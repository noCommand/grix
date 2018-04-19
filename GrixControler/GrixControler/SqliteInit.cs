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
            
                SQLiteConnection dbConn = new SQLiteConnection(@"Data Source=" + dbPath + @"\grixdb.db");
                dbConn.Open();
                SQLiteConnection.CreateFile(dbPath + @"\grixdb.db");


                sql = "create table if not exists idTable(groupNum int auto_increment, roomID string, roomNum string)";
                command = new SQLiteCommand(sql, dbConn);
                result = command.ExecuteNonQuery();
            
           
            
            /**
             * 18.04.19  16:03 
             * programSetting sql 데이터 삽입 코딩중
             * 현재 cs에서
             * 해당 db 파일 다른 프로세스 사용중 엑세스 불가 에러 발생
             * 
             * process explorer에서는 발견하지 못함
             * 파일을 삭제하고 디버깅해도 똑같음
             * 
             * ???? mainform에서 catch문의 exception이 실행됬는데, try문에 있는 sqliteinit이 실행, 결국 db폴더, 파일이 생성됨 -> ?? 
             *
             * */

        }
        
        

    }
}
