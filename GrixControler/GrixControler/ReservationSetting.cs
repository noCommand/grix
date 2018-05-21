using System;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;

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

        int listviewCheckboxCount = 0;

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

            RoomList.Columns.Add("", 50);

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
                        checkRoomNum.Append(RoomList.Items[i].Text + "호 ");
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

            MessageBox.Show(checkRoomNum + "\n예약적용 완료");
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
                              "MondayEndTime = \'오후0800\', " +
                              "MondayTemp = \'25\', " +

                              "TuesdayStartTime = \'오전0800\', " +
                              "TuesdayEndTime = \'오후0800\', " +
                              "TuesdayTemp = \'25\', " +

                              "WednesdayStartTime = \'오전0800\', " +
                              "WednesdayEndTime = \'오후0800\', " +
                              "WednesdayTemp = \'25\', " +

                              "ThursdayStartTime = \'오전0800\', " +
                              "ThursdayEndTime = \'오후0800\', " +
                              "ThursdayTemp = \'25\', " +

                              "FridayStartTime = \'오전0800\', " +
                              "FridayEndTime = \'오후0800\', " +
                              "FridayTemp = \'25\', " +

                              "SaturdayStartTime = \'오전0800\', " +
                              "SaturdayEndTime = \'오후0800\', " +
                              "SaturdayTemp = \'25\', " +

                              "SundayStartTime = \'오전0800\', " +
                              "SundayEndTime = \'오후0800\', " +
                              "SundayTemp = \'25\', " +

                              "ReservationStartDay = \"\", " +
                              "ReservationEndDay = \"\" " +

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
                              "TuesdayEndTime = \'오후0800\', " +
                              "TuesdayTemp = \'25\', " +

                              "WednesdayStartTime = \'오전0800\', " +
                              "WednesdayEndTime = \'오후0800\', " +
                              "WednesdayTemp = \'25\', " +

                              "ThursdayStartTime = \'오전0800\', " +
                              "ThursdayEndTime = \'오후0800\', " +
                              "ThursdayTemp = \'25\', " +

                              "FridayStartTime = \'오전0800\', " +
                              "FridayEndTime = \'오후0800\', " +
                              "FridayTemp = \'25\', " +

                              "SaturdayStartTime = \'오전0800\', " +
                              "SaturdayEndTime = \'오후0800\', " +
                              "SaturdayTemp = \'25\', " +

                              "SundayStartTime = \'오전0800\', " +
                              "SundayEndTime = \'오후0800\', " +
                              "SundayTemp = \'25\', " +

                              "ReservationStartDay = \"\", " +
                              "ReservationEndDay = \"\" " +


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



        private String FindReservationStartDayFromForm()
        {
            StringBuilder appendDay = new StringBuilder("");

            if (MondayStartCheckbox.Checked)
            {
                appendDay.Append("월");
            }
            if (TuesdayStartCheckbox.Checked)
            {
                appendDay.Append("화");
            }
            if (WednesdayStartCheckbox.Checked)
            {
                appendDay.Append("수");
            }
            if (ThursdayStartCheckbox.Checked)
            {
                appendDay.Append("목");
            }
            if (FridayStartCheckbox.Checked)
            {
                appendDay.Append("금");
            }
            if (SaturdayStartCheckbox.Checked)
            {
                appendDay.Append("토");
            }
            if (SundayStartCheckbox.Checked)
            {
                appendDay.Append("일");
            }
            if (!MondayStartCheckbox.Checked &&
                !TuesdayStartCheckbox.Checked && !WednesdayStartCheckbox.Checked &&
                !ThursdayStartCheckbox.Checked && !FridayStartCheckbox.Checked &&
                    !SaturdayStartCheckbox.Checked && !SundayStartCheckbox.Checked)
            {
                appendDay.Append("");
            }
            return appendDay.ToString();

        }

        private String FindReservationEndDayFromForm()
        {
            StringBuilder appendDay = new StringBuilder("");

            if (MondayEndCheckbox.Checked)
            {
                appendDay.Append("월");
            }
            if (TuesdayEndCheckbox.Checked)
            {
                appendDay.Append("화");
            }
            if (WednesdayEndCheckbox.Checked)
            {
                appendDay.Append("수");
            }
            if (ThursdayEndCheckbox.Checked)
            {
                appendDay.Append("목");
            }
            if (FridayEndCheckbox.Checked)
            {
                appendDay.Append("금");
            }
            if (SaturdayEndCheckbox.Checked)
            {
                appendDay.Append("토");
            }
            if (SundayEndCheckbox.Checked)
            {
                appendDay.Append("일");
            }
            if (!MondayStartCheckbox.Checked &&
                !TuesdayStartCheckbox.Checked && !WednesdayStartCheckbox.Checked &&
                !ThursdayStartCheckbox.Checked && !FridayStartCheckbox.Checked &&
                    !SaturdayStartCheckbox.Checked && !SundayStartCheckbox.Checked)
            {
                appendDay.Append("");
            }

            return appendDay.ToString();
        }

        private void AllStartCheckboxUnCheck()
        {
            MondayStartCheckbox.Checked = false;
            TuesdayStartCheckbox.Checked = false;
            WednesdayStartCheckbox.Checked = false;
            ThursdayStartCheckbox.Checked = false;
            FridayStartCheckbox.Checked = false;
            SaturdayStartCheckbox.Checked = false;
            SundayStartCheckbox.Checked = false;
        }

        private void AllEndCheckboxUnCheck()
        {
            MondayEndCheckbox.Checked = false;
            TuesdayEndCheckbox.Checked = false;
            WednesdayEndCheckbox.Checked = false;
            ThursdayEndCheckbox.Checked = false;
            FridayEndCheckbox.Checked = false;
            SaturdayEndCheckbox.Checked = false;
            SundayEndCheckbox.Checked = false;
        }

        private void FindReservationStartDayFromDB(String day)
        {
            if (day == "월")
            {
                MondayStartCheckbox.Checked = true;
            }
            if (day == "화")
            {
                TuesdayStartCheckbox.Checked = true;
            }
            if (day == "수")
            {
                WednesdayStartCheckbox.Checked = true;
            }
            if (day == "목")
            {
                ThursdayStartCheckbox.Checked = true;
            }
            if (day == "금")
            {
                FridayStartCheckbox.Checked = true;
            }
            if (day == "토")
            {
                SaturdayStartCheckbox.Checked = true;
            }
            if (day == "일")
            {
                SundayStartCheckbox.Checked = true;
            }
        }

        private void FindReservationEndDayFromDB(String day)
        {
            if (day == "월")
            {
                MondayEndCheckbox.Checked = true;
            }
            if (day == "화")
            {
                TuesdayEndCheckbox.Checked = true;
            }
            if (day == "수")
            {
                WednesdayEndCheckbox.Checked = true;
            }
            if (day == "목")
            {
                ThursdayEndCheckbox.Checked = true;
            }
            if (day == "금")
            {
                FridayEndCheckbox.Checked = true;
            }
            if (day == "토")
            {
                SaturdayEndCheckbox.Checked = true;
            }
            if (day == "일")
            {
                SundayEndCheckbox.Checked = true;
            }
        }

        private int SetMorningEveningToInt(String time)
        {
            if (time == "오전")
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private void SetTimeIfHourOverflow(DateTimePicker dateTimePicker)
        {
            dateTimePicker.Value = new DateTime(2000, 1, 1, 12, 00, 0);
        }

        private void Show_RoomReservationInfo()
        {
            AllStartCheckboxUnCheck();
            AllEndCheckboxUnCheck();
            if (RoomList.Items.Count > 0)
            {
                for (int i = 0; i <= RoomList.Items.Count - 1; i++)

                {
                    ListViewItem item = RoomList.Items[i];

                    if (RoomList.Items[i].Focused == true)

                    {
                        try
                        {
                            String[] startDay;
                            String[] endDay;
                            int count;
                            sql = "select * from idTable where roomID = \'" + RoomList.Items[i].SubItems[0].Text + "\'";

                            command = new SQLiteCommand(sql, dbConn);
                            rdr = command.ExecuteReader();

                            while (rdr.Read())
                            {
                                String mondayOnStr = rdr["MondayStartTime"].ToString();
                                String tuesdayOnStr = rdr["TuesdayStartTime"].ToString();
                                String wednesdayOnStr = rdr["WednesdayStartTime"].ToString();
                                String thursdayOnStr = rdr["ThursdayStartTime"].ToString();
                                String fridayOnStr = rdr["FridayStartTime"].ToString();
                                String saturdayOnStr = rdr["SaturdayStartTime"].ToString();
                                String sundayOnStr = rdr["SundayStartTime"].ToString();

                                String mondayOffStr = rdr["MondayEndTime"].ToString();
                                String tuesdayOffStr = rdr["TuesdayEndTime"].ToString();
                                String wednesdayOffStr = rdr["WednesdayEndTime"].ToString();
                                String thursdayOffStr = rdr["ThursdayEndTime"].ToString();
                                String fridayOffStr = rdr["FridayEndTime"].ToString();
                                String saturdayOffStr = rdr["SaturdayEndTime"].ToString();
                                String sundayOffStr = rdr["SundayEndTime"].ToString();

                                if (Convert.ToInt32(mondayOnStr.Substring(2, 2)) + SetMorningEveningToInt(mondayOnStr.Substring(0, 2)) * 12 == 24)
                                {
                                    SetTimeIfHourOverflow(MondayStartTimePicker);
                                }
                                else
                                {
                                    MondayStartTimePicker.Value = new DateTime(2000, 1, 1,
                                       Convert.ToInt32(mondayOnStr.Substring(2, 2)) + SetMorningEveningToInt(mondayOnStr.Substring(0, 2)) * 12,
                                       Convert.ToInt32(mondayOnStr.Substring(4, 2)), 0);
                                }
                                MondayTempUpDown.Value = Convert.ToInt32(rdr["MondayTemp"].ToString());

                                if (Convert.ToInt32(tuesdayOnStr.Substring(2, 2)) + SetMorningEveningToInt(tuesdayOnStr.Substring(0, 2)) * 12 == 24)
                                {
                                    SetTimeIfHourOverflow(TuesdayStartTimePicker);
                                }
                                else
                                {
                                    TuesdayStartTimePicker.Value = new DateTime(2000, 1, 1,
                                   Convert.ToInt32(tuesdayOnStr.Substring(2, 2)) + SetMorningEveningToInt(tuesdayOnStr.Substring(0, 2)) * 12,
                                   Convert.ToInt32(tuesdayOnStr.Substring(4, 2)), 0);
                                }

                                TuesdayTempUpDown.Value = Convert.ToInt32(rdr["TuesdayTemp"].ToString());
                                if (Convert.ToInt32(wednesdayOnStr.Substring(2, 2)) + SetMorningEveningToInt(wednesdayOnStr.Substring(0, 2)) * 12 == 24)
                                {
                                    SetTimeIfHourOverflow(WednesdayStartTimePicker);
                                }
                                else
                                {
                                    WednesdayStartTimePicker.Value = new DateTime(2000, 1, 1,
                                        Convert.ToInt32(wednesdayOnStr.Substring(2, 2)) + SetMorningEveningToInt(wednesdayOnStr.Substring(0, 2)) * 12,
                                        Convert.ToInt32(wednesdayOnStr.Substring(4, 2)), 0);
                                }
                                WednesdayTempUpDown.Value = Convert.ToInt32(rdr["WednesdayTemp"].ToString());

                                if (Convert.ToInt32(thursdayOnStr.Substring(2, 2)) + SetMorningEveningToInt(thursdayOnStr.Substring(0, 2)) * 12 == 24)
                                {
                                    SetTimeIfHourOverflow(ThursdayStartTimePicker);
                                }
                                else
                                {
                                    ThursdayStartTimePicker.Value = new DateTime(2000, 1, 1,
                                        Convert.ToInt32(thursdayOnStr.Substring(2, 2)) + SetMorningEveningToInt(thursdayOnStr.Substring(0, 2)) * 12,
                                        Convert.ToInt32(thursdayOnStr.Substring(4, 2)), 0);
                                }
                                ThursdayTempUpDown.Value = Convert.ToInt32(rdr["ThursdayTemp"].ToString());

                                if (Convert.ToInt32(fridayOnStr.Substring(2, 2)) + SetMorningEveningToInt(fridayOnStr.Substring(0, 2)) * 12 == 24)
                                {
                                    SetTimeIfHourOverflow(FridayStartTimePicker);
                                }
                                else
                                {
                                    FridayStartTimePicker.Value = new DateTime(2000, 1, 1,
                                        Convert.ToInt32(fridayOnStr.Substring(2, 2)) + SetMorningEveningToInt(fridayOnStr.Substring(0, 2)) * 12,
                                        Convert.ToInt32(fridayOnStr.Substring(4, 2)), 0);
                                }
                                FridayTempUpDown.Value = Convert.ToInt32(rdr["FridayTemp"].ToString());

                                if (Convert.ToInt32(saturdayOnStr.Substring(2, 2)) + SetMorningEveningToInt(saturdayOnStr.Substring(0, 2)) * 12 == 24)
                                {
                                    SetTimeIfHourOverflow(SaturdayStartTimePicker);
                                }
                                else
                                {
                                    SaturdayStartTimePicker.Value = new DateTime(2000, 1, 1,
                                        Convert.ToInt32(saturdayOnStr.Substring(2, 2)) + SetMorningEveningToInt(saturdayOnStr.Substring(0, 2)) * 12,
                                        Convert.ToInt32(saturdayOnStr.Substring(4, 2)), 0);

                                }
                                SaturdayTempUpDown.Value = Convert.ToInt32(rdr["SaturdayTemp"].ToString());

                                if (Convert.ToInt32(sundayOnStr.Substring(2, 2)) + SetMorningEveningToInt(sundayOnStr.Substring(0, 2)) * 12 == 24)
                                {
                                    SetTimeIfHourOverflow(SundayStartTimePicker);
                                }
                                else
                                {
                                    SundayStartTimePicker.Value = new DateTime(2000, 1, 1,
                                   Convert.ToInt32(sundayOnStr.Substring(2, 2)) + SetMorningEveningToInt(sundayOnStr.Substring(0, 2)) * 12,
                                   Convert.ToInt32(sundayOnStr.Substring(4, 2)), 0);
                                }

                                SundayTempUpDown.Value = Convert.ToInt32(rdr["SundayTemp"].ToString());

                                if (Convert.ToInt32(mondayOffStr.Substring(2, 2)) + SetMorningEveningToInt(mondayOffStr.Substring(0, 2)) * 12 == 24)
                                {
                                    SetTimeIfHourOverflow(MondayEndTimePicker);
                                }
                                else
                                {
                                    MondayEndTimePicker.Value = new DateTime(2000, 1, 1,
                                   Convert.ToInt32(mondayOffStr.Substring(2, 2)) + SetMorningEveningToInt(mondayOffStr.Substring(0, 2)) * 12,
                                   Convert.ToInt32(mondayOffStr.Substring(4, 2)), 0);
                                }


                                if (Convert.ToInt32(tuesdayOffStr.Substring(2, 2)) + SetMorningEveningToInt(tuesdayOffStr.Substring(0, 2)) * 12 == 24)
                                {
                                    SetTimeIfHourOverflow(TuesdayEndTimePicker);
                                }
                                else
                                {
                                    TuesdayEndTimePicker.Value = new DateTime(2000, 1, 1,
                                   Convert.ToInt32(tuesdayOffStr.Substring(2, 2)) + SetMorningEveningToInt(tuesdayOffStr.Substring(0, 2)) * 12,
                                   Convert.ToInt32(tuesdayOffStr.Substring(4, 2)), 0);
                                }

                                if (Convert.ToInt32(wednesdayOffStr.Substring(2, 2)) + SetMorningEveningToInt(wednesdayOffStr.Substring(0, 2)) * 12 == 24)
                                {
                                    SetTimeIfHourOverflow(WednesdayEndTimePicker);
                                }
                                else
                                {
                                    WednesdayEndTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(wednesdayOffStr.Substring(2, 2)) + SetMorningEveningToInt(wednesdayOffStr.Substring(0, 2)) * 12,
                                    Convert.ToInt32(wednesdayOffStr.Substring(4, 2)), 0);
                                }

                                if (Convert.ToInt32(thursdayOffStr.Substring(2, 2)) + SetMorningEveningToInt(thursdayOffStr.Substring(0, 2)) * 12 == 24)
                                {
                                    SetTimeIfHourOverflow(ThursdayEndTimePicker);
                                }
                                else
                                {
                                    ThursdayEndTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(thursdayOffStr.Substring(2, 2)) + SetMorningEveningToInt(thursdayOffStr.Substring(0, 2)) * 12,
                                    Convert.ToInt32(thursdayOffStr.Substring(4, 2)), 0);
                                }

                                if (Convert.ToInt32(fridayOffStr.Substring(2, 2)) + SetMorningEveningToInt(fridayOffStr.Substring(0, 2)) * 12 == 24)
                                {
                                    SetTimeIfHourOverflow(FridayEndTimePicker);
                                }
                                else
                                {
                                    FridayEndTimePicker.Value = new DateTime(2000, 1, 1,
                                   Convert.ToInt32(fridayOffStr.Substring(2, 2)) + SetMorningEveningToInt(fridayOffStr.Substring(0, 2)) * 12,
                                   Convert.ToInt32(fridayOffStr.Substring(4, 2)), 0);
                                }

                                if (Convert.ToInt32(saturdayOffStr.Substring(2, 2)) + SetMorningEveningToInt(saturdayOffStr.Substring(0, 2)) * 12 == 24)
                                {
                                    SetTimeIfHourOverflow(SaturdayEndTimePicker);
                                }
                                else
                                {
                                    SaturdayEndTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(saturdayOffStr.Substring(2, 2)) + SetMorningEveningToInt(saturdayOffStr.Substring(0, 2)) * 12,
                                    Convert.ToInt32(saturdayOffStr.Substring(4, 2)), 0);
                                }

                                if (Convert.ToInt32(sundayOffStr.Substring(2, 2)) + SetMorningEveningToInt(sundayOffStr.Substring(0, 2)) * 12 == 24)
                                {
                                    SetTimeIfHourOverflow(SundayEndTimePicker);
                                }
                                else
                                {
                                    SundayEndTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(sundayOffStr.Substring(2, 2)) + SetMorningEveningToInt(sundayOffStr.Substring(0, 2)) * 12,
                                    Convert.ToInt32(sundayOffStr.Substring(4, 2)), 0);
                                }


                                startDay = SeperateDay(rdr["ReservationStartDay"].ToString());
                                endDay = SeperateDay(rdr["ReservationEndDay"].ToString());

                                for (count = 0; count < startDay.Length; count++)
                                {
                                    FindReservationStartDayFromDB(startDay[count]);
                                }
                                for (count = 0; count < endDay.Length; count++)
                                {
                                    FindReservationEndDayFromDB(endDay[count]);
                                }

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

        private String[] SeperateDay(String str)
        {
            String[] strArray = new String[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                strArray[i] = str.Substring(i, 1);
            }
            return strArray;
        }


        private void RoomList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            SetListViewConnectCheckBoxFocused();
            Show_RoomReservationInfo();

        }

        private void SetListViewConnectCheckBoxFocused()
        {
            if (RoomList.SelectedItems.Count > 0)
            {
                if (RoomList.Items.Count > 0)
                {
                    for (int i = 0; i <= RoomList.Items.Count - 1; i++)
                    {
                        ListViewItem item = RoomList.Items[i];
                        if (RoomList.Items[i].Focused == true)
                        {
                            RoomList.Items[i].Checked = true;
                        }
                    }
                }
            }
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void comfirm_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
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
