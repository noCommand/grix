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
    class SqliteInit
    {
     
        public SqliteInit()
        {
            string dbPath = Application.StartupPath + @"\GrixDB"; //현재 경로 기반
            string sql;
            SQLiteCommand command;
            int result;
            
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(dbPath);
            
            if (di.Exists == false)
            {
                di.Create();
            }

            try
            {
                SQLiteConnection dbConn = new SQLiteConnection(@"Data Source=" + dbPath + @"\grixdb.db");
                dbConn.Open();
                SQLiteConnection.CreateFile(dbPath + @"\grixdb.db");


                sql = "create table if not exists idTable(groupNum int auto_increment, roomID string, roomNum string)";
                command = new SQLiteCommand(sql, dbConn);
                result = command.ExecuteNonQuery();

                dbConn.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("SQLite3 Database Connection Error -> " + e.Message);
            }
           
            
            /**
             * 18.04.19  16:03 
             * programSetting sql 데이터 삽입 코딩중
             * 현재 cs에서
             * 해당 db 파일 다른 프로세스 사용중 엑세스 불가 에러 발생
             * 
             * */

        }
        
        

    }
}
