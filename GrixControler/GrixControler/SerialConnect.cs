using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace GrixControler
{
    class SerialConnect
    {
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


        public void AutoConnect()
        {
            byte[] ckport = { 0xAA, 0x00, 0x01, 0x00, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0x01, 0x55 };

            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                try
                {
                    sp.PortName = s;
                    sp.Open();
                    sp.Write(ckport, 0, ckport.Length);
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

        public void portClose()
        {
            sp.Close();
        }
        public RoomInfo getSerialPacket()
        {
            RoomInfo roominfo = new RoomInfo();

            string test;
            
            byte[] ckport = { 0xAA, 0x00, 0x01, 0x00, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0x01, 0x55 };

            sp.Write(ckport, 0, ckport.Length);

            System.Threading.Thread.Sleep(100);

            sp.ReadByte();
            roominfo.ID = sp.ReadByte() * 100 + sp.ReadByte();
            sp.ReadByte();
            sp.ReadByte();
            roominfo.NowTemp = sp.ReadByte();
            roominfo.SetTemp = sp.ReadByte();

            test = roominfo.SetTemp.ToString();

            MessageBox.Show(" 테스트" + test
                + sp.ReadByte() + " " 
                + sp.ReadByte() + " " + sp.ReadByte() + " " + sp.ReadByte() + " " + sp.ReadByte() + " " 
                + sp.ReadByte() + " " + sp.ReadByte() + " " + sp.ReadByte() + " " + sp.ReadByte() + " " 
                + sp.ReadByte() + " " + sp.ReadByte() + " " );

            return roominfo;
        }
    }
}
