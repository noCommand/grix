using System;
using System.Data.SQLite;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;

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

        public Thread thread_Serial;

        bool gridviewInitComplete = false;

        bool gridviewValueChagne = true;

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
            portCombx.Text = main.GetCOMInfo();

            if (main.SFExist)
            {
                specialFunctionCheckBox.Checked = true;
            }

            this.main = main;
        }
        

        private void ProgramSetting_Load(object sender, EventArgs e)
        {
            dbConn.Open();

            show_roomGridView();
            gridviewInitComplete = true;
        }
        


        private void confirmButton_click(object sender, EventArgs e)
        {
            if(specialFunctionCheckBox.Checked == true && !main.specificFunctionExist)
            {
                insertSpecificFunction();
                main.specificFunctionExist = true;
            }
            else if(specialFunctionCheckBox.Checked == false)
            {
                deleteSpecificFunction();
                main.specificFunctionExist = false;
                main.SFExist = main.isSpecificFunctionExistInDB();
            }

            /* 18.5.12
           * 시리얼포트 수동연결 가능
           * */
            if (main.serialConnect.GetPortName() != portCombx.Text || !main.serialConnect.CheckPortOpen())
            {
                main.serialConnect.PortClose();
                main.serialConnect = new SerialConnect(portCombx.Text, main);
                main.ResetAllVariable();
            }


            this.Close();
            
            //SQL
            /*
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
            this.Close();
            //dbConn.Close();
            
        }

        public void SQLExcute(String sql, SQLiteTransaction tr)
        {
            command.Transaction = tr;
            command = new SQLiteCommand(sql, dbConn);
            result = command.ExecuteNonQuery();
        }
        
    

        public void show_roomGridView()
        {

            SetGridViewClear();

            try
            {
                sql = "select * from idTable where roomid not in(select roomid from idtable where roomid = \'9999\')";

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
             //MessageBox.Show(roomGridView.RowCount.ToString());

        }
        

        private void ProgramSetting_FormClosed(object sender, FormClosedEventArgs e)
        {



            //MessageBox.Show(main.serialConnect.GetPortName());
            dbConn.Close();
            main.ThreadResume();
            
        }

        

        private void SetRoomID()
        {
            //SQL
            row = roomGridView.RowCount;

            int scalarNum;
            using (SQLiteTransaction tr = dbConn.BeginTransaction())
            {
                /** 18.5.23 
                 *  sqlitetransaction을 사용해야 insert연산이 빨라진다. 
                 *  
                 *  이유는..? 
                 *  
                 * */

                SQLExcute("delete from idTable", tr);
                SQLExcute("update sqlite_sequence set seq = 0 where name = 'idTable'", tr);

                try
                {

                    for (int i = 0; i < row - 1; i++)
                    {

                        sql = "insert into idTable(roomID,roomNum) Values(\'" +
                            roomGridView.Rows[i].Cells[1].FormattedValue.ToString() + "\',\'" +
                            roomGridView.Rows[i].Cells[2].FormattedValue.ToString() + "\')";
                        SQLExcute(sql, tr);

                    }


                }
                catch (Exception er)
                {
                    MessageBox.Show("SQLite3 Database Connection Error -> " + er.Message);
                }
                tr.Commit();
            }

            show_roomGridView();
            gridviewInitComplete = true;
        }

        private void insertSpecificFunction()
        {
            int scalarNum;

            using (SQLiteTransaction tr = dbConn.BeginTransaction())
            {
                try
                {
                        sql = "insert into idTable(roomID,roomNum) Values(\'9999\',\'9999\')";
                        SQLExcute(sql, tr);
                }
                catch (Exception er)
                {
                    MessageBox.Show("SQLite3 Database Connection Error -> " + er.Message);
                }
                tr.Commit();
            }
        }

        private void deleteSpecificFunction()
        {
            int scalarNum;

            using (SQLiteTransaction tr = dbConn.BeginTransaction())
            {
                try
                {
                    sql = "delete from idTable where roomID in (select roomid from idtable where roomid = \'9999\')";
                    SQLExcute(sql, tr);
                }
                catch (Exception er)
                {
                    MessageBox.Show("SQLite3 Database Connection Error -> " + er.Message);
                }
                tr.Commit();
            }
        }

        private void roomGridView_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void reSetButton_Click(object sender, EventArgs e)
        {
            SetGridViewClear();
        }

        private void SetGridViewClear()
        {
            if (roomGridView.RowCount > 1)
            {
                int count = roomGridView.RowCount;

                for (int i = 1; i <= count - 1; i++)

                {
                    roomGridView.Rows.RemoveAt(0);
                }

            }
        }

        private void roomGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (gridviewInitComplete)
            {
                try
                {
                    roomGridView.Rows[roomGridView.CurrentCell.RowIndex].Cells[0].Value
                       = Convert.ToInt32(roomGridView.Rows[roomGridView.CurrentCell.RowIndex - 1].Cells[0].Value.ToString()) + 1;
                }
                catch (System.ArgumentOutOfRangeException ae)
                {
                    roomGridView.Rows[0].Cells[0].Value = 1;
                }
            }
        }

        private void roomGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridviewInitComplete)
            {
               
                    if(roomGridView.CurrentCell.ColumnIndex==1)
                    {
                        roomGridView.Rows[roomGridView.CurrentCell.RowIndex].Cells[2].Value =
                        roomGridView.Rows[roomGridView.CurrentCell.RowIndex].Cells[1].Value;
                    }
                
            }
        }

        private void roomGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void roomGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1) 
            {
                int i;
                if (e.FormattedValue != "")
                {
                    if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                    }
                }
            }
        }

        private void roomApplyButton_Click(object sender, EventArgs e)
        {

            gridviewInitComplete = false;
            SetRoomID();
        }

        private void roomGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }
    }


    /**
     * 남은 기능
     * 똑같이 옆에 값 입력되게하는것
     * 행이 늘어날때마다 default값 넣는것
     * */
}
