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
        public byte[] readCmd = { 0xAA, 0xBB, 0xBB, 0x00, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0x55 };
        public byte[] powerOffCmd = { 0xAA, 0xBB, 0xBB, 0x10, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0x55 };
        public byte[] powerOnCmd = { 0xAA, 0xBB, 0xBB, 0x11, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0x55 };
        public byte[] lockOnCmd = { 0xAA, 0xBB, 0xBB, 0x44, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0x55 };
        public byte[] lockOffCmd = { 0xAA, 0xBB, 0xBB, 0x40, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0x55 };
        public byte[] allOnCmd = { 0xAA, 0x64, 0x64, 0x11, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0x11, 0x55 };
        public byte[] writeCmd = { 0xAA, 0xBB, 0xBB, 0x20, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0x55 };

        public byte[] Cmd = { 0xAA, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0x55 };

    SerialPort sp = new SerialPort();

        public SerialConnect()
        {

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
                return false;
            }
            else
            {
                return true;
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
                    sp.Write(readCmd, 0, readCmd.Length);
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

            for(int i = 1; i < 16; i++)
            {
                checksum ^= writeCmd[i];
            }

            writeCmd[16] = checksum;
            return writeCmd;

            // 수정해야함 -> 
        }

        public RoomInfo GetSerialPacket(byte[] serialRead, byte id_H, byte id_L)
        {
            int originTemp;
            int compareTemp;
            int islock;

            int a, b, c, d, e, f, g, h;
            
            RoomInfo roominfo = new RoomInfo();

            string test;

            serialRead[1] = id_H;
            serialRead[2] = id_L;

            serialRead[16] = FindCheckSum(serialRead);

            sp.Write(serialRead, 0, serialRead.Length);

            System.Threading.Thread.Sleep(100);

            a = sp.ReadByte();
            b = sp.ReadByte();
            c = sp.ReadByte();
            roominfo.ID = b * 100 + c;
            d = sp.ReadByte();
            islock = sp.ReadByte();
            if (islock == 3)
            {
                roominfo.LockOn = false;

            } else if(islock == 7)
            {
                roominfo.LockOn = true;
            }

            originTemp = sp.ReadByte();
            compareTemp = sp.ReadByte();

            roominfo.NowTemp = originTemp;
            roominfo.SetTemp = compareTemp;

            if(compareTemp>originTemp)
            {
                roominfo.HeaterOn = true;
            } else
            {
                roominfo.HeaterOn = false;
            }
            
            for(int i = 0; i < 11; i++)
            {
                sp.ReadByte();
            }
            /*
            MessageBox.Show(" 테스트" + 
                a + " " + b + " " + c + " " + d + " " + islock + " " + originTemp + " " + compareTemp + " "
                + sp.ReadByte() + " " 
                + sp.ReadByte() + " " + sp.ReadByte() + " " + sp.ReadByte() + " " + sp.ReadByte() + " " 
                + sp.ReadByte() + " " + sp.ReadByte() + " " + sp.ReadByte() + " " + sp.ReadByte() + " " 
                + sp.ReadByte() + " " + sp.ReadByte() + " " );
                */

            sp.DiscardInBuffer();
            return roominfo;
        }

        public void setSerialPacket(byte[] serialCommand ,byte id_H, byte id_L)
        {
            serialCommand[1] = id_H;
            serialCommand[2] = id_L;

            serialCommand[16] = FindCheckSum(serialCommand);

            sp.Write(serialCommand, 0, serialCommand.Length);
            sp.DiscardInBuffer();
            System.Threading.Thread.Sleep(200);
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
    }
}
