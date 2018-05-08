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

        private bool view_Handle = true;

        public MainForm()
        {
            InitializeComponent();

            serialConnect = new SerialConnect(this);
            serialConnect.AutoConnect();

            try
            {
                sqliteconnect = new SqliteInit();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            dbConn.Open();

            ri = new RoomInfo();

            defaultCount = TupleCount();

            SetRoomIDString(defaultCount);

            SetRoomView(defaultCount, ri);

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
            while (_pauseEvent.WaitOne()) //false가 되면 while문을 빠져나가겠지 
            {
                if (view_Handle)
                {
                    //MessageBox.Show("UIThread");
                    try
                    {
                        UpdateRoomView(currentCount);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
            }
        }

        private void SerialThread()
        {
            while (_pauseEvent.WaitOne())
            {

                //MessageBox.Show(thread_UI.IsAlive.ToString());
                compareCount = TupleCount();
                SetRoomIDString(compareCount);

                if (defaultCount == compareCount && CheckRoomIDChange(compareCount))
                {
                    currentCount = defaultCount;
                }
                else
                {
                    currentCount = compareCount;
                    view_Handle = false;
                    RemoveRoomView(defaultCount, currentCount);
                }

                if (check == 0)
                {
                    for (int nowCount = 0; nowCount < currentCount; nowCount++)
                    {
                        if (roomID[nowCount].Length == 4)
                        {
                            id_H = roomID[nowCount].Substring(0, 2);
                            id_L = roomID[nowCount].Substring(2, 2);
                        }
                        else if (roomID[nowCount].Length == 3)
                        {
                            id_H = roomID[nowCount].Substring(0, 1);
                            id_L = roomID[nowCount].Substring(1, 2);
                        }
                        else
                        {
                            id_H = "0";
                            id_L = roomID[nowCount];
                        }

                        compareChecksum[1] = (byte)Convert.ToInt32(id_H);
                        compareChecksum[2] = (byte)Convert.ToInt32(id_L);


                        roomInfoList.Add(serialConnect.GetSerialPacket(serialConnect.readCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L)));

                        Thread.Sleep(50);
                    }
                    check = 1;
                }
                else
                {

                    for (int nowCount = 0; nowCount < currentCount; nowCount++)
                    {

                        if (roomID[nowCount].Length == 4)
                        {
                            id_H = roomID[nowCount].Substring(0, 2);
                            id_L = roomID[nowCount].Substring(2, 2);
                        }
                        else if (roomID[nowCount].Length == 3)
                        {
                            id_H = roomID[nowCount].Substring(0, 1);
                            id_L = roomID[nowCount].Substring(1, 2);
                        }
                        else
                        {
                            id_H = "0";
                            id_L = roomID[nowCount];
                        }

                        compareChecksum[1] = (byte)Convert.ToInt32(id_H);
                        compareChecksum[2] = (byte)Convert.ToInt32(id_L);
                        if (roomInfoList.Count < nowCount + 1)
                        {
                            roomInfoList.Add(serialConnect.GetSerialPacket(serialConnect.readCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L)));

                        }

                        if (roomView.Length < roomInfoList.Count)
                        {
                            roomInfoList.RemoveRange(roomView.Length, roomInfoList.Count - roomView.Length);
                        }

                        if (roominfoControl == 0)
                        {
                            break;
                        }
                        RoomInfo hi = serialConnect.GetSerialPacket(serialConnect.readCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L));
                        roomInfoList[nowCount].NowTemp = hi.NowTemp;
                        roomInfoList[nowCount].SetTemp = hi.SetTemp;
                        roomInfoList[nowCount].CheckSum = hi.CheckSum;
                        roomInfoList[nowCount].LockOn = hi.LockOn;
                        roomInfoList[nowCount].HeaterOn = hi.HeaterOn;

                        Thread.Sleep(50);

                    }
                }

                defaultCount = currentCount;
            }
        }

        public void UpdateRoomView(int count)
        {
            try
            {
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
                         * 
                         * room 지우고 새로 만들었을 때, 원래 배열 크기보다 더 커지면, UI 쓰레드가 멈춤 -> resize문제
                         * 
                         * ---------------------------------------------------------해결 18.5.8
                         * while문에서 false가 되면 while문을 빠져나감 _pauseEvent.WaitOne()이 true false 내부적으로 다른듯 
                         *  &&연산을 통하여 나온 결과로는 false가 되어 UI가 멈추는 거였음. 따라서 while은 _pauseEvent.WaitOne()만 두고 내부에서 
                         *  if handle을 두어 여부에 따라 동작, 비동작으로 구분지음
                         * 
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

                }
            }
            catch (IndexOutOfRangeException e)
            {
                MessageBox.Show(e.ToString());
            }

        }


        public void SetRoomView(int count, RoomInfo roomInfo)
        {
            roomView = new RoomView[count];

            for (int i = 0; i < count; i++)
            {

                roomView[i] = new RoomView(this);
                roomView[i].roomName.Text = roomID[i];

                ViewPanel.Controls.Add(roomView[i]);
            }


        }

        private bool CheckRoomIDChange(int count)
        {
            for (int i = 0; i < count; i++)
            {
                //MessageBox.Show(roomView[i].roomName.Text + " " + roomID[i].ToString());
                if (roomView[i].roomName.Text != roomID[i])
                {
                    return false;
                }
            }
            return true;
        }

        public void RemoveRoomView(int defaultCount, int newCount)
        {
            //MessageBox.Show("Enter ther removeRoomView");

            this.defaultCount = newCount;

            for (int i = 0; i < defaultCount; i++)
            {
                roomView[i].Invoke((MethodInvoker)delegate ()
               {
                   ViewPanel.Controls.Remove(roomView[i]);

               });

            }

            SetRoomIDString(newCount);

            Array.Resize(ref roomView, newCount);
            /**18.5.8 
             * resize가 여기있을때에는 줄어드나 늘어나나 UI스레드가 멈춤, serial스레드는살아있는걸로봐서
             * thread resume은 제데로 작동함.
             * 
             * 
             * --------------------------------------
             * Resize문제가 아니라 ProgramSetting을 나갈경우 그냥 UI스레드가 멈춤 
             * 
             * 왜 멈추는지 찾지 못해서 같이 동작하는 serial 스레드에서 ui스레드가 멈췄을 경우 다시 동작하도록 코딩함
             * ㅠㅠ
             * 
             * ---> 해결 testupdateview 주석 확인
             * */

            if (defaultCount < newCount)
            {
                //Array.Resize(ref roomView, newCount);
                for (int k = defaultCount; k < newCount; k++)
                {
                    roomView[k] = new RoomView(this);
                }
            }

            for (int i = 0; i < newCount; i++)
            {

                ViewPanel.Invoke((MethodInvoker)delegate ()
                {
                    ViewPanel.Controls.Add(roomView[i]);
                });

                roomView[i].Invoke((MethodInvoker)delegate ()
                {
                    roomView[i].roomName.Text = roomID[i];
                });

            }
            view_Handle = true;
            //MessageBox.Show(_pauseEvent.WaitOne() + view_Handle.ToString());
        }



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


        private void button2_Click(object sender, EventArgs e)
        {
            ProgramSetting pgset = new ProgramSetting(this);
            pgset.ShowDialog();
        }

        private void AdminSet_Click(object sender, EventArgs e)
        {

            ReservationSetting reSet = new ReservationSetting(this);
            reSet.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {


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


        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.loadNow();
            Time.setNow();
            timeLabel.Text = Time.All;
        }




        public int TupleCount()
        {
            int count;
            try
            {
                sql = "select count(*) from idTable";

                command = new SQLiteCommand(sql, dbConn);

                object scalarValue = command.ExecuteScalar();
                count = Convert.ToInt32(scalarValue);

                return count;
            }
            catch (Exception er)
            {
                MessageBox.Show("SQLite3 Database Connection Error -> " + er.Message);
                return 0;
            }
        }

        public void SetRoomIDString(int count)
        {
            roomID = new string[count];

            sql = "select * from idTable";

            command = new SQLiteCommand(sql, dbConn);

            rdr = command.ExecuteReader();

            int i = 0;
            object remRoomID;

            while (rdr.Read())
            {

                roomID[i] = Convert.ToInt32(rdr["roomID"]).ToString();

                i++;
            }
            rdr.Close();
        }

    }
}
