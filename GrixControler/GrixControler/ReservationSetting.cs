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

        bool MondayStartIsChecked = false;
        bool TuesdayStartIsChecked = false;
        bool WednesdayStartIsChecked = false;
        bool ThursdayStartIsChecked = false;
        bool FridayStartIsChecked = false;
        bool SaturdayStartIsChecked = false;
        bool SundayStartIsChecked = false;

        bool MondayEndIsChecked = false;
        bool TuesdayEndIsChecked = false;
        bool WednesdayEndIsChecked = false;
        bool ThursdayEndIsChecked = false;
        bool FridayEndIsChecked = false;
        bool SaturdayEndIsChecked = false;
         bool SundayEndIsChecked = false;

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
            StringBuilder checkRoomNum = new StringBuilder("");

            if (RoomList.Items.Count > 0)

            {

                for (int i = 0; i <= RoomList.Items.Count - 1; i++)

                {
                    ListViewItem item = RoomList.Items[i];

                    if (RoomList.Items[i].Checked == true)

                    {
                        checkRoomNum.Append(RoomList.Items[i].Text+ "호 ");
                        try
                        {
                            sql = "update idTable set MondayStartTime = \'"
                                + MondayStartTimePicker.Value.ToString("tthhmm") + "\', " +
                           "MondayEndTime = \'" + MondayEndTimePicker.Value.ToString("tthhmm") + "\', " +
                           "MondayTemp = \'" + MondayTempUpDown.Value.ToString() + "\', " +

                           "TuesdayStartTime = \'" + TuesdayStartTimePicker.Value.ToString("tthhmm") + "\', " +
                           "TuesdayEndTime = \'" + TuesdayEndTimePicker.Value.ToString("tthhmm") + "\', " +
                           "TuesdayTemp = \'" + TuesdayTempUpDown.Value.ToString() + "\', " +

                           "WednesdayStartTime = \'" + WednesdayStartTimePicker.Value.ToString("tthhmm") + "\', " +
                           "WednesdayEndTime = \'" + WednesdayEndTimePicker.Value.ToString("tthhmm") + "\', " +
                           "WednesdayTemp = \'" + WednesdayTempUpDown.Value.ToString() + "\', " +

                           "ThursdayStartTime = \'" + ThursdayStartTimePicker.Value.ToString("tthhmm") + "\', " +
                           "ThursdayEndTime = \'" + ThursdayEndTimePicker.Value.ToString("tthhmm") + "\', " +
                           "ThursdayTemp = \'" + ThursdayTempUpDown.Value.ToString() + "\', " +

                           "FridayStartTime = \'" + FridayStartTimePicker.Value.ToString("tthhmm") + "\', " +
                           "FridayEndTime = \'" + FridayEndTimePicker.Value.ToString("tthhmm") + "\', " +
                           "FridayTemp = \'" + FridayTempUpDown.Value.ToString() + "\', " +

                           "SaturdayStartTime = \'" + SaturdayStartTimePicker.Value.ToString("tthhmm") + "\', " +
                           "SaturdayEndTime = \'" + SaturdayEndTimePicker.Value.ToString("tthhmm") + "\', " +
                           "SaturdayTemp = \'" + SaturdayTempUpDown.Value.ToString() + "\', " +

                           "SundayStartTime = \'" + SundayStartTimePicker.Value.ToString("tthhmm") + "\', " +
                           "SundayEndTime = \'" + SundayEndTimePicker.Value.ToString("tthhmm") + "\', " +
                           "SundayTemp = \'" + SundayTempUpDown.Value.ToString() + "\', " +
                           
                           "ReservationStartDay = \'" + FindReservationStartDayFromForm() + "\', " +
                           "ReservationEndDay = \'" + FindReservationEndDayFromForm() + "\' " +

                           "where roomID = \'" + RoomList.Items[i].SubItems[0].Text + "\'";

                            command = new SQLiteCommand(sql, dbConn);
                            command.ExecuteNonQuery();

                        }
                        catch (Exception easda)
                        {
                            MessageBox.Show(easda.ToString());
                        }
                        

                    }

                }

            }

            show_RoomList();

            MessageBox.Show(checkRoomNum + "예약적용 완료");
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
                            sql = "update idTable set MondayStartTime = \'오전0800\', " +
                              "MondayEndTime = \'오전0800\', " +
                              "MondayTemp = \'25\', " +

                              "TuesdayStartTime = \'오전0800\', " +
                              "TuesdayEndTime = \'오전0800\', " +
                              "TuesdayTemp = \'25\', " +

                              "WednesdayStartTime = \'오전0800\', " +
                              "WednesdayEndTime = \'오전0800\', " +
                              "WednesdayTemp = \'25\', " +

                              "ThursdayStartTime = \'오전0800\', " +
                              "ThursdayEndTime = \'오전0800\', " +
                              "ThursdayTemp = \'25\', " +

                              "FridayStartTime = \'오전0800\', " +
                              "FridayEndTime = \'오전0800\', " +
                              "FridayTemp = \'25\', " +

                              "SaturdayStartTime = \'오전0800\', " +
                              "SaturdayEndTime = \'오전0800\', " +
                              "SaturdayTemp = \'25\', " +

                              "SundayStartTime = \'오전0800\', " +
                              "SundayEndTime = \'오전0800\', " +
                              "SundayTemp = \'25\', " +

                              "ReservationStartDay = \'-\', " +
                              "ReservationEndDay = \'-\' " +

                              "where roomID = \'" + RoomList.Items[i].SubItems[0].Text + "\'";
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
            Show_RoomReservationInfo();
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
                String[] reservation_arr = { rdr["roomID"].ToString()
                };
                var listViewItem = new ListViewItem(reservation_arr);
                RoomList.Items.Add(listViewItem);
            }
            rdr.Close();
        }

        private void ReservationSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            dbConn.Close();
            main.ThreadResume();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {


            if (RoomList.Items.Count > 0)

            {

                for (int i = 0; i <= RoomList.Items.Count - 1; i++)

                {
                    if (RoomList.Items[i].Checked == true)

                    {
                        ListViewItem item = RoomList.Items[i];

                        try
                        {
                            sql = "update idTable set MondayStartTime = \'오전0800\', " +
                              "MondayEndTime = \'오전0800\', " +
                              "MondayTemp = \'25\', " +

                              "TuesdayStartTime = \'오전0800\', " +
                              "TuesdayEndTime = \'오전0800\', " +
                              "TuesdayTemp = \'25\', " +

                              "WednesdayStartTime = \'오전0800\', " +
                              "WednesdayEndTime = \'오전0800\', " +
                              "WednesdayTemp = \'25\', " +

                              "ThursdayStartTime = \'오전0800\', " +
                              "ThursdayEndTime = \'오전0800\', " +
                              "ThursdayTemp = \'25\', " +

                              "FridayStartTime = \'오전0800\', " +
                              "FridayEndTime = \'오전0800\', " +
                              "FridayTemp = \'25\', " +

                              "SaturdayStartTime = \'오전0800\', " +
                              "SaturdayEndTime = \'오전0800\', " +
                              "SaturdayTemp = \'25\', " +

                              "SundayStartTime = \'오전0800\', " +
                              "SundayEndTime = \'오전0800\', " +
                              "SundayTemp = \'25\', " +

                              "ReservationStartDay = \'-\', " +
                              "ReservationEndDay = \'-\' " +


                              "where roomID = \'" + RoomList.Items[i].SubItems[0].Text + "\'";

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

            }
            Show_RoomReservationInfo();
            show_RoomList();
        }


        private void MondayRadBtn_Click(object sender, EventArgs e)
        {

            TuesdayStartIsChecked = false;
            WednesdayStartIsChecked = false;
            ThursdayStartIsChecked = false;
            FridayStartIsChecked = false;
            SaturdayStartIsChecked = false;
            SundayStartIsChecked = false;

            if (MondayStartIsChecked)
            {
                MondayStartRadBtn.Checked = false;
                MondayStartIsChecked = false;

            }
            else
            {
                MondayStartIsChecked = MondayStartRadBtn.Checked;
            }
        }

        private void TuesdayRadBtn_Click(object sender, EventArgs e)
        {

            MondayStartIsChecked = false;
            WednesdayStartIsChecked = false;
            ThursdayStartIsChecked = false;
            FridayStartIsChecked = false;
            SaturdayStartIsChecked = false;
            SundayStartIsChecked = false;

            if (TuesdayStartIsChecked)
            {
                TuesdayStartRadBtn.Checked = false;
                TuesdayStartIsChecked = false;

            }
            else
            {
                TuesdayStartIsChecked = TuesdayStartRadBtn.Checked;
            }
        }

        private void WednesdayRadBtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WednesdayRadBtn_Click(object sender, EventArgs e)
        {
            MondayStartIsChecked = false;
            TuesdayStartIsChecked = false;
            ThursdayStartIsChecked = false;
            FridayStartIsChecked = false;
            SaturdayStartIsChecked = false;
            SundayStartIsChecked = false;

            if (WednesdayStartIsChecked)
            {
                WednesdayStartRadBtn.Checked = false;
                WednesdayStartIsChecked = false;

            }
            else
            {
                WednesdayStartIsChecked = WednesdayStartRadBtn.Checked;
            }
        }

        private void ThursdayRadBtn_Click(object sender, EventArgs e)
        {
            MondayStartIsChecked = false;
            TuesdayStartIsChecked = false;
            WednesdayStartIsChecked = false;
            FridayStartIsChecked = false;
            SaturdayStartIsChecked = false;
            SundayStartIsChecked = false;

            if (ThursdayStartIsChecked)
            {
                ThursdayStartRadBtn.Checked = false;
                ThursdayStartIsChecked = false;

            }
            else
            {
                ThursdayStartIsChecked = ThursdayStartRadBtn.Checked;
            }
        }

        private void FridayRadBtn_Click(object sender, EventArgs e)
        {
            MondayStartIsChecked = false;
            TuesdayStartIsChecked = false;
            WednesdayStartIsChecked = false;
            ThursdayStartIsChecked = false;
            SaturdayStartIsChecked = false;
            SundayStartIsChecked = false;

            if (FridayStartIsChecked)
            {
                FridayStartRadBtn.Checked = false;
                FridayStartIsChecked = false;

            }
            else
            {
                FridayStartIsChecked = FridayStartRadBtn.Checked;
            }
        }

        private void SaturdayRadBtn_Click(object sender, EventArgs e)
        {
            MondayStartIsChecked = false;
            TuesdayStartIsChecked = false;
            WednesdayStartIsChecked = false;
            ThursdayStartIsChecked = false;
            FridayStartIsChecked = false;
            SundayStartIsChecked = false;

            if (SaturdayStartIsChecked)
            {
                SaturdayStartRadBtn.Checked = false;
                SaturdayStartIsChecked = false;

            }
            else
            {
                SaturdayStartIsChecked = SaturdayStartRadBtn.Checked;
            }
        }

        private void SundayRadBtn_Click(object sender, EventArgs e)
        {
            MondayStartIsChecked = false;
            TuesdayStartIsChecked = false;
            WednesdayStartIsChecked = false;
            ThursdayStartIsChecked = false;
            FridayStartIsChecked = false;
            SaturdayStartIsChecked = false;

            if (SundayStartIsChecked)
            {
                SundayStartRadBtn.Checked = false;
                SundayStartIsChecked = false;

            }
            else
            {
                SundayStartIsChecked = SundayStartRadBtn.Checked;
            }
        }

        private void MondayEndRadBtn_Click(object sender, EventArgs e)
        {
            TuesdayEndIsChecked = false;
            WednesdayEndIsChecked = false;
            ThursdayEndIsChecked = false;
            FridayEndIsChecked = false;
            SaturdayEndIsChecked = false;
            SundayEndIsChecked = false;

            if (MondayEndIsChecked)
            {
                MondayEndRadBtn.Checked = false;
                MondayEndIsChecked = false;

            }
            else
            {
                MondayEndIsChecked = MondayEndRadBtn.Checked;
            }
        }

        private void TuesdayEndRadBtn_Click(object sender, EventArgs e)
        {
            MondayEndIsChecked = false;
            WednesdayEndIsChecked = false;
            ThursdayEndIsChecked = false;
            FridayEndIsChecked = false;
            SaturdayEndIsChecked = false;
            SundayEndIsChecked = false;

            if (TuesdayEndIsChecked)
            {
                TuesdayEndRadBtn.Checked = false;
                TuesdayEndIsChecked = false;

            }
            else
            {
                TuesdayEndIsChecked = TuesdayEndRadBtn.Checked;
            }
        }

        private void WednesdayEndRadBtn_Click(object sender, EventArgs e)
        {
            MondayEndIsChecked = false;
            TuesdayEndIsChecked = false;
            ThursdayEndIsChecked = false;
            FridayEndIsChecked = false;
            SaturdayEndIsChecked = false;
            SundayEndIsChecked = false;

            if (WednesdayEndIsChecked)
            {
                WednesdayEndRadBtn.Checked = false;
                WednesdayEndIsChecked = false;

            }
            else
            {
                WednesdayEndIsChecked = WednesdayEndRadBtn.Checked;
            }
        }

        private void ThursdayEndRadBtn_Click(object sender, EventArgs e)
        {
            MondayEndIsChecked = false;
            TuesdayEndIsChecked = false;
            WednesdayEndIsChecked = false;
            FridayEndIsChecked = false;
            SaturdayEndIsChecked = false;
            SundayEndIsChecked = false;

            if (ThursdayEndIsChecked)
            {
                ThursdayEndRadBtn.Checked = false;
                ThursdayEndIsChecked = false;

            }
            else
            {
                ThursdayEndIsChecked = ThursdayEndRadBtn.Checked;
            }
        }

        private void FridayEndRadBtn_Click(object sender, EventArgs e)
        {
            MondayEndIsChecked = false;
            TuesdayEndIsChecked = false;
            WednesdayEndIsChecked = false;
            ThursdayEndIsChecked = false;
            SaturdayEndIsChecked = false;
            SundayEndIsChecked = false;

            if (FridayEndIsChecked)
            {
                FridayEndRadBtn.Checked = false;
                FridayEndIsChecked = false;

            }
            else
            {
                FridayEndIsChecked = FridayEndRadBtn.Checked;
            }
        }

        private void SaturdayEndRadBtn_Click(object sender, EventArgs e)
        {
            MondayEndIsChecked = false;
            TuesdayEndIsChecked = false;
            WednesdayEndIsChecked = false;
            ThursdayEndIsChecked = false;
            FridayEndIsChecked = false;
            SundayEndIsChecked = false;

            if (SaturdayEndIsChecked)
            {
                SaturdayEndRadBtn.Checked = false;
                SaturdayEndIsChecked = false;

            }
            else
            {
                SaturdayEndIsChecked = SaturdayEndRadBtn.Checked;
            }
        }

        private void SundayEndRadBtn_Click(object sender, EventArgs e)
        {
            MondayEndIsChecked = false;
            TuesdayEndIsChecked = false;
            WednesdayEndIsChecked = false;
            ThursdayEndIsChecked = false;
            FridayEndIsChecked = false;
            SaturdayEndIsChecked = false;

            if (SundayEndIsChecked)
            {
                SundayEndRadBtn.Checked = false;
                SundayEndIsChecked = false;

            }
            else
            {
                SundayEndIsChecked = SundayEndRadBtn.Checked;
            }
        }

        private void SundayStartTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void WednesdayEndTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
        

        private String FindReservationStartDayFromForm()
        {
            if (MondayStartRadBtn.Checked)
            {
                return "월요일";
            }
            else if (TuesdayStartRadBtn.Checked)
            {
                return "화요일";
            }
            else if (WednesdayStartRadBtn.Checked)
            {
                return "수요일";
            }
            else if (ThursdayStartRadBtn.Checked)
            {
                return "목요일";
            }
            else if (FridayStartRadBtn.Checked)
            {
                return "금요일";
            }
            else if (SaturdayStartRadBtn.Checked)
            {
                return "토요일";
            }
            else if (SundayStartRadBtn.Checked)
            {
                return "일요일";
            }
            else
            {
                return "-";
            }
        }

        private String FindReservationEndDayFromForm()
        {
            if (MondayEndRadBtn.Checked)
            {
                return "월요일";
            }
            else if (TuesdayEndRadBtn.Checked)
            {
                return "화요일";
            }
            else if (WednesdayEndRadBtn.Checked)
            {
                return "수요일";
            }
            else if (ThursdayEndRadBtn.Checked)
            {
                return "목요일";
            }
            else if (FridayEndRadBtn.Checked)
            {
                return "금요일";
            }
            else if (SaturdayEndRadBtn.Checked)
            {
                return "토요일";
            }
            else if (SundayEndRadBtn.Checked)
            {
                return "일요일";
            }
            else
            {
                return "-";
            }
        }

        private void AllStartRadioButtonUnCheck()
        {
            MondayStartRadBtn.Checked = false;
            TuesdayStartRadBtn.Checked = false;
            WednesdayStartRadBtn.Checked = false;
            ThursdayStartRadBtn.Checked = false;
            FridayStartRadBtn.Checked = false;
            SaturdayStartRadBtn.Checked = false;
            SundayStartRadBtn.Checked = false;
        }

        private void AllEndRadioButtonUnCheck()
        {
            MondayEndRadBtn.Checked = false;
            TuesdayEndRadBtn.Checked = false;
            WednesdayEndRadBtn.Checked = false;
            ThursdayEndRadBtn.Checked = false;
            FridayEndRadBtn.Checked = false;
            SaturdayEndRadBtn.Checked = false;
            SundayEndRadBtn.Checked = false;
        }

        private void FindReservationStartDayFromDB(String day)
        {
            if (day == "월요일")
            {
                MondayStartRadBtn.Checked = true;
            }
            else if (day == "화요일")
            {
                TuesdayStartRadBtn.Checked = true;
            }
            else if (day == "수요일")
            {
                WednesdayStartRadBtn.Checked = true;
            }
            else if (day == "목요일")
            {
                ThursdayStartRadBtn.Checked = true;
            }
            else if (day == "금요일")
            {
                FridayStartRadBtn.Checked = true;
            }
            else if (day == "토요일")
            {
                SaturdayStartRadBtn.Checked = true;
            }
            else if (day == "일요일")
            {
                SundayStartRadBtn.Checked = true;
            }
            else {
                AllStartRadioButtonUnCheck();
            }
        }

        private void FindReservationEndDayFromDB(String day)
        {
            if (day == "월요일")
            {
                MondayEndRadBtn.Checked = true;
            }
            else if (day == "화요일")
            {
                TuesdayEndRadBtn.Checked = true;
            }
            else if (day == "수요일")
            {
                WednesdayEndRadBtn.Checked = true;
            }
            else if (day == "목요일")
            {
                ThursdayEndRadBtn.Checked = true;
            }
            else if (day == "금요일")
            {
                FridayEndRadBtn.Checked = true;
            }
            else if (day == "토요일")
            {
                SaturdayEndRadBtn.Checked = true;
            }
            else if (day == "일요일")
            {
                SundayEndRadBtn.Checked = true;
            }
            else {
                AllEndRadioButtonUnCheck();
            }
        }

        private void Show_RoomReservationInfo()
        {
            if (RoomList.Items.Count > 0)
            {
                for (int i = 0; i <= RoomList.Items.Count - 1; i++)

                {
                    ListViewItem item = RoomList.Items[i];

                    if (RoomList.Items[i].Focused == true)

                    {
                        try
                        {
                            String startDay;
                            String endDay;

                            sql = "select * from idTable where roomID = \'" + RoomList.Items[i].SubItems[0].Text + "\'";

                            command = new SQLiteCommand(sql, dbConn);
                            rdr = command.ExecuteReader();

                            while (rdr.Read())
                            {
                                MondayStartTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(rdr["MondayStartTime"].ToString().Substring(2, 2)),
                                    Convert.ToInt32(rdr["MondayStartTime"].ToString().Substring(4, 2)), 0);
                                MondayTempUpDown.Value = Convert.ToInt32(rdr["MondayTemp"].ToString());

                                TuesdayStartTimePicker.Value = new DateTime(2000, 1, 1,
                                   Convert.ToInt32(rdr["TuesdayStartTime"].ToString().Substring(2, 2)),
                                   Convert.ToInt32(rdr["TuesdayEndTime"].ToString().Substring(4, 2)), 0);
                                TuesdayTempUpDown.Value = Convert.ToInt32(rdr["TuesdayTemp"].ToString());

                                WednesdayStartTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(rdr["WednesdayStartTime"].ToString().Substring(2, 2)),
                                    Convert.ToInt32(rdr["WednesdayEndTime"].ToString().Substring(4, 2)), 0);
                                WednesdayTempUpDown.Value = Convert.ToInt32(rdr["WednesdayTemp"].ToString());

                                ThursdayStartTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(rdr["ThursdayStartTime"].ToString().Substring(2, 2)),
                                    Convert.ToInt32(rdr["ThursdayEndTime"].ToString().Substring(4, 2)), 0);
                                ThursdayTempUpDown.Value = Convert.ToInt32(rdr["ThursdayTemp"].ToString());

                                FridayStartTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(rdr["FridayStartTime"].ToString().Substring(2, 2)),
                                    Convert.ToInt32(rdr["FridayEndTime"].ToString().Substring(4, 2)), 0);
                                FridayTempUpDown.Value = Convert.ToInt32(rdr["FridayTemp"].ToString());
                                
                                SaturdayStartTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(rdr["SaturdayStartTime"].ToString().Substring(2, 2)),
                                    Convert.ToInt32(rdr["SaturdayEndTime"].ToString().Substring(4, 2)), 0);
                                SaturdayTempUpDown.Value = Convert.ToInt32(rdr["SaturdayTemp"].ToString());

                                SundayStartTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(rdr["SundayStartTime"].ToString().Substring(2, 2)),
                                    Convert.ToInt32(rdr["SundayEndTime"].ToString().Substring(4, 2)), 0);
                                SundayTempUpDown.Value = Convert.ToInt32(rdr["SundayTemp"].ToString());

                                startDay = rdr["ReservationStartDay"].ToString();
                                endDay = rdr["ReservationEndDay"].ToString();

                                FindReservationStartDayFromDB(startDay);
                                FindReservationEndDayFromDB(endDay);

                            }
                            rdr.Close();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.ToString());
                        }
                    }

                }

            }
        }


        private void RoomList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Show_RoomReservationInfo();
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }
        /*
private void RadButtonCanOnOFF(RadioButton rad, bool radCheck)
{
if (radCheck)
{
rad.Checked = false;
radCheck = false;
}
else
{
radCheck = rad.Checked;
}
} 
*/// 이걸 사용할 수 있는 방법은 무엇이있을까 radCheck가 SundayDendlsChecked에 매핑되진 않는다. C 처럼포인터값을 가져올까?
    }
}
