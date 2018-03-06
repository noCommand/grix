using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.IO;
using System.Security.Permissions;
using System.Security;
using System.Security.Principal;
using System.Diagnostics;

namespace GrixControler
{
    public partial class MainForm : Form
    {
        SqliteConnect sqliteconnect;
        SerialConnect serialConnect;

        public MainForm()
        {
            InitializeComponent();

            serialConnect = new SerialConnect();
            serialConnect.AutoConnect();
            /* 현재 위치에서 상위폴더로 올라감
            System.IO.DirectoryInfo diPa = System.IO.Directory.GetParent(filePath);
            diPa = System.IO.Directory.GetParent(diPa.ToString());
            diPa = System.IO.Directory.GetParent(diPa.ToString());
            */


            /*  폴더 권한설정
            FileSecurity fsSecurity = File.GetAccessControl(di.ToString());
            fsSecurity.AddAccessRule(new FileSystemAccessRule("NETWORK SERVICE", FileSystemRights.FullControl,
                AccessControlType.Allow));
            File.SetAccessControl(di.ToString(), fsSecurity);
            */

            try
            {
                sqliteconnect = new SqliteConnect();
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

      
     

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProgramSetting pgset = new ProgramSetting();
            pgset.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void customButton2_Load(object sender, EventArgs e)
        {

        }

        private void AdminSet_Click(object sender, EventArgs e)
        {
            RoomSetting rmset = new RoomSetting();
            rmset.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialConnect.portClose();
        }
    }
}
