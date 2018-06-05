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
        SerialPort ssp = new SerialPort();


        public SerialConnect(MainForm main)
        {
            this.main = main;
        }

        public SerialConnect(String pttx, MainForm main)
        {
            this.main = main;
            sp.PortName = pttx;
            /** 18.5.11 sp.bandrate에 따라 보내는 속성이 달라진다. 
             * 
             * */


            try
            {
                sp.Open();
                if (sp.IsOpen)
                    main.SetCOMInfo(pttx);
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

        public byte[] setPowerONTempCmd(byte setTemp)
        {
            byte checksum = writeCmd[1];

            writeCmd[3] = 0x31;
            writeCmd[6] = setTemp;

            for (int i = 1; i < 16; i++)
            {
                checksum ^= writeCmd[i];
            }

            writeCmd[16] = checksum;
            return writeCmd;
        }

        public byte[] setTempCmd(byte setTemp)
        {
            byte checksum = writeCmd[1];

            writeCmd[3] = 0x20;
            writeCmd[6] = setTemp;

            for (int i = 1; i < 16; i++)
            {
                checksum ^= writeCmd[i];
            }

            writeCmd[16] = checksum;
            return writeCmd;
            
        }


        public RoomInfo GetFirstSerialPacket(byte[] serialRead, byte id_H, byte id_L)
        {

            ClearReceiveBuffer();

            int originTemp;
            int compareTemp;
            int environment;

            int a, b, c, d, e, f, g, h;

            RoomInfo roominfo = new RoomInfo();

            string test;

            serialRead[1] = id_H;
            serialRead[2] = id_L;
            serialRead[16] = FindCheckSum(serialRead);

            

            try
            {
                sp.Write(serialRead, 0, serialRead.Length);

                System.Threading.Thread.Sleep(300);
                if (sp.BytesToRead == 18)
                {
                    a = sp.ReadByte();
                    b = sp.ReadByte();
                    c = sp.ReadByte();
                    roominfo.ID = b * 100 + c;
                    d = sp.ReadByte();
                    environment = sp.ReadByte();

                    if ((environment & 0x04) == 0x04)
                    {
                        roominfo.LockOn = true;
                    }
                    else roominfo.LockOn = false;

                    if ((environment & 0x01) == 0x01)
                    {
                        roominfo.PowerOn = true;
                    }
                    else roominfo.PowerOn = false;

                    //
                    if ((environment & 0x02) == 0x02)
                    {
                        roominfo.HeaterOn = true;
                    }
                    else roominfo.HeaterOn = false;


                    if ((environment & 0x08) == 0x08)
                    {
                        roominfo.StepOn = true;
                    }
                    else roominfo.StepOn = false;

                    
                    originTemp = sp.ReadByte();
                    compareTemp = sp.ReadByte();

                    roominfo.NowTemp = originTemp.ToString();
                    roominfo.SetTemp = compareTemp.ToString();

                    sp.ReadByte();
                    roominfo.UH = sp.ReadByte();
                    for (int i = 0; i < 2; i++)
                    {
                        sp.ReadByte();
                    }
                    roominfo.TempStep = sp.ReadByte();

                    roominfo.PeriodStep = sp.ReadByte();

                    for (int i = 0; i < 3; i++)
                    {
                        sp.ReadByte();
                    }

                    roominfo.CheckSum = sp.ReadByte();
                    roominfo.ConnectOn = true;

                    sp.ReadByte();
                    ClearReceiveBuffer();
                    roominfo.Count = 0;

                    return roominfo;
                }
                else
                {
                    foreach (RoomInfo info in main.roomInfoList)
                    {
                        if (info.ID == id_H * 100 + id_L)
                        {
                            roominfo = info;
                        }
                    }
                    roominfo.ID = id_H * 100 + id_L;
                    roominfo.SetTemp = " ";
                    roominfo.NowTemp = "X";
                    roominfo.DisConnectCount = 3;
                    roominfo.ConnectOn = false;
                    ClearReceiveBuffer();
                    return roominfo;


                }
            }
            catch (InvalidOperationException ioe)
            {
                return roominfo;
            }
        }


        public RoomInfo GetSerialPacket(byte[] serialRead, byte id_H, byte id_L)
        {
            ClearReceiveBuffer();

            int originTemp;
            int compareTemp;
            int environment;

            int a, b, c, d, e, f, g, h;

            RoomInfo roominfo = new RoomInfo();

            string test;

            serialRead[1] = id_H;
            serialRead[2] = id_L;

            serialRead[16] = FindCheckSum(serialRead);
           

            try
            {
                sp.Write(serialRead, 0, serialRead.Length);

                System.Threading.Thread.Sleep(300);
                if (sp.BytesToRead == 18)
                {
                    a = sp.ReadByte();
                    b = sp.ReadByte();
                    c = sp.ReadByte();
                    roominfo.ID = b * 100 + c;
                    d = sp.ReadByte();
                    environment = sp.ReadByte();

                    if ((environment & 0x04) == 0x04)
                    {
                        roominfo.LockOn = true;
                    }
                    else roominfo.LockOn = false;

                    if ((environment & 0x01) == 0x01)
                    {
                        roominfo.PowerOn = true;
                    }
                    else roominfo.PowerOn = false;

                    //
                    if ((environment & 0x02) == 0x02)
                    {
                        roominfo.HeaterOn = true;
                    }
                    else roominfo.HeaterOn = false;


                    if ((environment & 0x08) == 0x08)
                    {
                        roominfo.StepOn = true;
                    }
                    else roominfo.StepOn = false;
                    

                    originTemp = sp.ReadByte();
                    compareTemp = sp.ReadByte();

                    roominfo.NowTemp = originTemp.ToString();
                    roominfo.SetTemp = compareTemp.ToString();

                    sp.ReadByte();
                    roominfo.UH = sp.ReadByte();
                    for (int i = 0; i < 2; i++)
                    {
                        sp.ReadByte();
                    }
                    roominfo.TempStep = sp.ReadByte();

                    roominfo.PeriodStep = sp.ReadByte();

                    for (int i = 0; i < 3; i++)
                    {
                        sp.ReadByte();
                    }

                    roominfo.CheckSum = sp.ReadByte();
                    roominfo.ConnectOn = true;

                    sp.ReadByte();
                    ClearReceiveBuffer();
                    roominfo.Count = 0;

                    return roominfo;
                }
                else
                {
                    foreach (RoomInfo info in main.roomInfoList)
                    {
                        if (info.ID == id_H * 100 + id_L)
                        {
                            roominfo = info;
                        }
                    }
                    roominfo.Count = 1;
                    roominfo.ConnectOn = false;
                    ClearReceiveBuffer();
                    return roominfo;
                }
            }
            catch (InvalidOperationException ioe)
            {
                return roominfo;
            }
        }

        public RoomInfo GetSerialPacketForResult(byte[] serialCommand, byte cmd, byte setTemp, byte setStep, byte id_H, byte id_L)
        {

            ClearReceiveBuffer();

            int originTemp;
            int compareTemp;
            int environment;

            int a, b, c, d, e, f, g, h;

            RoomInfo roominfo = new RoomInfo();


            serialCommand[1] = id_H;
            serialCommand[2] = id_L;
            serialCommand[3] = cmd;
            serialCommand[6] = setTemp;
            serialCommand[11] = setStep;

            serialCommand[16] = FindCheckSum(serialCommand);

            try
            {
                sp.Write(serialCommand, 0, serialCommand.Length);
                System.Threading.Thread.Sleep(300);
                if (sp.BytesToRead == 18)
                {
                    a = sp.ReadByte();
                    b = sp.ReadByte();
                    c = sp.ReadByte();
                    roominfo.ID = b * 100 + c;
                    d = sp.ReadByte();
                    environment = sp.ReadByte();

                    if ((environment & 0x04) == 0x04)
                    {
                        roominfo.LockOn = true;
                    }
                    else roominfo.LockOn = false;

                    if ((environment & 0x01) == 0x01)
                    {
                        roominfo.PowerOn = true;
                    }
                    else roominfo.PowerOn = false;

                    //
                    if ((environment & 0x02) == 0x02)
                    {
                        roominfo.HeaterOn = true;
                    }
                    else roominfo.HeaterOn = false;


                    if ((environment & 0x08) == 0x08)
                    {
                        roominfo.StepOn = true;
                    }
                    else roominfo.StepOn = false;


                    originTemp = sp.ReadByte();
                    compareTemp = sp.ReadByte();

                    roominfo.NowTemp = originTemp.ToString();
                    roominfo.SetTemp = compareTemp.ToString();

                    sp.ReadByte();
                    roominfo.UH = sp.ReadByte();
                    for (int i = 0; i < 2; i++)
                    {
                        sp.ReadByte();
                    }
                    roominfo.TempStep = sp.ReadByte();

                    roominfo.PeriodStep = sp.ReadByte();

                    for (int i = 0; i < 3; i++)
                    {
                        sp.ReadByte();
                    }

                    roominfo.CheckSum = sp.ReadByte();
                    roominfo.ConnectOn = true;

                    sp.ReadByte();
                    ClearReceiveBuffer();
                    return roominfo;
                }
                else
                {
                    foreach (RoomInfo info in main.roomInfoList)
                    {
                        if (info.ID == id_H * 100 + id_L)
                        {
                            roominfo = info;
                        }
                    }
                    roominfo.ConnectOn = false;
                    ClearReceiveBuffer();
                    return roominfo;
                }
            }
            catch (InvalidOperationException ioe)
            {
                return roominfo;
                //프로그램 종료시에만 발생
            }
        }


        public RoomInfo GetGroupSerialPacket(byte[] serialCommand, byte cmd, byte setTemp, byte id_H, byte id_L)
        {

            ClearReceiveBuffer();

            int originTemp;
            int compareTemp;
            int environment;

            int a, b, c, d, e, f, g, h;

            RoomInfo roominfo = new RoomInfo();
            

            serialCommand[1] = id_H;
            serialCommand[2] = id_L;
            serialCommand[3] = cmd;
            serialCommand[6] = setTemp;
            serialCommand[16] = FindCheckSum(serialCommand);
            
            try
            {
                sp.Write(serialCommand, 0, serialCommand.Length);
                System.Threading.Thread.Sleep(300);
                if (sp.BytesToRead == 18)
                {
                    a = sp.ReadByte();
                    b = sp.ReadByte();
                    c = sp.ReadByte();
                    roominfo.ID = b * 100 + c;
                    d = sp.ReadByte();
                    environment = sp.ReadByte();

                    if ((environment & 0x04) == 0x04)
                    {
                        roominfo.LockOn = true;
                    }
                    else roominfo.LockOn = false;

                    if ((environment & 0x01) == 0x01)
                    {
                        roominfo.PowerOn = true;
                    }
                    else roominfo.PowerOn = false;

                    //
                    if ((environment & 0x02) == 0x02)
                    {
                        roominfo.HeaterOn = true;
                    }
                    else roominfo.HeaterOn = false;


                    if ((environment & 0x08) == 0x08)
                    {
                        roominfo.StepOn = true;
                    }
                    else roominfo.StepOn = false;

                    originTemp = sp.ReadByte();
                    compareTemp = sp.ReadByte();
                    roominfo.NowTemp = originTemp.ToString();
                    roominfo.SetTemp = compareTemp.ToString();

                    sp.ReadByte();
                    roominfo.UH = sp.ReadByte();
                    for (int i = 0; i < 2; i++)
                    {
                        sp.ReadByte();
                    }
                    roominfo.TempStep = sp.ReadByte();

                    roominfo.PeriodStep = sp.ReadByte();

                    for (int i = 0; i < 3; i++)
                    {
                        sp.ReadByte();
                    }

                    roominfo.CheckSum = sp.ReadByte();
                    roominfo.ConnectOn = true;
                    sp.ReadByte();
                    ClearReceiveBuffer();
                    return roominfo;
                }
                else
                {
                    foreach (RoomInfo info in main.roomInfoList)
                    {
                        if (info.ID == id_H * 100 + id_L)
                        {
                            roominfo = info;
                        }
                    }
                    roominfo.ConnectOn = false;
                    ClearReceiveBuffer();
                    return roominfo;
                }
            }
            catch (InvalidOperationException ioe)
            {
                return roominfo;
                //프로그램 종료시에만 발생
            }
        }

        public RoomInfo GetAdminSerialPacket(byte[] serialCommand,byte df,byte uh,byte ul,byte ht, byte pd,byte od,byte tc, byte id_H, byte id_L)
        {

            ClearReceiveBuffer();

            int originTemp;
            int compareTemp;
            int environment;

            int a, b, c, d, e, f, g, h;

            RoomInfo roominfo = new RoomInfo();


            serialCommand[1] = id_H;
            serialCommand[2] = id_L;
            serialCommand[4] = 0x20;
            serialCommand[7] = df;
            serialCommand[8] = uh;
            serialCommand[9] = ul;
            serialCommand[10] = ht;
            serialCommand[12] = pd;
            serialCommand[13] = od;
            serialCommand[14] = tc;
            
            serialCommand[16] = FindCheckSum(serialCommand);

            try
            {
                sp.Write(serialCommand, 0, serialCommand.Length);
                System.Threading.Thread.Sleep(300);
                if (sp.BytesToRead == 18)
                {
                    a = sp.ReadByte();
                    b = sp.ReadByte();
                    c = sp.ReadByte();
                    roominfo.ID = b * 100 + c;
                    d = sp.ReadByte();
                    environment = sp.ReadByte();

                    if ((environment & 0x04) == 0x04)
                    {
                        roominfo.LockOn = true;
                    }
                    else roominfo.LockOn = false;

                    if ((environment & 0x01) == 0x01)
                    {
                        roominfo.PowerOn = true;
                    }
                    else roominfo.PowerOn = false;

                    //
                    if ((environment & 0x02) == 0x02)
                    {
                        roominfo.HeaterOn = true;
                    }
                    else roominfo.HeaterOn = false;


                    if ((environment & 0x08) == 0x08)
                    {
                        roominfo.StepOn = true;
                    }
                    else roominfo.StepOn = false;

                    originTemp = sp.ReadByte();
                    compareTemp = sp.ReadByte();
                    roominfo.NowTemp = originTemp.ToString();
                    roominfo.SetTemp = compareTemp.ToString();

                    sp.ReadByte();
                    roominfo.UH = sp.ReadByte();
                    for (int i = 0; i < 2; i++)
                    {
                        sp.ReadByte();
                    }
                    roominfo.TempStep = sp.ReadByte();

                    roominfo.PeriodStep = sp.ReadByte();

                    for (int i = 0; i < 3; i++)
                    {
                        sp.ReadByte();
                    }

                    roominfo.CheckSum = sp.ReadByte();
                    roominfo.ConnectOn = true;
                    sp.ReadByte();
                    ClearReceiveBuffer();
                    return roominfo;
                }
                else
                {
                    foreach (RoomInfo info in main.roomInfoList)
                    {
                        if (info.ID == id_H * 100 + id_L)
                        {
                            roominfo = info;
                        }
                    }
                    roominfo.ConnectOn = false;
                    ClearReceiveBuffer();
                    return roominfo;
                }
            }
            catch (InvalidOperationException ioe)
            {
                return roominfo;
                //프로그램 종료시에만 발생
            }
        }

        
        public byte FindCheckSum(byte[] cmd)
        {
            byte checksum = cmd[1];
            for (int i = 2; i < 16; i++)
            {
                checksum ^= cmd[i];
            }
            return checksum;
        }

        public void ClearReceiveBuffer()
        {
            try
            {
                sp.DiscardInBuffer();
            }
            catch (InvalidOperationException e)
            {

            }
        }

        public void ClearSendBuffer()
        {
            try
            {
                sp.DiscardOutBuffer();
            }
            catch (InvalidOperationException e)
            {

            }
        }

        public void spLength()
        {
            MessageBox.Show("Length : " + sp.BytesToRead.ToString());
        }

        public String GetPortName()
        {
            if (sp.PortName == null)
            {
                return "COM1";
            }

            else
            {
                return sp.PortName;
            }
        }
    }
}
