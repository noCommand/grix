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


            sql = "create table if not exists idTable(groupNum integer primary key autoincrement," +
                " roomID string default \'X\', roomNum string," + 
                " MondayStartTime string Default \'오전0800\', MondayEndTime string Default '오후0800', MondayTemp string default 25," +
                " TuesdayStartTime string Default \'오전0800\', TuesdayEndTime string Default \'오후0800\', TuesdayTemp string default 25," +
                " WednesdayStartTime string Default \'오전0800\', WednesdayEndTime string Default \'오후0800\', WednesdayTemp string default 25," +
                " ThursdayStartTime string Default \'오전0800\', ThursdayEndTime string Default \'오후0800\', ThursdayTemp string default 25," +
                " FridayStartTime string Default \'오전0800\', FridayEndTime string Default \'오후0800\', FridayTemp string default 25," +
                " SaturdayStartTime string Default \'오전0800\', SaturdayEndTime string Default \'오후0800\', SaturdayTemp string default 25," +
                " SundayStartTime string Default \'오전0800\', SundayEndTime string Default \'오후0800\', SundayTemp string default 25," +
                " ReservationStartDay string Default \"\" , ReservationEndDay string Default \"\"" +
                ")";

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
             * -----------------------------------------------------------
             * SQLiteConnection.CreateFile(dbPath + @"\grixdb.db");   ->> 이부분이 sqliteinit으로 수정될때 아래로 내려가서 문제발생했던 것임
             * + 없어도 아래 코드에서 grixdb를 생성해줌
             * SQLiteConnection dbConn = new SQLiteConnection(@"Data Source=" + dbPath + @"\grixdb.db");
             * dbConn.Open();
             * 
             * */

        }



    }
}