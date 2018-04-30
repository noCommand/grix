﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.IO;
using System.Security.Permissions;
using System.Security;
using System.Security.Principal;
using System.Diagnostics;
using System.Data.SQLite;
using System.Threading;


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

        public Thread thread_UI;

        RoomView[] roomView;

        RoomInfo ri;

        String[] roomID;

        int currentCount, defaultCount, compareCount;

        public MainForm()
        {
            InitializeComponent();

            serialConnect = new SerialConnect();
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
             * */


            RoomView roomDataView = new RoomView(this);

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
            
            roomID = new String[defaultCount];
            
            for(int nowCount = 0; nowCount < defaultCount; nowCount++)
            {
                String id_H, id_L;
                if(roomID[i].Length == 4)
                {
                    id_H = roomID[i].Substring(0, 2);
                    id_L = roomID[i].Substring(2, 4);
                    ri = serialConnect.GetSerialPacket(serialConnect.readCmd,(byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L));

                    setRoomView(defaultCount, ri);
                } else if(roomID[i].Length == 3)
                {
                    id_H = roomID[i].Substring(0, 1);
                    id_L = roomID[i].Substring(1, 3);
                    ri = serialConnect.GetSerialPacket(serialConnect.readCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L));

                    setRoomView(defaultCount, ri);
                }
                else
                {
                    id_H = "0";
                    id_L = roomID[i];
                    ri = serialConnect.GetSerialPacket(serialConnect.readCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L));
                    setRoomView(defaultCount, ri);
                }
                
            }



            
            
            // -> 화면이 뜨기전에 while문이 계속 돌으므로 절대 뜨지않는다

            thread_UI = new Thread(testThread);
            thread_UI.IsBackground = true;
            thread_UI.Start();



        }
        
        public void ThreadPause()
        {
            _pauseEvent.Reset();
        }

        public void ThreadResume()
        {
            _pauseEvent.Set();
        }

        private void testThread()
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
                    removeRoomView(defaultCount, currentCount, ri);
                }

                try
                {
                    ri = serialConnect.GetSerialPacket(serialConnect.readCmd);
                    updateRoomView(currentCount, ri);
                    /* 비동기시 사용한다고 하는데,, 딱히
                    BeginInvoke((MethodInvoker)(() => {
                        updateRoomView(count, ri);
                        
                    }));
                    */
                }
                catch (Exception e)
                {

                }
                Thread.Sleep(3000);
            }

            //while은 그냥 돌아가는데 beginInvoke를 사용하면 터져버림 + thread.sleep을 써도 안터짐
        }


        public void setRoomView(int count, RoomInfo roomInfo)
        {
            roomView = new RoomView[count];
            
            for (int i = 0; i < count; i++)
            {

                roomView[i] = new RoomView(this);
                roomView[i].roomName.Text = roomInfo.ID.ToString();
                roomView[i].current_Temp.Text = roomInfo.NowTemp.ToString();
                roomView[i].desired_Temp.Text = roomInfo.SetTemp.ToString();
                roomView[i].picture_Lock.Visible = roomInfo.LockOn;
                roomView[i].picture_Heat.Visible = roomInfo.HeaterOn;

                ViewPanel.Controls.Add(roomView[i]);
            }

            /** 18.4.26 
             * UI를 지웠다가 다시만들 생각을 하지 말고
             * 만들어진 UI에서 텍스트만 변경시키자
             *  -> 적용
             * */

        }

        public void removeRoomView(int defaultCount, int newCount, RoomInfo roomInfo)
        {

            for (int i = 0; i < defaultCount; i++)
            {
                ViewPanel.Controls.Remove(roomView[i]);
            }

            for (int i = 0; i < newCount; i++)
            {
                if (defaultCount < newCount)
                {
                    roomView[i] = new RoomView(this);
                }

                roomView[i].roomName.Text = roomInfo.ID.ToString();
                roomView[i].current_Temp.Text = roomInfo.NowTemp.ToString();
                roomView[i].desired_Temp.Text = roomInfo.SetTemp.ToString();
                roomView[i].picture_Lock.Visible = roomInfo.LockOn;
                roomView[i].picture_Heat.Visible = roomInfo.HeaterOn;

                ViewPanel.Controls.Add(roomView[i]);
            }
        }

        public void updateRoomView(int count, RoomInfo roomInfo)
        {
            for (int i = 0; i < count; i++)
            {
                //roomView[i] = new RoomView(); 바보 다시 할당하니까 안되지
                roomView[i].roomName.Text = roomInfo.ID.ToString();
                roomView[i].current_Temp.Text = roomInfo.NowTemp.ToString();
                roomView[i].desired_Temp.Text = roomInfo.SetTemp.ToString();
                roomView[i].picture_Lock.Visible = roomInfo.LockOn;
                roomView[i].picture_Heat.Visible = roomInfo.HeaterOn;
            }
            //MessageBox.Show(roomInfo.LockOn.ToString());
        }

        /** roomview 단일 객체로 올리면 화면에 올라가는데
         *  배열을사용해 올리면 올라가지 않음 -> 
         *  -----------------------------------------------
         *  당연히 안되지 -> 인스턴스를 생성하고 추가해줘야지 저건 껍데기만있는거임!
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

            ReservationSetting reSet = new ReservationSetting();
            reSet.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            /** 18.4.26
             *  main에서 db를 열어놓고 다시 닫지 않아도, 다른 폼에서 db를 사용하려면 db를 다시 열어야한다.
             *  이유 - ? 포커스가 바뀔때 db가 닫혀서?
             * */

            /*
           timer1.Start();
           timer1.Interval = 1000;

           Time.setNow();
           timeLabel.Text = Time.All;
           */

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
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
                

                sql = "select * from idTable";

                command = new SQLiteCommand(sql, dbConn);

                rdr = command.ExecuteReader();

                int i = 0;

                while (rdr.Read())
                {
                    roomID[i] = Convert.ToInt32(rdr["roomID"]).ToString();
                    i++;
                }
                rdr.Close();

                ////////////////////////////////////////////////
                return count;
            }
            catch (Exception er)
            {
                MessageBox.Show("SQLite3 Database Connection Error -> " + er.Message);
                return 0;
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            serialConnect.setSerialPacket(serialConnect.readCmd);
            updateRoomView(defaultCount, ri);
        }
    }
}
