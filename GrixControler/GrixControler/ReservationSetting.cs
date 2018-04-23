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

        public ReservationSetting()
        {
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

            for(int i = 0; i < 25; i++)
            {
                on_Hour.Items.Add(i);
                off_Hour.Items.Add(i);
            }
            for(int j = 0; j < 61; j++)
            {
                on_Min.Items.Add(j);
                off_Min.Items.Add(j);
            }
            for(int k = 0; k < 60; k++)
            {
                on_temp.Items.Add(k);
            }

            dbConn.Open();

            try
            {
                showRoomList();
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
            MessageBox.Show("1");


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
                            if(on_Hour.SelectedItem != null && on_Min.SelectedItem != null && on_temp.SelectedItem != null
                                && off_Hour.SelectedItem !=null && off_Min.SelectedItem !=null) //전부입력시 
                            {
                                sql = "update idTable set onTime = \'" + on_Hour.SelectedItem + "시 " + on_Min.SelectedItem + "분\'," +
                               "offTime =\'" + off_Hour.SelectedItem + "시 " + off_Min.SelectedItem + "분\'," +
                               "reservTemp =\'" + on_temp.SelectedItem + "\' where roomID = \'" + RoomList.Items[i].SubItems[0].Text + "\'";

                                execute_Query(sql);
                            }
                            else if (on_Hour.SelectedItem != null && on_Min.SelectedItem != null && on_temp.SelectedItem != null
                                && off_Hour.SelectedItem == null && off_Min.SelectedItem == null) //on
                            {
                                sql = "update idTable set onTime = \'" + on_Hour.SelectedItem + "시 " + on_Min.SelectedItem + "분\', " +
                               "reservTemp =\'" + on_temp.SelectedItem + "\', offTime = null where roomID = \'" + RoomList.Items[i].SubItems[0].Text + "\'";

                                execute_Query(sql);
                            }
                            else if (on_Hour.SelectedItem == null && on_Min.SelectedItem == null && on_temp.SelectedItem == null
                                && off_Hour.SelectedItem != null && off_Min.SelectedItem != null) //off
                            {
                                sql = "update idTable set onTime = null, reservTemp = null, " +
                               "offTime =\'" + off_Hour.SelectedItem + "시 " + off_Min.SelectedItem + "분\' " +
                               "where roomID = \'" + RoomList.Items[i].SubItems[0].Text + "\'";

                                execute_Query(sql);
                            }
                            else if (on_Hour.SelectedItem == null && on_Min.SelectedItem == null && on_temp.SelectedItem == null
                                && off_Hour.SelectedItem == null && off_Min.SelectedItem == null)
                            {
                                sql = "update idTable set onTime = \'" + on_Hour.SelectedItem + on_Min.SelectedItem + "\'," +
                               "offTime =\'" + off_Hour.SelectedItem + "" + off_Min.SelectedItem + "\'," +
                               "reservTemp =\'" + on_temp.SelectedItem + "\' where roomID = \'" + RoomList.Items[i].SubItems[0].Text + "\'";

                                execute_Query(sql);
                            }
                            else
                            {
                                MessageBox.Show("정확히 입력해주세요");
                            }

                            /* 지저분한 if문 코드 깔끔하게 할 수 있는 방법은...?ㅠ
                             * ...
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
            dbConn.Close();
        }

        public void showRoomList()
        {
            
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

                            execute_Query(sql);
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
            
        }

        public void execute_Query(String sql)
        {
            command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();
        }

        private void all_button_Click(object sender, EventArgs e)
        {
            if (RoomList.Items.Count > 0)
            {
                for (int i = 0; i <= RoomList.Items.Count - 1; i++)
                {
                    RoomList.Items[i].Checked = true;
                }
            }
        }
    }
}
