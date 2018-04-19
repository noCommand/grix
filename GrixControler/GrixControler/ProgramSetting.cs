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
using System.Data.SQLite;

namespace GrixControler
{
    public partial class ProgramSetting : Form
    {
        SerialPort sp = new SerialPort();
    
        //SQLiteConnection dbConn = new SQLiteConnection(@"Data Source=" + Application.StartupPath + @"\GrixDB" + @"\grixdb.db");

        //SQLiteCommand command;

       // SQLiteDataReader rdr;

        String sql;
        int result;

        int row;

        public ProgramSetting()
        {
            InitializeComponent();

            roomGridView.RowHeadersWidth = 20;

            string[] portsArray = SerialPort.GetPortNames();
            foreach (string portNumber in portsArray)
            {
                portCombx.Items.Add(portNumber);
            }

        }
        

        private void ProgramSetting_Load(object sender, EventArgs e)
        {

            //dbConn.Open();

            /*
            string sql;
            SQLiteCommand command;
            int result;
            sql = "create table if not exists idTable(groupNum int, roomID int, roomNum int)";
            command = new SQLiteCommand(sql, dbConn);
            result = command.ExecuteNonQuery();

            dbConn.Close();
            */
        }
        


        private void confirmButton_click(object sender, EventArgs e)
        {
            SerialConnect sc = new SerialConnect(portCombx.Text); //연결실패시
            
            row = roomGridView.RowCount; 

            //SQL
            /*
            try
            {
                for (int i = 0; i < row; i++)
                {
                    sql = "select exists(select * from idTable where roomID = " +
                        roomGridView.Rows[i].Cells[1].FormattedValue.ToString() +
                        ", roomNum = " +
                        roomGridView.Rows[i].Cells[2].FormattedValue.ToString();

                    command = new SQLiteCommand(sql, dbConn);
                    result = command.ExecuteNonQuery();

                    if (result.ToString().Equals("0"))
                    {
                        sql = "insert into idTable Valuse(" +
                            "roomGridView.Rows[i].Cells[1].FormattedValue.ToString()," +
                            "roomGridView.Rows[i].Cells[2].FormattedValue.ToString())";
                        command = new SQLiteCommand(sql, dbConn);
                    }

                }
                
            }
            catch(Exception er)
            {
                MessageBox.Show("SQLite3 Database Connection Error -> " + er.Message);
            }

           dbConn.Close();

            */

            /*
            //???
            sp.PortName = portCombx.Text;
            sp.BaudRate = 38400;

            try
            {
                sp.Close();
                if (sp.IsOpen)
                    MessageBox.Show(sp.IsOpen.ToString() + "열림");
                else
                    MessageBox.Show(sp.IsOpen.ToString());

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            */
        }



        private void cancelButton_click(object sender, EventArgs e)
        {

            //dbConn.Close();
            
        }
        
    }
}
