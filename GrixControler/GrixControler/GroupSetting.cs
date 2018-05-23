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
    public partial class GroupSetting : Form
    {

        Byte[] setCommand;

        MainForm main = null;


        SQLiteConnection dbConn = new SQLiteConnection(@"Data Source=" + Application.StartupPath + @"\GrixDB" + @"\grixdb.db");

        SQLiteCommand command;

        SQLiteDataReader rdr;

        int all_check = 0;

        string sql;

        public GroupSetting(MainForm main)
        {
            InitializeComponent();
            main.ThreadPause();

            this.main = main;
            
        }
        
        private byte[] IDStringToByte(String roomID)
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            Byte[] seperateID = new Byte[2];

            if (RoomList.Items.Count > 0)
            {
                for (int i = 0; i <= RoomList.Items.Count - 1; i++)
                {
                    if (RoomList.Items[i].Checked == true)
                    {
                        seperateID = IDStringToByte(RoomList.Items[i].SubItems[0].Text);
                        GroupingRoomSettinComfirm(seperateID);
                    }
                }
            }
            this.Close();

        }

        private void GroupingRoomSettinComfirm(Byte[] id)
        {
            if (powerOnBtn.Checked)
            {
                main.serialConnect.setSerialPacket(main.serialConnect.powerOnCmd, id[0], id[1]);
            }
            else if (powerOffBtn.Checked)
            {
                main.serialConnect.setSerialPacket(main.serialConnect.powerOffCmd, id[0], id[1]);
            }

            if (LockOnBtn.Checked)
            {
                main.serialConnect.setSerialPacket(main.serialConnect.lockOnCmd, id[0], id[1]);
            }
            else if (lockOffBtn.Checked)
            {
                main.serialConnect.setSerialPacket(main.serialConnect.lockOffCmd, id[0], id[1]);
            }
            //MessageBox.Show(setTempControl.Value.ToString() +  idValue[0] + idValue[1]);
            main.serialConnect.setSerialPacket(main.serialConnect.setTempCmd((Byte)setTempControl.Value), id[0], id[1]);
            System.Threading.Thread.Sleep(100);
        }

        private void RoomSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.ThreadResume();
        }

        private void GroupSetting_Load(object sender, EventArgs e)
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

        private void groupComfirrBtn_Click(object sender, EventArgs e)
        {
        }

        private void GroupSetting_FormClosed(object sender, FormClosedEventArgs e)
        {

            dbConn.Close();
            main.ThreadResume();
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
    }
}
