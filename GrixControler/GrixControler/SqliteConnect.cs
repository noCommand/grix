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

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(dbPath);
            
            if (di.Exists == false)
            {
                di.Create();
            }
            
            SQLiteConnection.CreateFile(dbPath + @"\grixdb.db");
            
            SQLiteConnection dbConn = new SQLiteConnection(@"Data Source=" + dbPath + @"\grixdb.db");
            dbConn.Open();
            
            
            string sql = "create table idTable(roomID int, roomNum int)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            int result = command.ExecuteNonQuery();

            
            sql = "create index idx01 on idTable(roomID)";
            command = new SQLiteCommand(sql, dbConn);
            result = command.ExecuteNonQuery();
            
            
            sql = "insert into idTable(roomID, roomNum) values (1000,2000)";
            command = new SQLiteCommand(sql, dbConn);
            result = command.ExecuteNonQuery();
            
        }
        
    }
}
