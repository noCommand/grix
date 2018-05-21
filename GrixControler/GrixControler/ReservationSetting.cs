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
            if(!MondayStartCheckbox.Checked&&
                !TuesdayStartCheckbox.Checked&&!WednesdayStartCheckbox.Checked&&
                !ThursdayStartCheckbox.Checked&&!FridayStartCheckbox.Checked&&
                    !SaturdayStartCheckbox.Checked&&!SundayStartCheckbox.Checked)
            {
                appendDay.Append("-");
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
            if(!MondayStartCheckbox.Checked &&
                !TuesdayStartCheckbox.Checked && !WednesdayStartCheckbox.Checked &&
                !ThursdayStartCheckbox.Checked && !FridayStartCheckbox.Checked &&
                    !SaturdayStartCheckbox.Checked && !SundayStartCheckbox.Checked)
            {
                appendDay.Append("-");
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
            else if (day == "화")
            {
                TuesdayStartCheckbox.Checked = true;
            }
            else if (day == "수")
            {
                WednesdayStartCheckbox.Checked = true;
            }
            else if (day == "목")
            {
                ThursdayStartCheckbox.Checked = true;
            }
            else if (day == "금")
            {
                FridayStartCheckbox.Checked = true;
            }
            else if (day == "토")
            {
                SaturdayStartCheckbox.Checked = true;
            }
            else if (day == "일")
            {
                SundayStartCheckbox.Checked = true;
            }
            else {
                AllStartCheckboxUnCheck();
            }
        }

        private void FindReservationEndDayFromDB(String day)
        {
            if (day == "월")
            {
                MondayEndCheckbox.Checked = true;
            }
            else if (day == "화")
            {
                TuesdayEndCheckbox.Checked = true;
            }
            else if (day == "수")
            {
                WednesdayEndCheckbox.Checked = true;
            }
            else if (day == "목")
            {
                ThursdayEndCheckbox.Checked = true;
            }
            else if (day == "금")
            {
                FridayEndCheckbox.Checked = true;
            }
            else if (day == "토")
            {
                SaturdayEndCheckbox.Checked = true;
            }
            else if (day == "일")
            {
                SundayEndCheckbox.Checked = true;
            }
            else {
                AllEndCheckboxUnCheck();
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
                            String[] startDay;
                            String[] endDay;
                            int count;
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
                                   Convert.ToInt32(rdr["TuesdayStartTime"].ToString().Substring(4, 2)), 0);
                                TuesdayTempUpDown.Value = Convert.ToInt32(rdr["TuesdayTemp"].ToString());

                                WednesdayStartTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(rdr["WednesdayStartTime"].ToString().Substring(2, 2)),
                                    Convert.ToInt32(rdr["WednesdayStartTime"].ToString().Substring(4, 2)), 0);
                                WednesdayTempUpDown.Value = Convert.ToInt32(rdr["WednesdayTemp"].ToString());

                                ThursdayStartTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(rdr["ThursdayStartTime"].ToString().Substring(2, 2)),
                                    Convert.ToInt32(rdr["ThursdayStartTime"].ToString().Substring(4, 2)), 0);
                                ThursdayTempUpDown.Value = Convert.ToInt32(rdr["ThursdayTemp"].ToString());

                                FridayStartTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(rdr["FridayStartTime"].ToString().Substring(2, 2)),
                                    Convert.ToInt32(rdr["FridayStartTime"].ToString().Substring(4, 2)), 0);
                                FridayTempUpDown.Value = Convert.ToInt32(rdr["FridayTemp"].ToString());
                                
                                SaturdayStartTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(rdr["SaturdayStartTime"].ToString().Substring(2, 2)),
                                    Convert.ToInt32(rdr["SaturdayStartTime"].ToString().Substring(4, 2)), 0);
                                SaturdayTempUpDown.Value = Convert.ToInt32(rdr["SaturdayTemp"].ToString());

                                SundayStartTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(rdr["SundayStartTime"].ToString().Substring(2, 2)),
                                    Convert.ToInt32(rdr["SundayStartTime"].ToString().Substring(4, 2)), 0);
                                SundayTempUpDown.Value = Convert.ToInt32(rdr["SundayTemp"].ToString());


                                MondayEndTimePicker.Value = new DateTime(2000, 1, 1,
                                   Convert.ToInt32(rdr["MondayEndTime"].ToString().Substring(2, 2)),
                                   Convert.ToInt32(rdr["MondayEndTime"].ToString().Substring(4, 2)), 0);

                                TuesdayEndTimePicker.Value = new DateTime(2000, 1, 1,
                                   Convert.ToInt32(rdr["TuesdayEndTime"].ToString().Substring(2, 2)),
                                   Convert.ToInt32(rdr["TuesdayEndTime"].ToString().Substring(4, 2)), 0);

                                WednesdayEndTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(rdr["WednesdayEndTime"].ToString().Substring(2, 2)),
                                    Convert.ToInt32(rdr["WednesdayEndTime"].ToString().Substring(4, 2)), 0);

                                ThursdayEndTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(rdr["ThursdayEndTime"].ToString().Substring(2, 2)),
                                    Convert.ToInt32(rdr["ThursdayEndTime"].ToString().Substring(4, 2)), 0);

                                FridayEndTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(rdr["FridayEndTime"].ToString().Substring(2, 2)),
                                    Convert.ToInt32(rdr["FridayEndTime"].ToString().Substring(4, 2)), 0);

                                SaturdayEndTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(rdr["SaturdayEndTime"].ToString().Substring(2, 2)),
                                    Convert.ToInt32(rdr["SaturdayEndTime"].ToString().Substring(4, 2)), 0);

                                SundayEndTimePicker.Value = new DateTime(2000, 1, 1,
                                    Convert.ToInt32(rdr["SundayEndTime"].ToString().Substring(2, 2)),
                                    Convert.ToInt32(rdr["SundayEndTime"].ToString().Substring(4, 2)), 0);

                                startDay = SeperateDay(rdr["ReservationStartDay"].ToString());
                                endDay = SeperateDay(rdr["ReservationEndDay"].ToString());

                                for(count = 0; count < startDay.Length; count++)
                                {
                                    FindReservationStartDayFromDB(startDay[count]);
                                }
                                for(count = 0; count < endDay.Length; count++)
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
            for(int i = 0; i < str.Length; i++)
            {
                strArray[i] = str.Substring(i,1);
            }
            return strArray;
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
