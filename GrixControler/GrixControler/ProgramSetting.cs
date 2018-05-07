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
        MainForm main;

        SQLiteConnection dbConn = new SQLiteConnection(@"Data Source=" + Application.StartupPath + @"\GrixDB" + @"\grixdb.db");

        SQLiteCommand command;

        SQLiteDataReader rdr;

        String sql;

        int result;

        int row;
        
        public ProgramSetting(MainForm main)
        {
            main.ThreadPause();
            InitializeComponent();

            roomGridView.RowHeadersWidth = 20;

            string[] portsArray = SerialPort.GetPortNames();

            foreach (string portNumber in portsArray)
            {
                portCombx.Items.Add(portNumber);
            }
            portCombx.Text = portsArray[0];

            this.main = main;
        }
        

        private void ProgramSetting_Load(object sender, EventArgs e)
        {

            dbConn.Open();

            show_roomGridView();
        }
        


        private void confirmButton_click(object sender, EventArgs e)
        {
            if (main.serialConnect.CheckPortOpen())
            {
                main.serialConnect = new SerialConnect(portCombx.Text);
            }
            
            //SQL
            row = roomGridView.RowCount;
            
            int scalarNum;

            SQLExcute("delete from idTable");
            SQLExcute("update sqlite_sequence set seq = 0 where name = 'idTable'");


            try
            {
                for (int i = 0; i < row-1; i++)
                {
                   
                        sql = "insert into idTable(roomID,roomNum) Values(\'" +
                            roomGridView.Rows[i].Cells[1].FormattedValue.ToString() + "\',\'" +
                            roomGridView.Rows[i].Cells[2].FormattedValue.ToString() + "\')";
                    SQLExcute(sql);
                    
                }
                
            }
            catch(Exception er)
            {
                MessageBox.Show("SQLite3 Database Connection Error -> " + er.Message);
            }

           dbConn.Close();
            

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

        public void SQLExcute(String sql)
        {
            command = new SQLiteCommand(sql, dbConn);
            result = command.ExecuteNonQuery();
        }

        private void roomGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void roomGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void roomGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            Int32 selectedColumnCount = roomGridView.Columns.GetColumnCount(DataGridViewElementStates.Selected);

            if (selectedColumnCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedColumnCount; i++)
                {
                    sb.Append("Column: ");
                    sb.Append(roomGridView.SelectedColumns[i].Index
                        .ToString());
                    sb.Append(Environment.NewLine);
                }

                sb.Append("Total: " + selectedColumnCount.ToString());
                MessageBox.Show(sb.ToString(), "Selected Columns");
            }
        */    
        }

        public void show_roomGridView()
        {
           
            if (roomGridView.RowCount > 1)
            {
                int count = roomGridView.RowCount;

                for (int i = 1; i <= count - 1; i++)

                {
                    roomGridView.Rows.RemoveAt(0);
                }

            }

            try
            {
                sql = "select * from idTable";

                command = new SQLiteCommand(sql, dbConn);

                rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    roomGridView.Rows.Add(rdr["groupNum"], rdr["roomID"], rdr["roomNum"]);
                }
                rdr.Close();

            }
            catch (Exception er)
            {
                MessageBox.Show("SQLite3 Database Connection Error -> " + er.Message);
            }
             MessageBox.Show(roomGridView.RowCount.ToString());

        }

        private void apply_btn_Click(object sender, EventArgs e)
        {
            if (!main.serialConnect.CheckPortOpen())
            {
                main.serialConnect = new SerialConnect(portCombx.Text);
            }

            //SQL
            row = roomGridView.RowCount;

            int scalarNum;

            SQLExcute("delete from idTable");
            SQLExcute("update sqlite_sequence set seq = 0 where name = 'idTable'");


            try
            {
                for (int i = 0; i < row - 1; i++)
                {

                    sql = "insert into idTable(roomID,roomNum) Values(\'" +
                        roomGridView.Rows[i].Cells[1].FormattedValue.ToString() + "\',\'" +
                        roomGridView.Rows[i].Cells[2].FormattedValue.ToString() + "\')";
                    SQLExcute(sql);

                }

            }
            catch (Exception er)
            {
                MessageBox.Show("SQLite3 Database Connection Error -> " + er.Message);
            }

            show_roomGridView();
        }

        private void ProgramSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.ThreadResume();
        }
    }


    /**
     * 남은 기능
     * 똑같이 옆에 값 입력되게하는것
     * 행이 늘어날때마다 default값 넣는것
     * */
}
