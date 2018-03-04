using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Security.Permissions;
using System.Windows.Forms;

namespace GrixControler
{
    class SqliteConnect
    {
        public SqliteConnect()
        {

            string dbPath = Application.StartupPath + @"\GrixDB";
            string sql;
            SQLiteCommand command;
            int result;


            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(dbPath);
            
            if (di.Exists == false)
            {
                di.Create();
            }
            
            SQLiteConnection.CreateFile(dbPath + @"\grixdb.db");
            SQLiteConnection dbConn = new SQLiteConnection(@"Data Source=" + dbPath + @"\grixdb.db");
            dbConn.Open();

            
            sql = "create table if not exists idTable(roomID int, roomNum int)";
            command = new SQLiteCommand(sql, dbConn);
            result = command.ExecuteNonQuery();
            
            
        }
        
    }
}
