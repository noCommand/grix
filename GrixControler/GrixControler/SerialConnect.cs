using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace GrixControler
{

    public class SerialConnect
    {
        public byte[] findPort = { 0xAA, 0x00, 0x01, 0x00, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0x01, 0x55 };

        public byte[] readCmd = { 0xAA, 0xBB, 0xBB, 0x00, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0x55 };
        public byte[] powerOffCmd = { 0xAA, 0xBB, 0xBB, 0x10, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0x55 };
        public byte[] powerOnCmd = { 0xAA, 0xBB, 0xBB, 0x11, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0x55 };
        public byte[] lockOnCmd = { 0xAA, 0xBB, 0xBB, 0x44, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0x55 };
        public byte[] lockOffCmd = { 0xAA, 0xBB, 0xBB, 0x40, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0x55 };
        public byte[] allOnCmd = { 0xAA, 0x64, 0x64, 0x11, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0x11, 0x55 };
        public byte[] writeCmd = { 0xAA, 0xBB, 0xBB, 0x20, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0x55 };

        public byte[] Cmd = { 0xAA, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0x55 };

        MainForm main;

        SerialPort sp = new SerialPort();
      

        public SerialConnect(MainForm main)
        {
            this.main = main;
        }

        public SerialConnect(String pttx)
        {

            sp.PortName = pttx;
            sp.BaudRate = 38400;

            try
            {
                sp.Open();
                if (sp.IsOpen)
                    MessageBox.Show(sp.IsOpen.ToString());
                else
                    MessageBox.Show(sp.IsOpen.ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }

        }

        public bool CheckPortOpen()
        {
            if (sp.IsOpen)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /*
        public void SendPacket(SerialPort sp, byte[] packet)
        {
            
        }
        */
        public void AutoConnect()
        {

            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                try
                {
                    sp.PortName = s;
                    sp.Open();
                    sp.Write(findPort, 0, findPort.Length);
                    System.Threading.Thread.Sleep(100);

                    if (sp.BytesToRead != 0)
                    {
                        if (!sp.ReadByte().Equals(0xAA))
                        {
                            sp.Close();
                        }
                    }
                    else
                    {
                        sp.Close();
                    }

                }
                catch (Exception e) { }
            }

            if (sp.IsOpen)
            {
                MessageBox.Show(sp.PortName + " 포트연결 성공");
                // 지우지말기
                MessageBox.Show(" 테스트" + sp.ReadByte() + " " + sp.ReadByte() + " " + sp.ReadByte() + " "
                    + sp.ReadByte() + " " + sp.ReadByte() + " " + sp.ReadByte() + " " + sp.ReadByte() + " "
                    + sp.ReadByte() + " " + sp.ReadByte() + " " + sp.ReadByte() + " " + sp.ReadByte() + " "
                    + sp.ReadByte() + " " + sp.ReadByte() + " " + sp.ReadByte() + " " + sp.ReadByte() + " "
                    + sp.ReadByte() + " " + sp.ReadByte() + " ");

            }
            else
            {
                MessageBox.Show(sp.PortName + " 포트연결실패");
            }            
        }

        public void PortClose()
        {
            sp.Close();
        }

        public byte[] setTempCmd(byte setTemp)
        {
            byte checksum = writeCmd[1];

            writeCmd[6] = setTemp;

            for (int i = 1; i < 16; i++)
            {
                checksum ^= writeCmd[i];
            }

            writeCmd[16] = checksum;
            return writeCmd;

            // 수정해야함 -> 
        }




        public RoomInfo GetSerialPacket(byte[] serialRead, byte id_H, byte id_L)
        {

            ClearBuffer();

            int originTemp;
            int compareTemp;
            int environment;

            int a, b, c, d, e, f, g, h;

            RoomInfo roominfo = new RoomInfo();

            string test;

            serialRead[1] = id_H;
            serialRead[2] = id_L;

            serialRead[16] = FindCheckSum(serialRead);
            
            sp.Write(serialRead, 0, serialRead.Length);


            /**
             * 송신 패킷을 보낼 때 수신하는 데이터가 없으면 sp.ReadByte에서 입력값을 받을때까지 대기하는 듯 하다.
             * 
             * */

            /*
            if(sp.BytesToRead > 18) 
            {
                for(int k = 0; k <18; k ++)
                {
                    sp.ReadByte();
                }
            } // 혹시 모르니 -> X      이러게하면 패킷이 중복으로 보내질 때 섞여서 보내질 위험이 있음 그냥 전부 지우고 차례로 보내야함
            */
            //MessageBox.Show("읽는 바이트 수" + sp.BytesToRead.ToString());

            System.Threading.Thread.Sleep(100);
            /** 18.5.2
             * 위의 MessgaeBox에 sp.BytesToRead에서 0이 결과값으로 나옴
             * 
             * 근데 아래 sp.BytesToRead는 18이 나옴
             * 
             * 즉 sp.write를 하고나서 바로 bytesToRead를 사용하면 0이 되는데, 이후 같은메소드를 사용하면 18이 나옴
             * 
             * ...시간차때문?
             * ---------------------------------------- 결론----
             * thread.sleep으로 들어갈 시간을 줬더니 예상한 결과값이 나옴
             * */

            
            if (sp.BytesToRead == 18)
            {
                

                a = sp.ReadByte();
                b = sp.ReadByte();
                c = sp.ReadByte();
                roominfo.ID = b * 100 + c;
                d = sp.ReadByte();
                environment = sp.ReadByte();

                if((environment & 0x04) == 0x04)
                {
                    roominfo.LockOn = true;
                }
                else roominfo.LockOn = false;

                if ((environment & 0x01) == 0x01)
                {
                    roominfo.PowerOn = true;
                }
                else roominfo.PowerOn = false;

                originTemp = sp.ReadByte();
                compareTemp = sp.ReadByte();
                roominfo.NowTemp = originTemp;
                roominfo.SetTemp = compareTemp;

                if (compareTemp > originTemp)
                {
                    roominfo.HeaterOn = true;
                }
                else
                {
                    roominfo.HeaterOn = false;
                }
                /*
                MessageBox.Show(" 테스트" + 
                    a + " " + b + " " + c + " " + d + " " + islock + " " + originTemp + " " + compareTemp + " "
                    + sp.ReadByte() + " " 
                    + sp.ReadByte() + " " + sp.ReadByte() + " " + sp.ReadByte() + " " + sp.ReadByte() + " " 
                    + sp.ReadByte() + " " + sp.ReadByte() + " " + sp.ReadByte() + " " + sp.ReadByte() + " " 
                    + sp.ReadByte() + " " + sp.ReadByte() + " " );
                 */
                 
                for (int i = 0; i < 9; i++)
                {
                    sp.ReadByte();
                }
                roominfo.CheckSum = sp.ReadByte();
                sp.ReadByte();
                ClearBuffer();
                return roominfo;
            }
            else
            {
                

                foreach(RoomInfo info in main.roomInfoList)
                {
                    if (info.ID == id_H * 100 + id_L)
                    {
                        roominfo = info;
                    }
                }
                ClearBuffer();
                return roominfo;
                //MessageBox.Show("serialconnection "+sp.BytesToRead.ToString());
                /** 18.5.5
                 *  중간에 roomsetting을 눌렀을 때, sp.bytetoread가 18이 아니게됨. 따라서 패킷은 보내지 않치만, return roominfo는 무조건 반환을 함
                 *  반환된 serial데이터가 없으므로, roominfo는 default값인 0을 넣어서 반환.
                 *  따라서 18이 아닐 때에는 list에 들어있던 예전 데이터를 roominfo에 넣어서 반환시킴
                 * */
            }
            
        }




        public void setSerialPacket(byte[] serialCommand, byte id_H, byte id_L)
        {
            ClearBuffer();

            serialCommand[1] = id_H;
            serialCommand[2] = id_L;

            serialCommand[16] = FindCheckSum(serialCommand);
            /*
             * MessageBox.Show(serialCommand[0].ToString() + " " +
               serialCommand[1].ToString() + " " + serialCommand[2].ToString() + " " + serialCommand[3].ToString() + " " +
               serialCommand[4].ToString() + " " + serialCommand[5].ToString() + " " + serialCommand[6].ToString() + " " +
               serialCommand[7].ToString() + " " + serialCommand[8].ToString() + " " + serialCommand[9].ToString() + " " +
               serialCommand[10].ToString() + " " + serialCommand[11].ToString() + " " + serialCommand[12].ToString() + " " +
               serialCommand[13].ToString() + " " + serialCommand[14].ToString() + " " + serialCommand[15].ToString() + " " +
               serialCommand[16].ToString() + " " + serialCommand[17].ToString() + " ");
               */
            /**
             * Messagebox만 들어가면 invoke로 빠짐,,, 이유를 모르겠음
             * */

            sp.Write(serialCommand, 0, serialCommand.Length);
            //MessageBox.Show("setSerialPacket!!! " + sp.BytesToRead.ToString());
            ClearBuffer();
            System.Threading.Thread.Sleep(100);
            // sleep을 써줘야 데이터가 제데로 전송됨
            
        }

        public byte FindCheckSum(byte[] cmd)
        {
            byte checksum = cmd[1];
            for (int i = 1; i < 16; i++)
            {
                checksum ^= cmd[i];
            }
            return checksum;
        }

        public void ClearBuffer()
        {
            sp.DiscardInBuffer();
        }

        public void spLength()
        {
            MessageBox.Show("Length : " +sp.BytesToRead.ToString());
        }

    }
}
