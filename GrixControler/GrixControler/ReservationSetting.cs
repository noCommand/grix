using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GrixControler
{
    public partial class ReservationSetting : Form
    {
        SQLiteConnection dbConn = new SQLiteConnection(@"Data Source=" + Application.StartupPath + @"\GrixDB" + @"\grixdb.db");

        SQLiteCommand command;

        SQLiteDataReader rdr;

        string sql;

        int result;

        int all_check = 0;

        MainForm main;

        public ReservationSetting(MainForm main)
        {
            this.main = main;
            main.ThreadPause();
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void ReservationSetting_Load(object sender, EventArgs e)
        {
            RoomList.View = View.Details;
            RoomList.GridLines = true;
            RoomList.FullRowSelect = true;
            RoomList.CheckBoxes = true;

            RoomList.Columns.Add("방번호", 50);
            RoomList.Columns.Add("켜질 시간", 100);
            RoomList.Columns.Add("꺼질 시간", 100);
            RoomList.Columns.Add("켜질때의 설정 온도", 150);

            for (int i = 0; i < 25; i++)
            {
                on_Hour.Items.Add(i);
                off_Hour.Items.Add(i);
            }
            for (int j = 0; j < 61; j++)
            {
                on_Min.Items.Add(j);
                off_Min.Items.Add(j);
            }
            for (int k = 0; k < 60; k++)
            {
                on_temp.Items.Add(k);
            }

            dbConn.Open();

            try
            {
                show_RoomList();
            }
            catch (Exception er)
            {
                MessageBox.Show("SQLite3 Database Connection Error -> " + er.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void apply_Btn_Click(object sender, EventArgs e)
        {

            if (RoomList.Items.Count > 0)

            {

                for (int i = 0; i <= RoomList.Items.Count - 1; i++)

                {
                    ListViewItem item = RoomList.Items[i];

                    if (RoomList.Items[i].Checked == true)

                    {
                        MessageBox.Show("2");
                        try
                        {
                            if (on_Hour.SelectedItem != null && on_Min.SelectedItem != null && on_temp.SelectedItem != null
                                && off_Hour.SelectedItem != null && off_Min.SelectedItem != null) //전부입력시 
                            {
                                sql = "update idTable set onTime = \'" + on_Hour.SelectedItem + "시 " + on_Min.SelectedItem + "분\'," +
                               "offTime =\'" + off_Hour.SelectedItem + "시 " + off_Min.SelectedItem + "분\'," +
                               "reservTemp =\'" + on_temp.SelectedItem + "\' where roomID = \'" + RoomList.Items[i].SubItems[0].Text + "\'";
                                command = new SQLiteCommand(sql, dbConn);
                                command.ExecuteNonQuery();
                            }
                            else if (on_Hour.SelectedItem != null && on_Min.SelectedItem != null && on_temp.SelectedItem != null
                                && off_Hour.SelectedItem == null && off_Min.SelectedItem == null) //on
                            {
                                sql = "update idTable set onTime = \'" + on_Hour.SelectedItem + "시 " + on_Min.SelectedItem + "분\', " +
                               "reservTemp =\'" + on_temp.SelectedItem + "\', offTime = null where roomID = \'" + RoomList.Items[i].SubItems[0].Text + "\'";
                                command = new SQLiteCommand(sql, dbConn);
                                command.ExecuteNonQuery();
                            }
                            else if (on_Hour.SelectedItem == null && on_Min.SelectedItem == null && on_temp.SelectedItem == null
                                && off_Hour.SelectedItem != null && off_Min.SelectedItem != null) //off
                            {
                                sql = "update idTable set onTime = null, reservTemp = null, " +
                               "offTime =\'" + off_Hour.SelectedItem + "시 " + off_Min.SelectedItem + "분\' " +
                               "where roomID = \'" + RoomList.Items[i].SubItems[0].Text + "\'";
                                command = new SQLiteCommand(sql, dbConn);
                                command.ExecuteNonQuery();
                            }
                            else if (on_Hour.SelectedItem == null && on_Min.SelectedItem == null && on_temp.SelectedItem == null
                                && off_Hour.SelectedItem == null && off_Min.SelectedItem == null)
                            {
                                sql = "update idTable set onTime = \'" + on_Hour.SelectedItem + on_Min.SelectedItem + "\'," +
                               "offTime =\'" + off_Hour.SelectedItem + "" + off_Min.SelectedItem + "\'," +
                               "reservTemp =\'" + on_temp.SelectedItem + "\' where roomID = \'" + RoomList.Items[i].SubItems[0].Text + "\'";
                                command = new SQLiteCommand(sql, dbConn);
                                command.ExecuteNonQuery();
                            }
                            else
                            {
                                MessageBox.Show("정확히 입력해주세요");
                            }


                            /* 지저분한 if문 코드 깔끔하게 할 수 있는 방법은...?ㅠ
                             * ...
                             * */

                            //RoomList.Refresh(); -> listview 갱신 안됨
                            /* 18.04.23 20:45
                             * git에 push하고나면 form에 있는 컨드롤-이벤트 관계가 끊어지는 현상이 발생
                             * ->버그?? 내가 뭘 잘못건들인건가?
                             * */
                        }
                        catch (Exception er)
                        {

                            MessageBox.Show("catch");
                            MessageBox.Show("SQLite3 Database Connection Error -> " + er.Message);
                        }
                    }

                }

            }
            show_RoomList();

            dbConn.Close();
        }


        private void reset_Btn_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("초기화하시겠습니까?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (dr == DialogResult.OK)
            {
                if (RoomList.Items.Count > 0)

                {

                    for (int i = 0; i <= RoomList.Items.Count - 1; i++)

                    {
                        ListViewItem item = RoomList.Items[i];

                        try
                        {
                            sql = "update idTable set onTime = \'" + on_Hour.SelectedItem + on_Min.SelectedItem + "\'," +
                                    "offTime =\'" + off_Hour.SelectedItem + "" + off_Min.SelectedItem + "\'," +
                                    "reservTemp =\'" + on_temp.SelectedItem + "\' where roomID = \'" + RoomList.Items[i].SubItems[0].Text + "\'";

                            command = new SQLiteCommand(sql, dbConn);
                            command.ExecuteNonQuery();
                        }

                        // 결국 sql문 빼고 아래 두줄은 무조건 들어가는데

                        catch (Exception er)
                        {

                            MessageBox.Show("catch");
                            MessageBox.Show("SQLite3 Database Connection Error -> " + er.Message);
                        }

                    }

                }
                MessageBox.Show("초기화 완료");
            }
            show_RoomList();

        }

        public void execute_Query(String sql)
        {

        }

        private void all_button_Click(object sender, EventArgs e)
        {


            if (all_check == 0 && RoomList.Items.Count > 0)
            {
                all_check = -1;

                for (int i = 0; i <= RoomList.Items.Count - 1; i++)
                {
                    RoomList.Items[i].Checked = true;
                }
            }
            else
            {
                all_check = 0;

                for (int i = 0; i <= RoomList.Items.Count - 1; i++)
                {
                    RoomList.Items[i].Checked = false;
                }
            }
        }

        public void review_RoomList()
        {
            //적용, 초기화 누르면 리스트 초기화
        }


        public void show_RoomList()
        {

            if (RoomList.Items.Count >= 0)
            {
                int count = RoomList.Items.Count;
                for (int i = 0; i <= count - 1; i++)

                {
                    RoomList.Items.RemoveAt(0);
                }

            }

            sql = "select * from idTable";

            command = new SQLiteCommand(sql, dbConn);

            rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                String[] reservation_arr = { rdr["roomID"].ToString(),
                        rdr["onTime"].ToString(),
                        rdr["offTime"].ToString(),
                        rdr["reservTemp"].ToString(),};
                var listViewItem = new ListViewItem(reservation_arr);
                RoomList.Items.Add(listViewItem);

            }
            rdr.Close();
        }

        private void ReservationSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.ThreadResume();
        }
    }
}
