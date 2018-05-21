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
                    setTempControl.Value = info.SetTemp;
                    if (info.LockOn) LockOnBtn.Checked = true;
                    else lockOffBtn.Checked = true;
                    powerOnBtn.Checked = true;
                }
            }
            main.serialConnect.ClearBuffer();

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
            if (powerOnBtn.Checked)
            {
                main.serialConnect.setSerialPacket(main.serialConnect.powerOnCmd, idValue[0], idValue[1]);
                //-> 위 코드 실행하면 main thread가 동작하지 않는 현상??
                //  이 버튼을 누르면 3번 room에 1번의 정보가 잠깐 들어감
                /** 18.5.2
                 *  이 버튼을 누르면 갑자기 main의 updateview의 컨트롤 invoke 함수로 들어감.... 다 거르고 if문 안으로 들어가서 무한루프..
                 *  
                 *  해결 --> 디버깅 모드로 돌릴때 자식 폼에 들어갔다가 나오면 f11로 넘겨도 한줄씩 넘기지않고 몇몇코드를 생략하고 보여줌 
                 *  invoke문제가 아닌 serialconnection getserialpacket에서 readtobyte -> 18 일때 readbyte하고 수신패킷 비우게해놨는데
                 *  자식폼에서 패킷 송신시 중첩, 수신패킷 2배 36으로 받아서 비워지지않고 계속 쌓였음 54 72 .... 이래서 UI 갱신이 안된거였음
                 *  DiscardInBuffer  if문 밖으로 빼놓음
                 * */
            }
            else if (powerOffBtn.Checked)
            {
                main.serialConnect.setSerialPacket(main.serialConnect.powerOffCmd, idValue[0], idValue[1]);
            }

            if (LockOnBtn.Checked)
            {
                main.serialConnect.setSerialPacket(main.serialConnect.lockOnCmd, idValue[0], idValue[1]);
            }
            else if (lockOffBtn.Checked)
            {
                main.serialConnect.setSerialPacket(main.serialConnect.lockOffCmd, idValue[0], idValue[1]);
            }
            //MessageBox.Show(setTempControl.Value.ToString() +  idValue[0] + idValue[1]);
            main.serialConnect.setSerialPacket(main.serialConnect.setTempCmd((Byte)setTempControl.Value), idValue[0], idValue[1]);
            System.Threading.Thread.Sleep(100);
            //setTempControl.Value
            this.Close();


        }

        private void RoomSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.ThreadResume();
        }
    }
}
