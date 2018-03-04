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
            foreach(string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                try
                {
                    sp.PortName = s;
                    sp.Open();
                    sp.Write("장비 접속 확인 명령");
                    System.Threading.Thread.Sleep(100);
                    if(sp.BytesToRead != 0)
                    {
                        byte[] data = new byte[sp.BytesToRead];
                        sp.Read(data, 0, sp.BytesToRead);
                        if(data.Equals("장비 접속 수신 패킷"))
                        {
                            break;
                        }
                    }
                } catch(Exception e) { }
            }
            if (sp.IsOpen)
            {
                MessageBox.Show("포트연결실패");
            }
            else
            {
                MessageBox.Show("포트연결성공");
            }
        }

        public void portClose()
        {
            sp.Close();
        }
    
    }
}
