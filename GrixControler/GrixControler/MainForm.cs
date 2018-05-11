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
        public Thread thread_Main;


        RoomView[] roomView;

        RoomInfo ri;

        String[] roomID;

        String[] reservationTime_ON;

        String[] reservationTime_ON_ID;

        String[] reservationTime_OFF;

        String[] reservationTime_OFF_ID;

        int[] reservationTime_TEMP;

        int currentCount, defaultCount, compareCount;

        String id_H, id_L;

        int reserveCheck_A = 0;

        int reserveCheck_B = 0;

        public List<RoomInfo> roomInfoList = new List<RoomInfo>();

        private int roominfoControl = 1;

        static readonly object locker = new object();

        private int check = 0;

        private bool view_Handle = true;

        int CheckHour;

        int CheckMin;

        public MainForm()
        {
            InitializeComponent();

            serialConnect = new SerialConnect(this);
            //serialConnect.AutoConnect();

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

            /*
            thread_Main = new Thread(MainThread);
            thread_Main.IsBackground = true;
            thread_Main.Start();
            */
            
            thread_Serial = new Thread(SerialThread);
            thread_UI = new Thread(UIThread);

            thread_Serial.IsBackground = true;
            thread_UI.IsBackground = true;

            thread_Serial.Start();
            thread_UI.Start();
            
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

        /*
        public void MainThread()
        {
            while (_pauseEvent.WaitOne())
            { 
                try
                {
                    thread_Serial = new Thread(SerialThread);
                    thread_UI = new Thread(UIThread);

                    thread_Serial.IsBackground = true;
                    thread_UI.IsBackground = true;

                    thread_Serial.Start();
                    thread_UI.Start();
                }
                catch (InvalidOperationException e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }
        */

        private void UIThread()
        {
            while (_pauseEvent.WaitOne()) //false가 되면 while문을 빠져나가겠지 
            {
                //MessageBox.Show(serialConnect.GetPortName());
                
                try
                {
                    //MessageBox.Show("roomview" + roomView.Length + "roomInfoList" + roomInfoList.Count.ToString());
                    //MessageBox.Show(serialConnect)
                    UpdateRoomView(currentCount);
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
                    /** 포트 재설정할때 어떻게 add할껀지 생각해야함
                     * 
                     * */


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
                        roomInfoList[nowCount].PowerOn = hi.PowerOn;

                        Thread.Sleep(50);
                    }
                }

                defaultCount = currentCount;

                CheckReservation_OFF(CheckReservationTuple_OFF());
                CheckReservation_ON(CheckReservationTuple_ON());
                ExecuteReservation(CheckReservationTuple_ON(), CheckReservationTuple_OFF());
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
                        //MessageBox.Show("viewhandle " + view_Handle.ToString());
                        if (view_Handle)
                        {
                            //MessageBox.Show("if문 " + (roomView[i].roomName.Text == roomInfoList[j].ID.ToString()).ToString() + " " 
                                //+ roomView[i].roomName.Text + " " + roomInfoList[j].ID.ToString());
                            if (roomView[i].roomName.Text == roomInfoList[j].ID.ToString())
                            {
                                if (roomInfoList[j].PowerOn == true)
                                {
                                    roomView[i].current_Temp.Invoke((MethodInvoker)delegate ()
                                    {
                                        //MessageBox.Show(roomInfoList[j].NowTemp.ToString() + "UIThread");
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
                                else
                                {
                                    
                                    roomView[i].current_Temp.Invoke((MethodInvoker)delegate ()
                                    {
                                        //MessageBox.Show(roomInfoList[j].NowTemp.ToString() + "UIThread - poweroff");
                                        roomView[i].current_Temp.Text = "0";
                                    });
                                    roomView[i].desired_Temp.Invoke((MethodInvoker)delegate ()
                                    {
                                        roomView[i].desired_Temp.Text = "0";
                                    });
                                    roomView[i].picture_Lock.Invoke((MethodInvoker)delegate ()
                                    {
                                        roomView[i].picture_Lock.Visible = false;
                                    });
                                    roomView[i].picture_Heat.Invoke((MethodInvoker)delegate ()
                                    {
                                        roomView[i].picture_Heat.Visible = false;
                                    });
                                }
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

            public static int GetHour()
            {
                return now.Hour;
            }

            public static int GetMin()
            {
                return now.Minute;
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

            CheckHour = Time.GetHour();
            CheckMin = Time.GetMin();
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

        private int CheckReservationTuple_ON()
        {
            int count;
            try
            {
                sql = "select count(*) from idTable where not onTime = \"\"";

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


        private void CheckReservation_ON(int count)
        {
            reservationTime_ON = new String[count];
            reservationTime_TEMP = new int[count];
            reservationTime_ON_ID = new String[count];

            sql = "select * from idTable where not onTime = \"\"";

            command = new SQLiteCommand(sql, dbConn);

            rdr = command.ExecuteReader();

            int i = 0;

            while (rdr.Read())
            {
                reservationTime_ON_ID[i] = Convert.ToInt32(rdr["roomID"]).ToString();
                reservationTime_ON[i] = rdr["onTime"].ToString();
                reservationTime_TEMP[i] = Convert.ToInt32(rdr["reservTemp"]);

                i++;
            }
            rdr.Close();

        }

        private int CheckReservationTuple_OFF()
        {
            int count;
            try
            {
                sql = "select count(*) from idTable where not offTime = \"\"";

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


        private void CheckReservation_OFF(int count)
        {
            reservationTime_OFF = new String[count];
            reservationTime_OFF_ID = new String[count];

            sql = "select * from idTable where not offtime = \"\"";

            command = new SQLiteCommand(sql, dbConn);

            rdr = command.ExecuteReader();

            int i = 0;

            while (rdr.Read())
            {
                reservationTime_OFF_ID[i] = Convert.ToInt32(rdr["roomID"]).ToString();
                reservationTime_OFF[i] = rdr["offTime"].ToString();
                i++;
            }
            rdr.Close();
            /** 18.5.11 
             * 저거는 배열 두개가 아니라 해시태그 사용해도 되는데 라는 생각이 지금들었다. 수정하도록하자 
             * 
             * */
        }


        private void ExecuteReservation(int onCount, int OffCount)
        {
            int hour = 0;
            int min = 0;
            int temp;

            String id_H;
            String id_L;


            for (int i = 0; i < onCount; i++)
            {
                string[] onSpString = reservationTime_ON[i].Split(' ');

                int onCheck = 1;
                for (int j = 0; j < onSpString.Length; j++)
                {
                    if (onSpString[j].Length == 3 && onCheck == 1)
                    {
                        hour = Convert.ToInt32(onSpString[j].Substring(0, 2));
                        onCheck = 0;
                    }
                    else if (onSpString[j].Length == 2 && onCheck == 1)
                    {
                        hour = Convert.ToInt32(onSpString[j].Substring(0, 1));
                        onCheck = 0;
                    }
                    else if (onSpString[j].Length == 3 && onCheck == 0)
                    {
                        min = Convert.ToInt32(onSpString[j].Substring(0, 2));
                        onCheck = 1;
                    }
                    else if (onSpString[j].Length == 2 && onCheck == 0)
                    {
                        min = Convert.ToInt32(onSpString[j].Substring(0, 1));
                        onCheck = 1;
                    }
                }

                if (CheckHour == hour && CheckMin == min && reserveCheck_A == 0)
                {
                    if (reservationTime_ON_ID[i].Length == 4)
                    {
                        id_H = reservationTime_ON_ID[i].Substring(0, 2);
                        id_L = reservationTime_ON_ID[i].Substring(2, 2);
                    }
                    else if (reservationTime_ON_ID[i].Length == 3)
                    {
                        id_H = reservationTime_ON_ID[i].Substring(0, 1);
                        id_L = reservationTime_ON_ID[i].Substring(1, 2);
                    }
                    else
                    {
                        id_H = "0";
                        id_L = reservationTime_ON_ID[i];
                    }

                    serialConnect.GetSerialPacket(serialConnect.powerOnCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L));
                    Thread.Sleep(50);
                    serialConnect.GetSerialPacket(serialConnect.setTempCmd((Byte)reservationTime_TEMP[i]), (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L));
                    reserveCheck_A = 1;
                }
            }

            for (int i = 0; i < OffCount; i++)
            {
                int offCheck = 1;
                string[] offSpString = reservationTime_OFF[i].Split(' ');

                for (int j = 0; j < offSpString.Length; j++)
                {
                    if (offSpString[j].Length == 3 && offCheck == 1)
                    {
                        hour = Convert.ToInt32(offSpString[j].Substring(0, 2));
                        offCheck = 0;
                    }
                    else if (offSpString[j].Length == 2 && offCheck == 1)
                    {
                        hour = Convert.ToInt32(offSpString[j].Substring(0, 1));
                        offCheck = 0;
                    }
                    else if (offSpString[j].Length == 3 && offCheck == 0)
                    {
                        min = Convert.ToInt32(offSpString[j].Substring(0, 2));
                        offCheck = 1;
                    }
                    else if (offSpString[j].Length == 2 && offCheck == 0)
                    {
                        min = Convert.ToInt32(offSpString[j].Substring(0, 1));
                        offCheck = 1;
                    }
                }

                if (CheckHour == hour && CheckMin == min && reserveCheck_B == 0)
                {
                    if (reservationTime_OFF_ID[i].Length == 4)
                    {
                        id_H = reservationTime_OFF_ID[i].Substring(0, 2);
                        id_L = reservationTime_OFF_ID[i].Substring(2, 2);
                    }
                    else if (reservationTime_OFF_ID[i].Length == 3)
                    {
                        id_H = reservationTime_OFF_ID[i].Substring(0, 1);
                        id_L = reservationTime_OFF_ID[i].Substring(1, 2);
                    }
                    else
                    {
                        id_H = "0";
                        id_L = reservationTime_OFF_ID[i];
                    }


                    serialConnect.GetSerialPacket(serialConnect.powerOffCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L));
                    reserveCheck_B = 1;
                    Thread.Sleep(50);
                }
            }


        }
    }

    /** 18.5.10
     * 중복되는 코드가 많음 리펙토링 필수
     * 
     * 
     * */
}
