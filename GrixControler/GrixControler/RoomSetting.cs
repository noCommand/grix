using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrixControler
{
    public partial class RoomSetting : Form
    {
        Byte[] setCommand;

        MainForm main = null;

        String roomID;

        byte[] idValue = new byte[2];

        public RoomSetting(MainForm main, String roomID)
        {
            this.main = main;
            this.roomID = roomID;
            InitializeComponent();
            main.ThreadPause();

            /*
            main.ThreadPause();
            System.Threading.Thread.Sleep(500);
            main.serialConnect.ClearBuffer();

            powerOnBtn.Checked = true;
            lockOffBtn.Checked = true;


            RoomInfo settingValue = new RoomInfo();
            IDStringToByte();
            settingValue = main.serialConnect.GetSerialPacket(main.serialConnect.readCmd, idValue[0], idValue[1]);
            // 앱이 중단상태에 있습니다
            setTempControl.Value = settingValue.SetTemp;
            */
            /*18.5.4
             * sp 길이 0 36 나오는 문제 해결해야함
             * 
             * -----------------해결
             * 패킷 보낼필요없이 저장해놓은 list에서 가지고오면됨
             * */

            IDStringToByte();
            foreach (RoomInfo info in main.roomInfoList)
            {
                if (roomID == info.ID.ToString())
                {
                    if (info.StepOn)
                    {
                        setTempControl.Enabled = false;
                        setStepControl.Value = info.TempStep;
                    }

                    else
                    {
                        setStepControl.Enabled = false;
                        if (info.SetTemp == " ")
                        {
                            setTempControl.Value = 0;
                        }
                        else
                        {
                            setTempControl.Value = Convert.ToInt32(info.SetTemp);
                        }
                    }
                    setTempControl.Maximum = info.UH;
                    if (info.LockOn) LockOnBtn.Checked = true;
                    else lockOffBtn.Checked = true;
                    if (info.PowerOn) powerOnBtn.Checked = true;
                    else powerOffBtn.Checked = true;

                }
            }
            main.serialConnect.ClearReceiveBuffer();

        }

        private void IDStringToByte()
        {
            String id_H, id_L;

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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            int cmdResult = 0;

            if (powerOnBtn.Checked)
            {
                cmdResult = FindIntFromByteIndex(4) + FindIntFromByteIndex(0);
            }
            else if (powerOffBtn.Checked)
            {
                cmdResult = FindIntFromByteIndex(4);
            }

            if (LockOnBtn.Checked)
            {
                cmdResult += FindIntFromByteIndex(6) + FindIntFromByteIndex(2);
            }
            else if (lockOffBtn.Checked)
            {
                cmdResult += FindIntFromByteIndex(6);
            }

            cmdResult += FindIntFromByteIndex(5);
            main.roomInfoSet = main.serialConnect.GetSerialPacketForResult(main.serialConnect.Cmd, (Byte)cmdResult, (Byte)setTempControl.Value, (Byte)setStepControl.Value, idValue[0], idValue[1]);

            main.roomSet = true;

            main.viewStartCount = FindIndexFromID();
            this.Close();


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

        private int FindIndexFromID()
        {
            int i = 0;
            for (i = 0; i < main.roomID.Length; i++)
            {
                if (main.roomID[i] == roomID)
                    break;
            }
            return i;
        }

        private void RoomSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.ThreadResume();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setStepControl_ValueChanged(object sender, EventArgs e)
        {
            if (setStepControl.Value < 1)
            {
                setStepControl.Value = 1;
            }
            if (setStepControl.Value > 9)
            {
                setStepControl.Value = 9;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setStepControl.Value = 5;
            setTempControl.Value = 25;
            lockOffBtn.Checked = true;
            powerOnBtn.Checked = true;
        }
    }
}
