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
    public partial class GroupSetting : Form
    {

        Byte[] setCommand;

        MainForm main = null;


        SQLiteConnection dbConn = new SQLiteConnection(@"Data Source=" + Application.StartupPath + @"\GrixDB" + @"\grixdb.db");

        SQLiteCommand command;

        SQLiteDataReader rdr;

        int all_check = 0;

        string sql;


        public GroupSetting(MainForm main, int i)
        {
            this.main = main;
        }


        public GroupSetting(MainForm main)
        {
            InitializeComponent();
            main.ThreadPause();

            this.main = main;

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            main.groupGetInfo = GetGroupRoomInfo();
            main.groupID = GetGroupID();
            main.ThreadResume();
            this.Close();

            main.GroupSettingThreadStart();
            
        }

        private List<String> GetGroupID()
        {
            //Byte[] seperateID = new Byte[2];

            List<String> hi = new List<String>();
            
            if (GroupRoomList.Items.Count > 0)
            {
                for (int i = 0; i <= GroupRoomList.Items.Count - 1; i++)
                {
                    if (GroupRoomList.Items[i].Checked == true)
                    {
                        hi.Add(GroupRoomList.Items[i].SubItems[0].Text);
                        
                        //seperateID = IDStringToByte(GroupRoomList.Items[i].SubItems[0].Text);
                        //GroupingRoomSettinComfirm(seperateID);
                    }
                }
            }
            return hi;
        }

        private GroupRoomInfo GetGroupRoomInfo()
        {
            GroupRoomInfo gr = new GroupRoomInfo();

            if (powerOnBtn.Checked)
            {
                gr.PowerOn = true;
            }
            else if (powerOffBtn.Checked)
            {
                gr.PowerOn = false;
            }

            if (LockOnBtn.Checked)
            {
                gr.LockOn = true;
            }
            else if (lockOffBtn.Checked)
            {
                gr.LockOn = false;
            }
            gr.SetTemp = (int)setTempControl.Value;

            return gr;
        }


        public void GroupingRoomSettinComfirm(Byte[] id,bool powerOn, bool lockOn, int setTemp)
        {
            if (powerOn)
            {
                main.serialConnect.setSerialPacket(main.serialConnect.powerOnCmd, id[0], id[1]);
            }
            else if (!powerOn)
            {
                main.serialConnect.setSerialPacket(main.serialConnect.powerOffCmd, id[0], id[1]);
            }

            if (lockOn)
            {
                main.serialConnect.setSerialPacket(main.serialConnect.lockOnCmd, id[0], id[1]);
            }
            else if (!lockOn)
            {
                main.serialConnect.setSerialPacket(main.serialConnect.lockOffCmd, id[0], id[1]);
            }
            //MessageBox.Show(setTempControl.Value.ToString() +  idValue[0] + idValue[1]);
            main.serialConnect.setSerialPacket(main.serialConnect.setTempCmd((Byte)setTemp), id[0], id[1]);
            System.Threading.Thread.Sleep(100);
        }

        private void RoomSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.ThreadResume();
        }

        private void GroupSetting_Load(object sender, EventArgs e)
        {
            GroupRoomList.View = View.Details;
            GroupRoomList.GridLines = true;
            GroupRoomList.FullRowSelect = true;
            GroupRoomList.CheckBoxes = true;

            GroupRoomList.Columns.Add("", 50);

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

            if (GroupRoomList.Items.Count >= 0)
            {
                int count = GroupRoomList.Items.Count;
                for (int i = 0; i <= count - 1; i++)

                {
                    GroupRoomList.Items.RemoveAt(0);
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
                GroupRoomList.Items.Add(listViewItem);
            }
            rdr.Close();
        }

        private void groupComfirrBtn_Click(object sender, EventArgs e)
        {
        }

        private void GroupSetting_FormClosed(object sender, FormClosedEventArgs e)
        {

            dbConn.Close();
        }

        private void all_button_Click(object sender, EventArgs e)
        {
            if (all_check == 0 && GroupRoomList.Items.Count > 0)
            {
                all_check = -1;

                for (int i = 0; i <= GroupRoomList.Items.Count - 1; i++)
                {
                    GroupRoomList.Items[i].Checked = true;
                }
            }
            else
            {
                all_check = 0;

                for (int i = 0; i <= GroupRoomList.Items.Count - 1; i++)
                {
                    GroupRoomList.Items[i].Checked = false;
                }
            }
        }
    }
}
