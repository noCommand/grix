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
    public partial class AllRoomSetting : Form
    {

        Byte[] setCommand;

        MainForm main = null;


        SQLiteConnection dbConn = new SQLiteConnection(@"Data Source=" + Application.StartupPath + @"\GrixDB" + @"\grixdb.db");

        SQLiteCommand command;

        SQLiteDataReader rdr;

        int all_check = 0;

        string sql;


        public AllRoomSetting(MainForm main)
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

        private List<String> GetGroupID()
        {
            //Byte[] seperateID = new Byte[2];

            List<String> roomStringID = new List<String>();

            if (GroupRoomList.Items.Count > 0)
            {
                for (int i = 0; i <= GroupRoomList.Items.Count - 1; i++)
                {
                    roomStringID.Add(GroupRoomList.Items[i].SubItems[0].Text);
                }
            }
            return roomStringID;
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


        public RoomInfo GroupingRoomSettinComfirm(Byte[] id, bool powerOn, bool lockOn, int setTemp)
        {
            RoomInfo ri;

            int cmdResult = 0;

            if (powerOn)
            {
                cmdResult = FindIntFromByteIndex(4) + FindIntFromByteIndex(0);
            }
            else if (!powerOn)
            {
                cmdResult = FindIntFromByteIndex(4);
            }

            if (lockOn)
            {
                cmdResult += FindIntFromByteIndex(6) + FindIntFromByteIndex(2);
            }
            else if (!lockOn)
            {
                cmdResult += FindIntFromByteIndex(6);
            }
            //MessageBox.Show(setTempControl.Value.ToString() +  idValue[0] + idValue[1]);
            cmdResult += FindIntFromByteIndex(5);

            ri = main.serialConnect.GetGroupSerialPacket(main.serialConnect.Cmd, (Byte)cmdResult, (Byte)setTemp, id[0], id[1]);

            return ri;
        }

        private void RoomSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.ThreadResume();
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

            sql = "select * from idTable where roomid not in(select roomid from idtable where roomid = \'9999\')";

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
            SetAllClick();
        }

        private void SetAllClick()
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

            setTempControl.Value = 25;
            setStepControl.Value = 3;
        }


        private int FindIntFromByteIndex(int index)
        {
            int result = 1;
            for (int i = 0; i < index; i++)
            {
                result *= 2;
            }
            return result;
        }

        private void GroupRoomList_ItemChecked(object sender, System.Windows.Forms.ItemCheckedEventArgs e)
        {

        }
        

        private void AllRoomSetting_Load(object sender, EventArgs e)
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

        private void ConfirmBtn_Click_1(object sender, EventArgs e)
        {
            main.isGroup = true;
            main.groupGetInfo = GetGroupRoomInfo();
            main.groupID = GetGroupID();
            main.viewStartCount = FindIndexFromID();
            main.ThreadResume();
            this.Close();
        }

        private void cancelBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AllRoomSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.ThreadResume();
        }
    }
}
