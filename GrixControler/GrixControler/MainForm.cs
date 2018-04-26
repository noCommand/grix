using System;
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


namespace GrixControler
{
    public partial class MainForm : Form
    {
        SqliteInit sqliteconnect;

        SerialConnect serialConnect;

        SQLiteConnection dbConn = new SQLiteConnection(@"Data Source=" + Application.StartupPath + @"\GrixDB" + @"\grixdb.db");

        SQLiteCommand command;

        SQLiteDataReader rdr;

        String sql;

        int result;

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
            


            RoomView roomDataView = new RoomView();

            try
            {
                sqliteconnect = new SqliteInit();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }


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
        
     

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProgramSetting pgset = new ProgramSetting();
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
            dbConn.Open();
            /** 18.4.26
             *  main에서 db를 열어놓고 다시 닫지 않아도, 다른 폼에서 db를 사용하려면 db를 다시 열어야한다.
             *  이유 - ? 포커스가 바뀔때 db가 닫혀서?
             * */

            int count;

            timer1.Start();
            timer1.Interval = 1000;

            Time.setNow();
            timeLabel.Text = Time.All;

            count = tupleCount();

            setRoomView(count);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialConnect.portClose();
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
        
        public void setRoomView(int count)
        {

            RoomView[] roomView = new RoomView[count];
            
            for (int i = 0; i < count; i++)
            {
                roomView[i] = new RoomView();
                ViewPanel.Controls.Add(roomView[i]);
            }
            /** roomview 단일 객체로 올리면 화면에 올라가는데
             *  배열을사용해 올리면 올라가지 않음 -> 
             *  -----------------------------------------------
             *  당연히 안되지 -> 인스턴스를 생성하고 추가해줘야지 저건 껍데기만있는거임!
             * */



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

                return count;
           }
           catch (Exception er)
           {
               MessageBox.Show("SQLite3 Database Connection Error -> " + er.Message);
                return 0;
           }
        }


    }
}
