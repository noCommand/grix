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
using System.Threading;

namespace GrixControler
{

    public partial class AdminSetting : Form
    {
        MainForm main;

        SQLiteConnection dbConn = new SQLiteConnection(@"Data Source=" + Application.StartupPath + @"\GrixDB" + @"\grixdb.db");

        SQLiteCommand command;

        SQLiteDataReader rdr;

        int all_check = 0;

        string sql;


        public AdminSetting(MainForm main, int i)
        {
            this.main = main;
        }

        public AdminSetting(MainForm main)
        {

            this.main = main;
            InitializeComponent();
            main.ThreadPause();
        }

        private void AdminSetting_Load(object sender, EventArgs e)
        {

            setDFText.Text = "3";
            setDFText.MaxLength = 2;
            setUHText.Text = "60";
            setUHText.MaxLength = 2;
            setULText.Text = "0";
            setULText.MaxLength = 2;
            setHTText.Text = "60";
            setHTText.MaxLength = 2;
            setPDText.Text = "3";
            setPDText.MaxLength = 2;
            setODText.Text = "1";
            setODText.MaxLength = 2;
            setTCText.Text = "0";
            setTCText.MaxLength = 2;

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

        private int FindIndexFromID()
        {
            int i = 0;
            List<String> forFirstIndex = GetGroupID();
            for (i = 0; i < main.roomID.Length; i++)
            {
                if (main.roomID[i] == forFirstIndex[0])
                    break;
            }
            return i;
        }

        public byte[] IDStringToByte(String roomID)
        {
            String id_H, id_L;
            byte[] idValue = new byte[2];

            if (roomID.Length == 4)
            {
                id_H = roomID.Substring(0, 2);
                id_L = roomID.Substring(2, 2);
            }
            else if (roomID.Length == 3)
            {
                id_H = roomID.Substring(0, 1);
                id_L = roomID.Substring(1, 2);
            }
            else
            {
                id_H = "0";
                id_L = roomID;
            }
            //MessageBox.Show(id_H + id_L);
            byte h = (byte)Convert.ToInt32(id_H);
            byte l = (byte)Convert.ToInt32(id_L);

            idValue[0] = h;
            idValue[1] = l;

            return idValue;
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

            sql = "select * from idTable where roomid not in(select roomid from idtable where roomid = \'9999\')";

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

        private AdminInfo GetAdminInfo()
        {
            AdminInfo ad = new AdminInfo();

            ad.DF = Convert.ToInt32(setDFText.Text);
            ad.UH = Convert.ToInt32(setUHText.Text);
            ad.UL = Convert.ToInt32(setULText.Text);
            ad.HT = Convert.ToInt32(setHTText.Text);
            ad.PD = Convert.ToInt32(setPDText.Text);
            ad.OD = Convert.ToInt32(setODText.Text);
            ad.TC = Convert.ToInt32(setTCText.Text);

            return ad;
        }

        public RoomInfo AdminRoomSettinComfirm(Byte[] id, int df, int uh, int ul, int ht, int pd, int od, int tc)
        {
            RoomInfo ri;
            
            ri = main.serialConnect.GetAdminSerialPacket(main.serialConnect.Cmd, (Byte)df, (Byte)uh,
                (Byte)ul, (Byte)ht, (Byte)pd, (Byte)od, (Byte)tc, id[0], id[1]);

            return ri;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            main.isGroup = false;
            if(string.IsNullOrEmpty(setDFText.Text)|| string.IsNullOrEmpty(setUHText.Text)
                || string.IsNullOrEmpty(setULText.Text) || string.IsNullOrEmpty(setHTText.Text)
                || string.IsNullOrEmpty(setPDText.Text) || string.IsNullOrEmpty(setODText.Text)
                || string.IsNullOrEmpty(setTCText.Text))
            {
                MessageBox.Show("전부 입력해주세요");
            }else
            {
                main.adminInfo = GetAdminInfo();
                main.groupID = GetGroupID();
                main.viewStartCount = FindIndexFromID();
                main.ThreadResume();
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

            main.ThreadResume();
            this.Close();
        }

        private List<String> GetGroupID()
        {
            //Byte[] seperateID = new Byte[2];

            List<String> roomStringID = new List<String>();

            if (RoomList.Items.Count > 0)
            {
                for (int i = 0; i <= RoomList.Items.Count - 1; i++)
                {
                    if (RoomList.Items[i].Checked == true)
                    {
                        roomStringID.Add(RoomList.Items[i].SubItems[0].Text);

                        //seperateID = IDStringToByte(GroupRoomList.Items[i].SubItems[0].Text);
                        //GroupingRoomSettinComfirm(seperateID);
                    }
                }
            }
            return roomStringID;
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
        
        private void inputOnlyInt(KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void setDFText_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputOnlyInt(e);
            setTextBoxFocus(e, setUHText);
        }

        private void setUHText_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputOnlyInt(e);
            setTextBoxFocus(e, setULText);
        }

        private void setULText_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputOnlyInt(e);
            setTextBoxFocus(e, setHTText);
        }

        private void setHTText_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputOnlyInt(e);
            setTextBoxFocus(e, setPDText);
        }

        private void setPDText_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputOnlyInt(e);
            setTextBoxFocus(e, setODText);
        }

        private void setODText_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputOnlyInt(e);
            setTextBoxFocus(e, setTCText);
        }

        private void setTCText_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputOnlyInt(e);
        }

        private void setDFText_Leave(object sender, EventArgs e)
        {
            setMinMaxCount(setDFText, 1, 10);
        }


        private void setUHText_Leave(object sender, EventArgs e)
        {
            setMinMaxCount(setUHText, 0, 80);
        }

        private void setULText_Leave(object sender, EventArgs e)
        {
            setMinMaxCount(setULText, 0, 0);
        }

        private void setHTText_Leave(object sender, EventArgs e)
        {
            setMinMaxCount(setHTText,Convert.ToInt32(setUHText.Text), 80);
        }

        private void setPDText_Leave(object sender, EventArgs e)
        {
            setMinMaxCount(setPDText, 1, 60);
        }

        private void setODText_Leave(object sender, EventArgs e)
        {
            setMinMaxCount(setODText, 1, 60);
        }

        private void setTCText_Leave(object sender, EventArgs e)
        {
            setMinMaxCount(setTCText, 0, 10);
        }


        private void setMinMaxCount(TextBox textBox, int minCount, int maxCount)
        {
            if (Convert.ToInt32(textBox.Text) > maxCount)
            {
                textBox.Text = maxCount.ToString();
            }
            if (Convert.ToInt32(textBox.Text) < minCount)
            {
                textBox.Text = minCount.ToString();
            }
        }


        private void setTextBoxFocus(KeyPressEventArgs e, TextBox textBox)
        {
            if (e.KeyChar == (char)13)
            {
                textBox.Focus();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
