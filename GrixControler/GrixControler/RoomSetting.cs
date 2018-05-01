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

        public RoomSetting(MainForm main)
        {
            this.main = main;
            InitializeComponent();
            main.ThreadPause();
            powerOnBtn.Checked = true;
            lockOffBtn.Checked = true;

            RoomInfo settingValue = new RoomInfo();
            //settingValue = main.serialConnect.GetSerialPacket(main.serialConnect.readCmd);
            setTempControl.Value = settingValue.SetTemp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void ConfirmBtn_Click(object sender, EventArgs e)
        {

            if (powerOnBtn.Checked)
            {
                //main.serialConnect.setSerialPacket(main.serialConnect.powerOnCmd);
            }
            else if (powerOffBtn.Checked)
            {
                //main.serialConnect.setSerialPacket(main.serialConnect.powerOffCmd);
            }

            if (LockOnBtn.Checked)
            {
               // main.serialConnect.setSerialPacket(main.serialConnect.lockOnCmd);
            }
            else if (lockOffBtn.Checked)
            {
               // main.serialConnect.setSerialPacket(main.serialConnect.lockOffCmd);
            }

            //main.serialConnect.setSerialPacket(main.serialConnect.setTempCmd((Byte)setTempControl.Value));
            //setTempControl.Value

            
            this.Close();
        }

        private void RoomSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.ThreadResume();
        }
    }
}
