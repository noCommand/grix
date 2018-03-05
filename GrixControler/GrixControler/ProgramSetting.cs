using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace GrixControler
{
    public partial class ProgramSetting : Form
    {
        SerialPort sp = new SerialPort();

        public ProgramSetting()
        {
            InitializeComponent();
            
            //port 연결 테스트코드 -> serialconnect로 뺄 예정 
            string[] portsArray = SerialPort.GetPortNames();
            foreach (string portNumber in portsArray)
            {
                portCombx.Items.Add(portNumber);
            }
        }

        private void ProgramSetting_Load(object sender, EventArgs e)
        {

        }

        private void portCombx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sp.PortName = portCombx.Text;
            sp.BaudRate = 38400;

            try
            {
                sp.Open();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}
