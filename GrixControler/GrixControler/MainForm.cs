﻿using System;
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

        String[] reservationTime_Mon_ON;
        String[] reservationTime_Tues_ON;
        String[] reservationTime_Wednes_ON;
        String[] reservationTime_Thurs_ON;
        String[] reservationTime_Fri_ON;
        String[] reservationTime_Satur_ON;
        String[] reservationTime_Sun_ON;


        String[] reservationTime_ON_DAY;

        String[] reservationTime_ON_ID;

        String[] reservationTime_Mon_OFF;
        String[] reservationTime_Tues_OFF;
        String[] reservationTime_Wednes_OFF;
        String[] reservationTime_Thurs_OFF;
        String[] reservationTime_Fri_OFF;
        String[] reservationTime_Satur_OFF;
        String[] reservationTime_Sun_OFF;

        String[] reservationTime_OFF_ID;

        String[] reservationTime_OFF_DAY;

        int[] reservationTime_Mon_TEMP;
        int[] reservationTime_Tues_TEMP;
        int[] reservationTime_Wednes_TEMP;
        int[] reservationTime_Thurs_TEMP;
        int[] reservationTime_Fri_TEMP;
        int[] reservationTime_Satur_TEMP;
        int[] reservationTime_Sun_TEMP;

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

        String CheckDayOfWeek;

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
                if (serialConnect.CheckPortOpen())
                {
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
        }

        private void SerialThread()
        {
            while (_pauseEvent.WaitOne())
            {
                if (serialConnect.CheckPortOpen())
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

                            //MessageBox.Show(roomID[nowCount].ToString());
                            //MessageBox.Show(id_H.ToString() + " " + id_L.ToString());

                            RoomInfo hi = serialConnect.GetSerialPacket(serialConnect.readCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L));
                            //MessageBox.Show(roomID[nowCount].ToString() + " " + hi.ConnectOn);
                            
                            /*
                            if(hi.ConnectOn==false)
                            {

                                roomInfoList[nowCount].SetTemp = 100;
                            }
                            */
                            roomInfoList[nowCount].ID = Convert.ToInt32(roomID[nowCount]);
                            roomInfoList[nowCount].NowTemp = hi.NowTemp;
                            roomInfoList[nowCount].SetTemp = hi.SetTemp;
                            roomInfoList[nowCount].CheckSum = hi.CheckSum;
                            roomInfoList[nowCount].LockOn = hi.LockOn;
                            roomInfoList[nowCount].HeaterOn = hi.HeaterOn;
                            roomInfoList[nowCount].PowerOn = hi.PowerOn;
                            roomInfoList[nowCount].ConnectOn = hi.ConnectOn;


                            Thread.Sleep(50);
                        }
                    }
                    defaultCount = currentCount;

                    CheckReservation_OFF(CheckReservationTuple_OFF());
                    CheckReservation_ON(CheckReservationTuple_ON());
                    ExecuteReservation(CheckReservationTuple_ON(), CheckReservationTuple_OFF());
                }


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
                            /*
                            MessageBox.Show("if문 " + (roomView[i].roomName.Text == roomInfoList[j].ID.ToString()).ToString() + " " 
                            + roomView[i].roomName.Text + " " + roomInfoList[j].ID.ToString());
                            */
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

            public static String GetDayOfWeek()
            {
                return now.DayOfWeek.ToString();
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
            CheckDayOfWeek = Time.GetDayOfWeek();
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
                sql = "select count(*) from idTable where not ReservationStartDay = \'-\'";

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
             reservationTime_Mon_ON = new String[count];
             reservationTime_Tues_ON = new String[count];
             reservationTime_Wednes_ON = new String[count];
             reservationTime_Thurs_ON = new String[count];
             reservationTime_Fri_ON = new String[count];
             reservationTime_Satur_ON = new String[count];
             reservationTime_Sun_ON = new String[count];
            
            reservationTime_Mon_TEMP = new int[count];
            reservationTime_Tues_TEMP = new int[count];
            reservationTime_Wednes_TEMP = new int[count];
            reservationTime_Thurs_TEMP = new int[count];
            reservationTime_Fri_TEMP = new int[count];
            reservationTime_Satur_TEMP = new int[count];
            reservationTime_Sun_TEMP = new int[count];

            reservationTime_ON_ID = new String[count];
            reservationTime_ON_DAY = new String[count];

            sql = "select * from idTable where not ReservationStartDay = \'-\'";

            command = new SQLiteCommand(sql, dbConn);

            rdr = command.ExecuteReader();

            int i = 0;

            while (rdr.Read())
            {
                reservationTime_ON_ID[i] = Convert.ToInt32(rdr["roomID"]).ToString();
                reservationTime_ON_DAY[i] = rdr["ReservationStartDay"].ToString();

                reservationTime_Mon_ON[i] = rdr["MondayStartTime"].ToString();
                reservationTime_Tues_ON[i] = rdr["TuesdayStartTime"].ToString();
                reservationTime_Wednes_ON[i] = rdr["WednesdayStartTime"].ToString();
                reservationTime_Thurs_ON[i] = rdr["ThursdayStartTime"].ToString();
                reservationTime_Fri_ON[i] = rdr["FridayStartTime"].ToString();
                reservationTime_Satur_ON[i] = rdr["SaturdayStartTime"].ToString();
                reservationTime_Sun_ON[i] = rdr["SundayStartTime"].ToString();

                reservationTime_Mon_TEMP[i] = Convert.ToInt32(rdr["MondayTemp"]);
                reservationTime_Tues_TEMP[i] = Convert.ToInt32(rdr["TuesdayTemp"]);
                reservationTime_Wednes_TEMP[i] = Convert.ToInt32(rdr["WednesdayTemp"]);
                reservationTime_Thurs_TEMP[i] = Convert.ToInt32(rdr["ThursdayTemp"]);
                reservationTime_Fri_TEMP[i] = Convert.ToInt32(rdr["FridayTemp"]);
                reservationTime_Satur_TEMP[i] = Convert.ToInt32(rdr["SaturdayTemp"]);
                reservationTime_Sun_TEMP[i] = Convert.ToInt32(rdr["SundayTemp"]);

                i++;
            }
            rdr.Close();

        }

        private int CheckReservationTuple_OFF()
        {
            int count;
            try
            {
                sql = "select count(*) from idTable where not ReservationEndDay = \'-\'";

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
            
             reservationTime_Mon_OFF = new String[count];
             reservationTime_Tues_OFF = new String[count];
             reservationTime_Wednes_OFF = new String[count];
             reservationTime_Thurs_OFF = new String[count];
             reservationTime_Fri_OFF = new String[count];
             reservationTime_Satur_OFF = new String[count];
             reservationTime_Sun_OFF = new String[count];
            
            reservationTime_OFF_ID = new String[count];
            reservationTime_OFF_DAY = new String[count];

            sql = "select * from idTable where not ReservationEndDay = \'-\'";

            command = new SQLiteCommand(sql, dbConn);

            rdr = command.ExecuteReader();

            int i = 0;

            while (rdr.Read())
            {
                reservationTime_OFF_ID[i] = Convert.ToInt32(rdr["roomID"]).ToString();
                reservationTime_OFF_DAY[i] = rdr["ReservationEndDay"].ToString();

                reservationTime_Mon_OFF[i] = rdr["MondayEndTime"].ToString();
                reservationTime_Tues_OFF[i] = rdr["TuesdayEndTime"].ToString();
                reservationTime_Wednes_OFF[i] = rdr["WednesdayEndTime"].ToString();
                reservationTime_Thurs_OFF[i] = rdr["ThursdayEndTime"].ToString();
                reservationTime_Fri_OFF[i] = rdr["FridayEndTime"].ToString();
                reservationTime_Satur_OFF[i] = rdr["SaturdayEndTime"].ToString();
                reservationTime_Sun_OFF[i] = rdr["SundayEndTime"].ToString();

                i++;
            }
            rdr.Close();
            /** 18.5.11 
             * 저거는 배열 두개가 아니라 해시태그 사용해도 되는데 라는 생각이 지금들었다. 수정하도록하자 
             * 
             * */
        }


        private string[] ReservationEachDay_ON_Time(String day)
        {
            if (day == "Monday")
            {
                return reservationTime_Mon_ON;
            }
            else if (day == "Tuesday")
            {
                return reservationTime_Tues_ON;
            }
            else if (day == "Wednesday")
            {
                return reservationTime_Wednes_ON;
            }
            else if (day == "Thursday")
            {
                return reservationTime_Thurs_ON;
            }
            else if (day == "Saturday")
            {
                return reservationTime_Satur_ON;
            }
            else
                return reservationTime_Sun_ON;
            
        }

        private string[] ReservationEachDay_OFF_Time(String day)
        {
            if (day == "Monday")
            {
                return reservationTime_Mon_OFF;
            }
            else if (day == "Tuesday")
            {
                return reservationTime_Tues_OFF;
            }
            else if (day == "Wednesday")
            {
                return reservationTime_Wednes_OFF;
            }
            else if (day == "Thursday")
            {
                return reservationTime_Thurs_OFF;
            }
            else if (day == "Saturday")
            {
                return reservationTime_Satur_OFF;
            }
            else
                return reservationTime_Sun_OFF;

        }

        private int[] ReservationEachDay_ON_Temp(String day)
        {
            if (day == "Monday")
            {
                return reservationTime_Mon_TEMP;
            }
            else if (day == "Tuesday")
            {
                return reservationTime_Tues_TEMP;
            }
            else if (day == "Wednesday")
            {
                return reservationTime_Wednes_TEMP;
            }
            else if (day == "Thursday")
            {
                return reservationTime_Thurs_TEMP;
            }
            else if (day == "Saturday")
            {
                return reservationTime_Satur_TEMP;
            }
            else
                return reservationTime_Sun_TEMP;

        }

        private void ExecuteEachDay_ON(String day, String time, int temp, int roomIDIndex)
        {
            int hour = 0;
            int min = 0;
            String tt;
            int ttToInt = 0;
            

            tt = time.Substring(0, 2);
            if (tt == "오전") { }
                else ttToInt = 1;
            hour = Convert.ToInt32(time.Substring(2, 2));
            min = Convert.ToInt32(time.Substring(4, 2));

            if (CheckDayOfWeek == day && CheckHour == hour+ttToInt*12 && CheckMin == min && reserveCheck_A == 0)
                {
                    if (reservationTime_ON_ID[roomIDIndex].Length == 4)
                    {
                        id_H = reservationTime_ON_ID[roomIDIndex].Substring(0, 2);
                        id_L = reservationTime_ON_ID[roomIDIndex].Substring(2, 2);
                    }
                    else if (reservationTime_ON_ID[roomIDIndex].Length == 3)
                    {
                        id_H = reservationTime_ON_ID[roomIDIndex].Substring(0, 1);
                        id_L = reservationTime_ON_ID[roomIDIndex].Substring(1, 2);
                    }
                    else
                    {
                        id_H = "0";
                        id_L = reservationTime_ON_ID[roomIDIndex];
                    }

                    serialConnect.GetSerialPacket(serialConnect.powerOnCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L));
                    Thread.Sleep(50);
                    serialConnect.GetSerialPacket(serialConnect.setTempCmd((Byte)temp), (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L));
                    reserveCheck_A = 1;
                }

        }


        private void ExecuteEachDay_OFF(String day, String time, int roomIDIndex)
        {
            int hour = 0;
            int min = 0;
            String tt;
            int ttToInt = 0;

            tt = time.Substring(0, 2);
            if (tt == "오전") { }
            else ttToInt = 1;
            
            hour = Convert.ToInt32(time.Substring(2, 2));
            min = Convert.ToInt32(time.Substring(4, 2));

            if (CheckDayOfWeek == day && CheckHour == hour + ttToInt * 12 && CheckMin == min && reserveCheck_B == 0)
            {
                if (reservationTime_OFF_ID[roomIDIndex].Length == 4)
                {
                    id_H = reservationTime_OFF_ID[roomIDIndex].Substring(0, 2);
                    id_L = reservationTime_OFF_ID[roomIDIndex].Substring(2, 2);
                }
                else if (reservationTime_OFF_ID[roomIDIndex].Length == 3)
                {
                    id_H = reservationTime_OFF_ID[roomIDIndex].Substring(0, 1);
                    id_L = reservationTime_OFF_ID[roomIDIndex].Substring(1, 2);
                }
                else
                { 
                    id_H = "0";
                    id_L = reservationTime_OFF_ID[roomIDIndex];
                }

                serialConnect.GetSerialPacket(serialConnect.powerOffCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L));
                reserveCheck_B = 1;
                Thread.Sleep(50);
            }
            
        }

        private void ExecuteReservation(int onCount, int OffCount)
        {
            

            String id_H;
            String id_L;

            String[] eachDay;

            for (int i = 0; i < onCount; i++)
            {
                eachDay = SeperateDay(reservationTime_ON_DAY[i]);
                /**
                 * 해당 방의, 시작 요일들을 나눠서 eachday에 넣어놓고,
                 * 아래에서 월요일이면, 월요일의 전체 time을 가져오고
                 * i번째에 해당하는 time을 추출하면 끝
                 * */

                for(int k = 0; k < eachDay.Length; k++)
                {
                    string[] onTimeEachDay = ReservationEachDay_ON_Time(eachDay[k]);
                    int[] tempEachDay = ReservationEachDay_ON_Temp(eachDay[k]);
                    ExecuteEachDay_ON(eachDay[k],onTimeEachDay[i], tempEachDay[i], i); //여기는 오전0800이 들어감
                }
            }


            for (int i = 0; i < OffCount; i++)
            {
                eachDay = SeperateDay(reservationTime_OFF_DAY[i]);
                /**
                 * 해당 방의, 시작 요일들을 나눠서 eachday에 넣어놓고,
                 * 아래에서 월요일이면, 월요일의 전체 time을 가져오고
                 * i번째에 해당하는 time을 추출하면 끝
                 * */

                for (int k = 0; k < eachDay.Length; k++)
                {
                    string[] onTimeEachDay = ReservationEachDay_OFF_Time(eachDay[k]);
                    ExecuteEachDay_OFF(eachDay[k], onTimeEachDay[i], i); //여기는 오전0800이 들어감
                }
            }


           

        }
        public void ResetAllVariable()
        {
            check_UI = 1;
            roominfoControl = 1;
            check = 0;
            reserveCheck_A = 0;
            reserveCheck_B = 0;
            roomInfoList.Clear();

            for(int i = 0; i < roomView.Length; i++)
            {
                roomView[i].current_Temp.Invoke((MethodInvoker)delegate ()
                {
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



        private String[] SeperateDay(String str)
        {
            String[] strArray = new String[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                strArray[i] = str.Substring(i, 1);
            }
            return strArray;
        }


    }





    /** 18.5.10
     * 중복되는 코드가 많음 리펙토링 필수
     * 
     * 
     * */
}
