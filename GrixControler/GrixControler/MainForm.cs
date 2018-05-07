using System;
using System.Data.SQLite;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;


namespace GrixControler
{
    public partial class MainForm : Form
    {
        SqliteInit sqliteconnect;

        public SerialConnect serialConnect;

        SQLiteConnection dbConn = new SQLiteConnection(@"Data Source=" + Application.StartupPath + @"\GrixDB" + @"\grixdb.db");

        private ManualResetEvent _pauseEvent = new ManualResetEvent(true);

        SQLiteCommand command;

        SQLiteDataReader rdr;

        String sql;

        int result;

        int check_UI = 1;

        public Thread thread_Serial;
        public Thread thread_UI;

        RoomView[] roomView;

        RoomInfo ri;

        String[] roomID;

        int currentCount, defaultCount, compareCount;

        String id_H, id_L;

        byte[] compareChecksum = new byte[18];

        public List<RoomInfo> roomInfoList = new List<RoomInfo>();

        private int roominfoControl = 1;

        static readonly object locker = new object();

        private int check = 0;

        private int view_Handle = 0;
        //창 핸들이 다 만들어질때까지 다른 스레드를 사용하지 않기위한 변수

        /** 배열 말고 ArrayList를 사용해야 한다. 이유는 -> 길이를 바꿀 수 없기 때문에
         *  궂이 removeroomView를 만들 필요가 없다.
         *  
         *  박싱 언박싱 + 자원의 사용
         *  http://www.mkexdev.net/Article/Content.aspx?parentCategoryID=1&categoryID=5&ID=671
         * */

        public MainForm()
        {
            InitializeComponent();

            serialConnect = new SerialConnect(this);
            serialConnect.AutoConnect();

            /* 현재 위치에서 상위폴더로 올라감
            System.IO.DirectoryInfo diPa = System.IO.Directory.GetParent(filePath);
            diPa = System.IO.Directory.GetParent(diPa.ToString());
            diPa = System.IO.Directory.GetParent(diPa.ToString());
            */

            /*  폴더 권한설정
            FileSecurity fsSecurity = File.GetAccessControl(di.ToString());
            fsSecurity.AddAccessRule(new FileSystemAccessRule("NETWORK SERVICE", FileSystemRights.FullControl,
                AccessControlType.Allow));
            File.SetAccessControl(di.ToString(), fsSecurity);
            
            /**
             * 폴더 접근불가때문에 권한설정문제인가했는데, 그냥 경로설정을 잘못한거였음. 
             **/
             
            try
            {
                sqliteconnect = new SqliteInit();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }


            dbConn.Open();
            ////////////////////////////////////////////
            ri = new RoomInfo();

            defaultCount = tupleCount();

            setRoomIDString(defaultCount);

            setRoomView(defaultCount, ri);

            // -> 화면이 뜨기전에 while문이 계속 돌으므로 절대 뜨지않는다

            thread_Serial = new Thread(SerialThread);
            thread_UI = new Thread(UIThread);
            thread_Serial.IsBackground = true;
            thread_UI.IsBackground = true;
            thread_UI.Start();
            thread_Serial.Start();



        }

        public void ThreadPause()
        {
            _pauseEvent.Reset();
            roominfoControl = 0;
        }

        public void ThreadResume()
        {
            Thread.Sleep(300);
            _pauseEvent.Set();
            roominfoControl = 1;
        }

        private void UIThread()
        {
            while (_pauseEvent.WaitOne() && view_Handle == 0)
            {
                try
                {
                    testUpdateRoomView(currentCount);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        private void SerialThread()
        {
            while (_pauseEvent.WaitOne())
            {
                compareCount = tupleCount();

                if (defaultCount == compareCount)
                {
                    currentCount = defaultCount;
                }
                else
                {
                    currentCount = compareCount;
                    view_Handle = 1;
                    removeRoomView(defaultCount, currentCount);
                }

                //MessageBox.Show("테스트다~~" + currentCount);
                if (check == 0)
                {
                    for (int nowCount = 0; nowCount < currentCount; nowCount++)
                    {
                        //MessageBox.Show("nowcount~~" + nowCount);
                        if (roomID[nowCount].Length == 4)
                        {
                            id_H = roomID[nowCount].Substring(0, 2);
                            id_L = roomID[nowCount].Substring(2, 4);
                        }
                        else if (roomID[nowCount].Length == 3)
                        {
                            id_H = roomID[nowCount].Substring(0, 1);
                            id_L = roomID[nowCount].Substring(1, 3);
                        }
                        else
                        {
                            id_H = "0";
                            id_L = roomID[nowCount];
                        }

                        compareChecksum[1] = (byte)Convert.ToInt32(id_H);
                        compareChecksum[2] = (byte)Convert.ToInt32(id_L);

                        //roomInfoList.RemoveAll(s => s.ID == nowCount);
                        /*
                        Monitor.Enter(locker);
                        try
                        {
                            roomInfoList.Add(serialConnect.GetSerialPacket(serialConnect.readCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L)));
                        }
                        finally
                        {
                            Monitor.Exit(locker);
                        }
                        */
                        roomInfoList.Add(serialConnect.GetSerialPacket(serialConnect.readCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L)));

                        //ri = serialConnect.GetSerialPacket(serialConnect.readCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L));

                        Thread.Sleep(50);
                    }
                    check = 1;
                }
                else
                {

                    for (int nowCount = 0; nowCount < currentCount; nowCount++)
                    {

                        //MessageBox.Show("nowcount~~" + nowCount);
                        if (roomID[nowCount].Length == 4)
                        {
                            id_H = roomID[nowCount].Substring(0, 2);
                            id_L = roomID[nowCount].Substring(2, 4);
                        }
                        else if (roomID[nowCount].Length == 3)
                        {
                            id_H = roomID[nowCount].Substring(0, 1);
                            id_L = roomID[nowCount].Substring(1, 3);
                        }
                        else
                        {
                            id_H = "0";
                            id_L = roomID[nowCount];
                        }

                        compareChecksum[1] = (byte)Convert.ToInt32(id_H);
                        compareChecksum[2] = (byte)Convert.ToInt32(id_L);

                        //roomInfoList.RemoveAll(s => s.ID == nowCount);
                       // MessageBox.Show(roomView.Length + " " + roomInfoList.Count.ToString() + " " + defaultCount.ToString() + " "  + currentCount.ToString());
                        if (roomInfoList.Count < nowCount + 1)
                        {
                            /*
                            Monitor.Enter(locker);
                            try
                            {
                                roomInfoList.Add(serialConnect.GetSerialPacket(serialConnect.readCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L)));

                            }
                            finally
                            {
                                Monitor.Exit(locker);
                            }
                            */
                            //MessageBox.Show(roomInfoList.Count.ToString());
                            roomInfoList.Add(serialConnect.GetSerialPacket(serialConnect.readCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L)));
                            
                            
                            /** 18.5.4 스레드가 멈출때, 눌렀을때의 getserialpacket 메서드를 씹고 다음 활동을 하는 것 같음. thread
                             * pause해도 이미 수행중이던 쓰레드는 마져 수행함
                             * 속도를 아무리 느리게해도 한번은 00으로 들어감
                             * 
                             * ---------------------------------
                             *  아래 if문으로 해결
                             *  
                             *  ------------------->>>>>>>>>>>>>>>
                             *  serialconnect에서 getserial sleep 200으로 줄이고, 맨앞에 clear 삭제하면 같은 현상 발생
                             * */
                            //MessageBox.Show(roomID[nowCount] + nowCount.ToString() + " " + hi.NowTemp + hi.SetTemp);
                            
                        }

                        if(roomView.Length < roomInfoList.Count)
                        {
                            roomInfoList.RemoveRange(roomView.Length, roomInfoList.Count - roomView.Length);
                            //MessageBox.Show("roomInfoList.Count" + roomInfoList.Count.ToString());
                        }

                        if (roominfoControl == 0)
                        {
                            break;
                            //클릭 시 hi의 값들이 00으로 들어가는 것을 막기 위한 if문
                        }
                        RoomInfo hi = serialConnect.GetSerialPacket(serialConnect.readCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L));
                        //MessageBox.Show(" roomlistcount "+roomInfoList.Count.ToString());
                        roomInfoList[nowCount].NowTemp = hi.NowTemp;
                        roomInfoList[nowCount].SetTemp = hi.SetTemp;
                        roomInfoList[nowCount].CheckSum = hi.CheckSum;
                        roomInfoList[nowCount].LockOn = hi.LockOn;
                        roomInfoList[nowCount].HeaterOn = hi.HeaterOn;
                        //ri = serialConnect.GetSerialPacket(serialConnect.readCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L));

                        Thread.Sleep(50);

                    }
                }


                /*
                foreach (RoomInfo info in roomInfoList)
                {
                    if (info.ID==1)
                    {
                        MessageBox.Show(info.NowTemp.ToString());
                    }
                }
                */
                defaultCount = currentCount;
            }
        }

        public void testUpdateRoomView(int count)
        {


            /** 18.5.1
             *  read를 한 값을 넣치 말고 내가 roominfo에 저장해놓은 정보를 가져오자
             * 
             *  main에서 roominfo 배열이나 리스트를 만들어서 계속 저장시켜놓으면 될듯
             * 
             * */
            //MessageBox.Show("roomID " + roomID + roomID.GetType());
           //MessageBox.Show("Update count" + count.ToString());
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < roomInfoList.Count; j++)
                {
                    if (roomView[i].roomName.Text == roomInfoList[j].ID.ToString())
                    /** 18.5.7 roomview 전부 다 지웠을때 여기서 인덱스 범위 벗어났습니다라는 에러 발생   ING
                     *  -> 근데 삭제 이후 위의 MessageBox.Show(count.ToString());가 찍히지 않고 에러가 발생하는걸로 보아서.. 에러코드는 여기라고 인식하는데
                     *  정작 다른데서 문제가 있는거같음
                     * 
                     * removeview에서 resize... 여부에따라 ui갱신 되고 안되고.. 쓰레드가 멈출때가 있음
                     * */
                    {
                        //MessageBox.Show(roomInfoList.Count + " " + i + " roomName.Text " + roomView[i].roomName.Text + " roomInfoList " + roomInfoList[j].ID.ToString());

                        if (roomInfoList[j].PowerOn == true)
                        {
                            //MessageBox.Show("Update index" + i.ToString());
                            roomView[i].current_Temp.Invoke((MethodInvoker)delegate ()
                            {
                                //MessageBox.Show(roomView[i].roomName.Text + "   " + roomID + " " + roomInfo.NowTemp.ToString());
                                roomView[i].current_Temp.Text = roomInfoList[j].NowTemp.ToString();
                            });
                            roomView[i].desired_Temp.Invoke((MethodInvoker)delegate ()
                            {
                                roomView[i].desired_Temp.Text = roomInfoList[j].SetTemp.ToString();
                            });
                            roomView[i].picture_Lock.Invoke((MethodInvoker)delegate ()
                            {
                                roomView[i].picture_Lock.Visible = roomInfoList[j].LockOn;
                            });
                            roomView[i].picture_Heat.Invoke((MethodInvoker)delegate ()
                            {
                                roomView[i].picture_Heat.Visible = roomInfoList[j].HeaterOn;
                            });
                        }
                    }
                }
                /*
                foreach (RoomInfo info in roomInfoList)
                {
                    //MessageBox.Show("roomView " + roomView[i].roomName.Text + info.PowerOn.ToString());
                    if (roomView[i].roomName.Text == info.ID.ToString())
                    {
                        
                        if (info.PowerOn == true)
                        {
                            //MessageBox.Show(roomInfoList.Count+ " " + i + " roomName.Text " + roomView[i].roomName.Text + " info.ID " + info.ID.ToString() + " Temp " + info.SetTemp.ToString());
                            roomView[i].current_Temp.Invoke((MethodInvoker)delegate ()
                            {
                                //MessageBox.Show(roomView[i].roomName.Text + "   " + roomID + " " + roomInfo.NowTemp.ToString());
                                roomView[i].current_Temp.Text = info.NowTemp.ToString();
                            });
                            roomView[i].desired_Temp.Invoke((MethodInvoker)delegate ()
                            {
                                roomView[i].desired_Temp.Text = info.SetTemp.ToString();
                            });
                            roomView[i].picture_Lock.Invoke((MethodInvoker)delegate ()
                            {
                                roomView[i].picture_Lock.Visible = info.LockOn;
                            });
                            roomView[i].picture_Heat.Invoke((MethodInvoker)delegate ()
                            {
                                roomView[i].picture_Heat.Visible = info.HeaterOn;
                            });
                        }
                    }
                }
                */

            }
            //roomView[i] = new RoomView(); 바보 다시 할당하니까 안되지
            //roomView[i].roomName.Text = roomInfo.ID.ToString();

            //MessageBox.Show(roomInfo.LockOn.ToString());
        }


        public void setRoomView(int count, RoomInfo roomInfo)
        {
            roomView = new RoomView[count];

            for (int i = 0; i < count; i++)
            {

                roomView[i] = new RoomView(this);
                roomView[i].roomName.Text = roomID[i];
                //roomView[i].current_Temp.Text = roomInfo.NowTemp.ToString();
                //roomView[i].desired_Temp.Text = roomInfo.SetTemp.ToString();
                //roomView[i].picture_Lock.Visible = roomInfo.LockOn;
                //roomView[i].picture_Heat.Visible = roomInfo.HeaterOn;

                ViewPanel.Controls.Add(roomView[i]);
            }

            /** 18.4.26 
             * UI를 지웠다가 다시만들 생각을 하지 말고
             * 만들어진 UI에서 텍스트만 변경시키자
             *  -> 적용
             * */

        }

        /** 18.5.1 ************************************************************************
         * Invoke((MethodInvoker)delegate ()
         * 크로스스레드 작업 에러 - 컨트롤이 자신이 만들어진 스레드가 아닌 스레드에서 엑세스 되었습니다.
         *  UI Control들은 폼 구동시 실행되는 하나의 쓰레드에서 구동된다.
         *  따라서 사용자가 실행시킨 쓰레드는 별도로 실행 되기 때문에 이 
         *  메인 쓰레드에 적절한 마샬링 없이 다른쓰레드에서 직접 접근하면
         *  다른 쓰레드를 침범하는 것이다. (Cross Thread Problem) 이런 경우에는 
         *  프로그램이 개발자가 설계한대로 잘 동작하지 않을 수 있다.(Race Condition,DeadLock)  
         *  따라서, 안전하게 동작하게 하기위하여 .Net 환경에서는 Invoke를 제공하고 있다.
         * */


        public void removeRoomView(int defaultCount, int newCount)
        {

            this.defaultCount = newCount;

            for (int i = 0; i < defaultCount; i++)
            {
                roomView[i].Invoke((MethodInvoker)delegate ()
               {
                   ViewPanel.Controls.Remove(roomView[i]);
                   
               });

            }
            
            setRoomIDString(newCount);

            if (defaultCount < newCount)
            {
                Array.Resize(ref roomView, newCount);

                for (int k = defaultCount; k < newCount; k++)
                {
                    roomView[k] = new RoomView(this);
                }
            }

            for (int i = 0; i < newCount; i++)
            {
                roomView[i].roomName.Text = roomID[i];
                
                ViewPanel.Invoke((MethodInvoker)delegate ()
                {
                    ViewPanel.Controls.Add(roomView[i]);
                });

            }
            view_Handle = 0;
        }
        /**
         *  18.05.01 설정에서 방 줄이면 화면 이상, 늘리면 터짐 
         *  인덱스문제 해결
         * 
         * */


        class Time
        {
            private static DateTime now = DateTime.Now;
            public static string All;

            public static void loadNow()
            {
                now = DateTime.Now;
            }

            public static void setNow()
            {
                int Year = now.Year;
                int Month = now.Month;
                int Day = now.Day;
                int Hour = now.Hour;
                int Min = now.Minute;
                int Sec = now.Second;
                All = Year + "-" + Month + "-" + Day + "    " + Hour + ":" + Min + ":" + Sec;
            }

        }



        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProgramSetting pgset = new ProgramSetting(this);
            pgset.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void customButton2_Load(object sender, EventArgs e)
        {

        }

        private void AdminSet_Click(object sender, EventArgs e)
        {

            ReservationSetting reSet = new ReservationSetting(this);
            reSet.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            /** 18.4.26
             *  main에서 db를 열어놓고 다시 닫지 않아도, 다른 폼에서 db를 사용하려면 db를 다시 열어야한다.
             *  이유 - ? 포커스가 바뀔때 db가 닫혀서?
             * */

            timer1.Start();
            timer1.Interval = 1000;

            Time.setNow();
            timeLabel.Text = Time.All;

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ThreadPause();
            serialConnect.PortClose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.loadNow();
            Time.setNow();
            timeLabel.Text = Time.All;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        public int tupleCount()
        {
            int count;
            try
            {
                sql = "select count(*) from idTable";

                command = new SQLiteCommand(sql, dbConn);

                object scalarValue = command.ExecuteScalar();
                count = Convert.ToInt32(scalarValue);
                /**
                 * object를 강제형변환으로 int로 변환 불가능한 이유?
                 **/
                ////////////////////////////////////////////////////


                ////////////////////////////////////////////////
                return count;
            }
            catch (Exception er)
            {
                MessageBox.Show("SQLite3 Database Connection Error -> " + er.Message);
                return 0;
            }
        }

        public void setRoomIDString(int count)
        {
            roomID = new string[count];

            sql = "select * from idTable";

            command = new SQLiteCommand(sql, dbConn);

            rdr = command.ExecuteReader();

            int i = 0;
            object remRoomID;

            while (rdr.Read())
            {
                //remRoomID= rdr["roomID"];
                //MessageBox.Show(remRoomID.ToString());
                //roomID[i] =remRoomID.ToString();
                roomID[i] = Convert.ToInt32(rdr["roomID"]).ToString(); //한번에 쓰면 개체참조의 인스턴스로 설정되지 않았습니다.

                // ------------> Convert쓰는이유? 그냥 .tostring도 되긴함

                i++;
            }
            rdr.Close();
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            //serialConnect.setSerialPacket(serialConnect.readCmd);
            //updateRoomView(defaultCount, ri);
        }
    }
}
