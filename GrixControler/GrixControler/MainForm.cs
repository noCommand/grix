using System;
using System.Data.SQLite;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.IO;

namespace GrixControler
{
    public partial class MainForm : Form
    {
        SqliteInit sqliteconnect;

        public SerialConnect serialConnect;

        SQLiteConnection dbConn = new SQLiteConnection(@"Data Source=" + Application.StartupPath + @"\GrixDB" + @"\grixdb.db");

        private ManualResetEvent _pauseEvent = new ManualResetEvent(true);

        SQLiteCommand command;

        SQLiteDataReader rdr;

        String sql;

        int result;

        int check_UI = 1;

        public Thread thread_Serial;
        public Thread thread_UI;
        public Thread thread_GroupInfoSetting;

        RoomView[] roomView;

        RoomInfo ri;

        public String[] roomID;
        public String[] roomName;

        String[] reservationTime_Mon_ON;
        String[] reservationTime_Tues_ON;
        String[] reservationTime_Wednes_ON;
        String[] reservationTime_Thurs_ON;
        String[] reservationTime_Fri_ON;
        String[] reservationTime_Satur_ON;
        String[] reservationTime_Sun_ON;
        
        String[] reservationTime_ON_DAY;

        String[] reservationTime_ON_ID;

        String[] reservationTime_Mon_OFF;
        String[] reservationTime_Tues_OFF;
        String[] reservationTime_Wednes_OFF;
        String[] reservationTime_Thurs_OFF;
        String[] reservationTime_Fri_OFF;
        String[] reservationTime_Satur_OFF;
        String[] reservationTime_Sun_OFF;

        String[] reservationTime_OFF_ID;

        String[] reservationTime_OFF_DAY;

        int[] reservationTime_Mon_TEMP;
        int[] reservationTime_Tues_TEMP;
        int[] reservationTime_Wednes_TEMP;
        int[] reservationTime_Thurs_TEMP;
        int[] reservationTime_Fri_TEMP;
        int[] reservationTime_Satur_TEMP;
        int[] reservationTime_Sun_TEMP;

        int currentCount, defaultCount, compareCount;

        String id_H, id_L;

        int reserveCheck_A = 0;

        int reserveCheck_B = 0;

        public List<RoomInfo> roomInfoList = new List<RoomInfo>();

        private int roominfoControl = 1;

        static readonly object locker = new object();

        private int check = 0;

        private bool view_Handle = true;

        int CheckHour;

        int CheckMin;

        int CheckAllRoomPowerCount = 0;

        String CheckDayOfWeek;

        int checkFirstThread = 0;

        Excel.Application excelApp = null;
        Excel.Workbook wb = null;
        Excel.Worksheet ws = null;

        int excelIndex;

        String saveDay = "";
        int saveHour = 0;
        int saveMin = 0;

        private ScrollPanelMessageFilter filter;

        public List<String> groupID = new List<String>();
        public GroupRoomInfo groupGetInfo = new GroupRoomInfo();
        public AdminInfo adminInfo = new AdminInfo();

        public int viewStartCount = 0;
        public bool roomSet = false;
        public RoomInfo roomInfoSet;

        public bool isGroup = false;
        public bool isAll = false;
        public bool isAdmin = false;

        public bool specificFunctionExist = false;
        public bool SFExist;

        private bool isInit = false;

        int reservationOffCount = 0;
        int reservationOnCount = 0;

        private bool resetViewHandle = true;
        private bool DBViewHandle = true;


        public MainForm()
        {
            InitializeComponent();

            isInit = true;

            SetGroupButton.TabStop = false;

            SetGroupButton.FlatStyle = FlatStyle.Flat;

            SetGroupButton.FlatAppearance.BorderSize = 0;

            SetAllButton.TabStop = false;

            SetAllButton.FlatStyle = FlatStyle.Flat;

            SetAllButton.FlatAppearance.BorderSize = 0;

            SetReservationButton.TabStop = false;

            SetReservationButton.FlatStyle = FlatStyle.Flat;

            SetReservationButton.FlatAppearance.BorderSize = 0;

            SetAdminButton.TabStop = false;

            SetAdminButton.FlatStyle = FlatStyle.Flat;

            SetAdminButton.FlatAppearance.BorderSize = 0;

            serialConnect = new SerialConnect(this);
            //serialConnect.AutoConnect();

            try
            {
                sqliteconnect = new SqliteInit();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            dbConn.Open();

            ExcelInit();

            excelApp = new Excel.Application();
            excelApp.DisplayAlerts = false;
            wb = excelApp.Workbooks.Open(Application.StartupPath + @"\GrixDB" + @"\eventlog.xls");
            ws = wb.Worksheets.get_Item(1) as Excel.Worksheet;

            if (GetCOMInfo() != "COM")
            {
                serialConnect = new SerialConnect(GetCOMInfo(), this);
            }

            SFExist = isSpecificFunctionExistInDB();

            ri = new RoomInfo();

            defaultCount = TupleCount();

            SetRoomIDString(defaultCount);

            SetRoomView(defaultCount, ri);


            thread_Serial = new Thread(SerialThread);
            thread_UI = new Thread(UIThread);

            thread_Serial.IsBackground = true;
            thread_UI.IsBackground = true;

            thread_Serial.Start();
            thread_UI.Start();


        }

        public void ThreadPause()
        {
            _pauseEvent.Reset();
            roominfoControl = 0;
        }

        public void ThreadResume()
        {
            Thread.Sleep(300);
            _pauseEvent.Set();
            roominfoControl = 1;
        }

        private void ExcelInit()
        {
            try
            {
                if (!File.Exists(Application.StartupPath + @"\GrixDB" + @"\eventlog.xls"))
                {
                    // Excel 첫번째 워크시트 가져오기                
                    excelApp = new Excel.Application();
                    wb = excelApp.Workbooks.Add();
                    ws = wb.Worksheets.get_Item(1) as Excel.Worksheet;

                    ws.Cells[1, 1] = "시간";
                    ws.Cells[1, 2] = "호실";
                    ws.Cells[1, 3] = "내용";
                    ws.Cells[1, 4] = 2;
                    ws.Cells[1, 5] = "COM";

                    // 엑셀파일 저장
                    wb.SaveAs(Application.StartupPath + @"\GrixDB" + @"\eventlog.xls", Excel.XlFileFormat.xlWorkbookNormal, ReadOnlyRecommended: false);
                    wb.Close(true);
                    excelApp.Quit();
                }
            }
            finally
            {
                // Clean up
                ReleaseExcelObject(ws);
                ReleaseExcelObject(wb);
                ReleaseExcelObject(excelApp);
            }
        }

        private static void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }
        /*
        public void MainThread()
        {
            while (_pauseEvent.WaitOne())
            { 
                try
                {
                    thread_Serial = new Thread(SerialThread);
                    thread_UI = new Thread(UIThread);

                    thread_Serial.IsBackground = true;
                    thread_UI.IsBackground = true;

                    thread_Serial.Start();
                    thread_UI.Start();
                }
                catch (InvalidOperationException e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }
        */

        private void UIThread()
        {
            while (_pauseEvent.WaitOne()) //false가 되면 while문을 빠져나가겠지 
            {
                //MessageBox.Show(serialConnect.GetPortName());
                if (serialConnect.CheckPortOpen())
                {
                    try
                    {
                        //MessageBox.Show("roomview" + roomView.Length + "roomInfoList" + roomInfoList.Count.ToString());
                        //MessageBox.Show(serialConnect)
                        UpdateRoomView(currentCount);
                    }
                    catch (Exception e)
                    {

                        MessageBox.Show(e.ToString());
                    }
                }
            }
        }
        
      

        private void SerialThread()
        {

            while (_pauseEvent.WaitOne())
            {
                bool isAllRoomPowerOn = false;

                if (serialConnect.CheckPortOpen())
                {
                    //MessageBox.Show(thread_UI.IsAlive.ToString());
                    compareCount = TupleCount();
                    SetRoomIDString(compareCount);

                    if (defaultCount == compareCount && CheckRoomIDChange(compareCount))
                    {
                        currentCount = defaultCount;
                    }
                    else
                    {
                        currentCount = compareCount;
                        view_Handle = false;
                        RemoveRoomView(defaultCount, currentCount);
                    }

                    if (check == 0)
                    {
                        /** 포트 재설정할때 어떻게 add할껀지 생각해야함
                         * 
                         * */
                        RoomInfo firstSpecificCheck = new RoomInfo();

                        for (int nowCount = 0; nowCount < currentCount; nowCount++)
                        {
                            if (roomID[nowCount].Length == 4)
                            {
                                id_H = roomID[nowCount].Substring(0, 2);
                                id_L = roomID[nowCount].Substring(2, 2);
                            }
                            else if (roomID[nowCount].Length == 3)
                            {
                                id_H = roomID[nowCount].Substring(0, 1);
                                id_L = roomID[nowCount].Substring(1, 2);
                            }
                            else
                            {
                                id_H = "0";
                                id_L = roomID[nowCount];
                            }
                            if (!(id_H == "99" && id_L == "99"))
                            {
                                firstSpecificCheck = serialConnect.GetFirstSerialPacket(serialConnect.readCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L));
                                roomInfoList.Add(firstSpecificCheck);
                                if (firstSpecificCheck.DisConnectCount < 3)
                                {
                                    isAllRoomPowerOn |= firstSpecificCheck.PowerOn;
                                }
                            }
                        }
                        check = 1;
                    }
                    else
                    {
                        for (int nowCount = viewStartCount ; nowCount < currentCount; nowCount++)
                        {

                            if (roomID[nowCount].Length == 4)
                            {
                                id_H = roomID[nowCount].Substring(0, 2);
                                id_L = roomID[nowCount].Substring(2, 2);
                            }
                            else if (roomID[nowCount].Length == 3)
                            {
                                id_H = roomID[nowCount].Substring(0, 1);
                                id_L = roomID[nowCount].Substring(1, 2);
                            }
                            else
                            {
                                id_H = "0";
                                id_L = roomID[nowCount];
                            }
                            if (!(id_H == "99" && id_L == "99"))
                            {
                                if (roomInfoList.Count < nowCount + 1)
                                {
                                    roomInfoList.Add(serialConnect.GetFirstSerialPacket(serialConnect.readCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L)));
                                }

                                if (roomView.Length < roomInfoList.Count)
                                {
                                    roomInfoList.RemoveRange(roomView.Length, roomInfoList.Count - roomView.Length);
                                }

                                if (roominfoControl == 0)
                                {
                                    break;
                                }

                                //MessageBox.Show(roomID[nowCount].ToString());
                                //MessageBox.Show(id_H.ToString() + " " + id_L.ToString());
                                RoomInfo hi;

                                if (groupID != null)
                                {
                                    Byte[] seperateID = new Byte[2];
                                    bool isExist = false;

                                    GroupSetting groupForCalculate = new GroupSetting(this, 0);

                                    AllRoomSetting allForCalculate = new AllRoomSetting(this, 0);

                                    AdminSetting adminForCalculate = new AdminSetting(this, 0);

                                    for (int i = 0; i < groupID.Count; i++)
                                    {
                                        if (groupID[i] == roomID[nowCount])
                                        {
                                            seperateID = groupForCalculate.IDStringToByte(groupID[i]);
                                            isExist = true;
                                            break;
                                        }
                                    }

                                    if (isExist)
                                    {
                                        if (isGroup == true)
                                        {
                                            hi = groupForCalculate.GroupingRoomSettinComfirm(seperateID, groupGetInfo.PowerOn, groupGetInfo.LockOn, groupGetInfo.SetTemp, groupGetInfo.TempStep);
                                            
                                        }
                                        else if (isAll == true)
                                        {
                                            hi = allForCalculate.GroupingRoomSettinComfirm(seperateID, groupGetInfo.PowerOn, groupGetInfo.LockOn, groupGetInfo.SetTemp,groupGetInfo.TempStep);
                                        }
                                        else 
                                            hi = adminForCalculate.AdminRoomSettinComfirm(seperateID, adminInfo.DF, adminInfo.UH, adminInfo.UL
                                                , adminInfo.HT, adminInfo.PD, adminInfo.OD, adminInfo.TC);
                                        
                                    }
                                    else
                                        hi = serialConnect.GetSerialPacket(serialConnect.readCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L));

                                }
                                else if (roomSet)
                                {
                                    hi = roomInfoSet;
                                    roomSet = false;
                                }
                                else
                                {
                                    hi = serialConnect.GetSerialPacket(serialConnect.readCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L));
                                }
                                //MessageBox.Show(roomID[nowCount].ToString() + " " + hi.ConnectOn);

                                /*
                                if(hi.ConnectOn==false)
                                {

                                    roomInfoList[nowCount].SetTemp = 100;
                                }
                                */
                                roomInfoList[nowCount].ID = Convert.ToInt32(roomID[nowCount]);


                                //MessageBox.Show(roomInfoList[nowCount].LockOn.ToString() + " " + hi.LockOn.ToString());

                                /** 18.5.21 
                                 *  visual studio error
                                 *  중단점이 현재 적중되지 않습니다. 소스코드가 원래 버전과 다릅니다
                                 *  messagebox는  뜨지도않고 중단점설정도 안되고 
                                 *  아래 eventlistview 아이템 add하는 코드를 지워도
                                 *  디버깅시 add됨
                                 *  
                                 *  솔루션 정리, 다시빌드하면 해결
                                 * */

                                if (roomInfoList[nowCount].LockOn == false && roomInfoList[nowCount].LockOn != hi.LockOn && checkFirstThread == 1)
                                {
                                    String[] eventArr
                                        = { Time.GetHour().ToString() + ":" + Time.GetMin().ToString(),
                                    roomInfoList[nowCount].ID.ToString(), "잠금 설정" };
                                    UpdateEventLog(Time.GetYear() + "." + Time.GetMonth() + "." + Time.GetDay() + " " + Time.GetHour().ToString() + ":" + Time.GetMin().ToString(),
                                        roomInfoList[nowCount].ID.ToString(), "잠금 설정");
                                    var listViewItem = new ListViewItem(eventArr);
                                    eventListView.Invoke((MethodInvoker)delegate ()
                                    {
                                        eventListView.Items.Add(listViewItem);
                                    });
                                }

                                else if (roomInfoList[nowCount].LockOn == true && roomInfoList[nowCount].LockOn != hi.LockOn && checkFirstThread == 1)
                                {
                                    String[] eventArr
                                       = {Time.GetHour().ToString() + ":" + Time.GetMin().ToString(),
                                    roomInfoList[nowCount].ID.ToString(), "잠금 해제" };
                                    UpdateEventLog(Time.GetYear() + "." + Time.GetMonth() + "." + Time.GetDay() + " " + Time.GetHour().ToString() + ":" + Time.GetMin().ToString(),
                                        roomInfoList[nowCount].ID.ToString(), "잠금 해제");
                                    var listViewItem = new ListViewItem(eventArr);
                                    eventListView.Invoke((MethodInvoker)delegate ()
                                    {

                                        eventListView.Items.Add(listViewItem);
                                    });
                                }

                                if (roomInfoList[nowCount].PowerOn == false && roomInfoList[nowCount].PowerOn != hi.PowerOn && checkFirstThread == 1)
                                {
                                    String[] eventArr
                                        = { Time.GetHour().ToString() + ":" + Time.GetMin().ToString(),
                                    roomInfoList[nowCount].ID.ToString(), "전원 켜짐" };
                                    UpdateEventLog(Time.GetYear() + "." + Time.GetMonth() + "." + Time.GetDay() + " " + Time.GetHour().ToString() + ":" + Time.GetMin().ToString(),
                                        roomInfoList[nowCount].ID.ToString(), "전원 켜짐");
                                    var listViewItem = new ListViewItem(eventArr);
                                    eventListView.Invoke((MethodInvoker)delegate ()
                                    {
                                        eventListView.Items.Add(listViewItem);
                                    });
                                }
                                else if (roomInfoList[nowCount].PowerOn == true && roomInfoList[nowCount].PowerOn != hi.PowerOn && checkFirstThread == 1)
                                {
                                    String[] eventArr
                                       = { Time.GetHour().ToString() + ":" + Time.GetMin().ToString(),
                                    roomInfoList[nowCount].ID.ToString(), "전원 꺼짐" };
                                    UpdateEventLog(Time.GetYear() + "." + Time.GetMonth() + "." + Time.GetDay() + " " + Time.GetHour().ToString() + ":" + Time.GetMin().ToString(),
                                        roomInfoList[nowCount].ID.ToString(), "전원 꺼짐");
                                    var listViewItem = new ListViewItem(eventArr);
                                    eventListView.Invoke((MethodInvoker)delegate ()
                                    {
                                        eventListView.Items.Add(listViewItem);
                                    });
                                }

                                if (roomInfoList[nowCount].SetTemp != hi.SetTemp && checkFirstThread == 1)
                                {
                                    String[] eventArr
                                        = { Time.GetHour().ToString() + ":" + Time.GetMin().ToString(),
                                    roomInfoList[nowCount].ID.ToString(), "온도 설정" };
                                    UpdateEventLog(Time.GetYear() + "." + Time.GetMonth() + "." + Time.GetDay() + " " + Time.GetHour().ToString() + ":" + Time.GetMin().ToString(),
                                        roomInfoList[nowCount].ID.ToString(), "온도 설정");
                                    var listViewItem = new ListViewItem(eventArr);
                                    eventListView.Invoke((MethodInvoker)delegate ()
                                    {
                                        eventListView.Items.Add(listViewItem);
                                    });
                                }

                                roomInfoList[nowCount].NowTemp = hi.NowTemp;
                                roomInfoList[nowCount].SetTemp = hi.SetTemp;
                                roomInfoList[nowCount].CheckSum = hi.CheckSum;
                                roomInfoList[nowCount].LockOn = hi.LockOn;
                                roomInfoList[nowCount].HeaterOn = hi.HeaterOn;
                                roomInfoList[nowCount].PowerOn = hi.PowerOn;
                                roomInfoList[nowCount].StepOn = hi.StepOn;
                                roomInfoList[nowCount].PeriodStep = hi.PeriodStep;
                                roomInfoList[nowCount].TempStep = hi.TempStep;
                                roomInfoList[nowCount].ConnectOn = hi.ConnectOn;
                                roomInfoList[nowCount].UH = hi.UH;
                                
                                roomInfoList[nowCount].DisConnectCount = roomInfoList[nowCount].DisConnectCount + hi.Count;
                                if(roomInfoList[nowCount].DisConnectCount < 3)
                                {
                                    isAllRoomPowerOn |= hi.PowerOn;
                                }

                                if (roomInfoList[nowCount].ConnectOn == true)
                                {
                                    roomInfoList[nowCount].DisConnectCount = 0;
                                }

                                checkFirstThread = 1;
                                Thread.Sleep(50);
                            }
                            
                        }
                        
                    }
                    defaultCount = currentCount;
                    isGroup = false;
                    isAll = false;
                    isAdmin = false;
                    CheckReservation_OFF(CheckReservationTuple_OFF());
                    CheckReservation_ON(CheckReservationTuple_ON());

                    ExecuteReservation(CheckReservationTuple_ON(), CheckReservationTuple_OFF());
                }

                if (isInit)
                {
                    panel1.Invoke((MethodInvoker)delegate ()
                    {
                        if (SFExist || specificFunctionExist)
                        {

                            specificFunctionPictureBox.Visible = true;
                            RoomInfo specific = new RoomInfo();
                            if (isAllRoomPowerOn)
                            {
                                specific = serialConnect.GetFirstSerialPacket(serialConnect.powerOnCmd, (byte)99, (byte)99);
                                if (specific.PowerOn)
                                    specificFunctionPictureBox.Image = GrixControler.Properties.Resources.Running;
                                else
                                    specificFunctionPictureBox.Visible = false;
                            }
                            else
                            {
                                specific = serialConnect.GetFirstSerialPacket(serialConnect.powerOffCmd, (byte)99, (byte)99);
                                if (specific.PowerOn)
                                    specificFunctionPictureBox.Image = GrixControler.Properties.Resources.Running;
                                else
                                    specificFunctionPictureBox.Visible = false;
                            }
                        }
                        else
                        {
                            specificFunctionPictureBox.Visible = false;
                        }
                    });
                }
                
                
                viewStartCount = 0;
                groupID = null;
                resetViewHandle = true;
            }
        }
        
        public void UpdateRoomView(int count)
        {
            try
            {
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < roomInfoList.Count; j++)
                    {
                        //MessageBox.Show("viewhandle " + view_Handle.ToString());
                        if (view_Handle && resetViewHandle && DBViewHandle)
                        {
                            /*
                            MessageBox.Show("if문 " + (roomView[i].roomName.Text == roomInfoList[j].ID.ToString()).ToString() + " " 
                            + roomView[i].roomName.Text + " " + roomInfoList[j].ID.ToString());
                            */
                            if (roomView!=null && roomName.Length!=0 && roomInfoList[j]!=null && roomView[i].roomName.Text == roomInfoList[j].ID.ToString())
                            {
                                /* 18.6.4 Error
                                 *  디버그 돌렸더니
                                 *  roomName.Length!=0이 false여도 if문 안으로 들어옴
                                 *  ....?
                                 *  
                                 *  roomName[i] 가 인덱스 범위 초과 에러 나옴
                                 *  try catch로 문제 발생하지않고 넘어가긴하는데....
                                 *  
                                 * */
                                try
                                {
                                    roomView[i].realRoomName.Invoke((MethodInvoker)delegate ()
                                    {
                                        //MessageBox.Show(roomInfoList[j].NowTemp.ToString() + "UIThread");
                                        roomView[i].realRoomName.Text = roomName[i];
                                    });
                                    if (roomInfoList[j].DisConnectCount < 3)
                                    {
                                        if (roomInfoList[j].PowerOn == true)
                                        {
                                            if (roomInfoList[j].StepOn)
                                            {
                                                roomView[i].current_Temp.Invoke((MethodInvoker)delegate ()
                                                {
                                                    //MessageBox.Show(roomInfoList[j].NowTemp.ToString() + "UIThread");
                                                    roomView[i].current_Temp.Text = roomInfoList[j].TempStep.ToString();
                                                });
                                                roomView[i].desired_Temp.Invoke((MethodInvoker)delegate ()
                                                {
                                                    roomView[i].desired_Temp.Text = roomInfoList[j].PeriodStep.ToString();
                                                });
                                                roomView[i].picture_Heat.Invoke((MethodInvoker)delegate ()
                                                {
                                                    roomView[i].picture_Heat.Visible = roomInfoList[j].HeaterOn;
                                                });
                                            }
                                            else
                                            {
                                                roomView[i].current_Temp.Invoke((MethodInvoker)delegate ()
                                                {
                                                    //MessageBox.Show(roomInfoList[j].NowTemp.ToString() + "UIThread");
                                                    roomView[i].current_Temp.Text = roomInfoList[j].NowTemp.ToString();
                                                });
                                                roomView[i].desired_Temp.Invoke((MethodInvoker)delegate ()
                                                {
                                                    roomView[i].desired_Temp.Text = roomInfoList[j].SetTemp.ToString();
                                                });
                                                roomView[i].picture_Heat.Invoke((MethodInvoker)delegate ()
                                                {
                                                    roomView[i].picture_Heat.Visible = roomInfoList[j].HeaterOn;
                                                });
                                            }

                                            roomView[i].picture_Lock.Invoke((MethodInvoker)delegate ()
                                            {
                                                roomView[i].picture_Lock.Visible = roomInfoList[j].LockOn;
                                            });

                                        }
                                        else
                                        {
                                            roomView[i].current_Temp.Invoke((MethodInvoker)delegate ()
                                            {
                                                //MessageBox.Show(roomInfoList[j].NowTemp.ToString() + "UIThread - poweroff");
                                                roomView[i].current_Temp.Text = "--";
                                            });
                                            roomView[i].desired_Temp.Invoke((MethodInvoker)delegate ()
                                            {
                                                roomView[i].desired_Temp.Text = " ";
                                            });
                                            roomView[i].picture_Lock.Invoke((MethodInvoker)delegate ()
                                            {
                                                roomView[i].picture_Lock.Visible = false;
                                            });
                                            roomView[i].picture_Heat.Invoke((MethodInvoker)delegate ()
                                            {
                                                roomView[i].picture_Heat.Visible = false;
                                            });
                                        }
                                    }
                                    else
                                    {
                                        roomView[i].current_Temp.Invoke((MethodInvoker)delegate ()
                                        {
                                            //MessageBox.Show(roomInfoList[j].NowTemp.ToString() + "UIThread - poweroff");
                                            roomView[i].current_Temp.Text = "X";
                                        });
                                        roomView[i].desired_Temp.Invoke((MethodInvoker)delegate ()
                                        {
                                            roomView[i].desired_Temp.Text = " ";
                                        });
                                        roomView[i].picture_Lock.Invoke((MethodInvoker)delegate ()
                                        {
                                            roomView[i].picture_Lock.Visible = false;
                                        });
                                        roomView[i].picture_Heat.Invoke((MethodInvoker)delegate ()
                                        {
                                            roomView[i].picture_Heat.Visible = false;
                                        });
                                    }
                                }
                                catch (System.IndexOutOfRangeException ex)
                                {

                                }
                            }
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        public void SetRoomView(int count, RoomInfo roomInfo)
        {
            roomView = new RoomView[count];

            for (int i = 0; i < count; i++)
            {

                roomView[i] = new RoomView(this);
                roomView[i].roomName.Text = roomID[i];
                roomView[i].realRoomName.Text = roomName[i];

                ViewPanel.Controls.Add(roomView[i]);
            }


        }

        private bool CheckRoomIDChange(int count)
        {
            for (int i = 0; i < count; i++)
            {
                //MessageBox.Show(roomView[i].roomName.Text + " " + roomID[i].ToString());
                if (roomView[i].roomName.Text != roomID[i])
                {
                    return false;
                }
            }
            return true;
        }

        public void RemoveRoomView(int defaultCount, int newCount)
        {
            //MessageBox.Show("Enter ther removeRoomView");

            this.defaultCount = newCount;

            for (int i = 0; i < defaultCount; i++)
            {
                roomView[i].Invoke((MethodInvoker)delegate ()
               {
                   ViewPanel.Controls.Remove(roomView[i]);

               });

            }

            SetRoomIDString(newCount);

            Array.Resize(ref roomView, newCount);
            /**18.5.8 
             * resize가 여기있을때에는 줄어드나 늘어나나 UI스레드가 멈춤, serial스레드는살아있는걸로봐서
             * thread resume은 제데로 작동함.
             * 
             * 
             * --------------------------------------
             * Resize문제가 아니라 ProgramSetting을 나갈경우 그냥 UI스레드가 멈춤 
             * 
             * 왜 멈추는지 찾지 못해서 같이 동작하는 serial 스레드에서 ui스레드가 멈췄을 경우 다시 동작하도록 코딩함
             * ㅠㅠ
             * 
             * ---> 해결 testupdateview 주석 확인
             * */

            if (defaultCount < newCount)
            {
                //Array.Resize(ref roomView, newCount);
                for (int k = defaultCount; k < newCount; k++)
                {
                    roomView[k] = new RoomView(this);
                }
            }

            for (int i = 0; i < newCount; i++)
            {

                ViewPanel.Invoke((MethodInvoker)delegate ()
                {
                    ViewPanel.Controls.Add(roomView[i]);
                });

                roomView[i].Invoke((MethodInvoker)delegate ()
                {
                    roomView[i].roomName.Text = roomID[i];
                    roomView[i].realRoomName.Text = roomName[i];
                });

            }
            view_Handle = true;
            //MessageBox.Show(_pauseEvent.WaitOne() + view_Handle.ToString());
        }



        class Time
        {
            private static DateTime now = DateTime.Now;
            public static string All;

            public static void loadNow()
            {
                now = DateTime.Now;
            }

            public static void setNow()
            {
                int Year = now.Year;
                int Month = now.Month;
                int Day = now.Day;
                int Hour = now.Hour;
                int Min = now.Minute;
                int Sec = now.Second;

                All = Year + "-" + Month + "-" + Day + "    " + Hour + ":" + Min + ":" + Sec;
            }

            public static int GetYear()
            {
                return now.Year;
            }
            public static int GetMonth()
            {
                return now.Month;
            }
            public static int GetDay()
            {
                return now.Day;
            }

            public static int GetHour()
            {
                return now.Hour;
            }

            public static int GetMin()
            {
                return now.Minute;
            }

            public static String GetDayOfWeek()
            {
                return now.DayOfWeek.ToString();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ProgramSetting pgset = new ProgramSetting(this);
            pgset.ShowDialog();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 1000;

            Time.setNow();
            timeLabel.Text = Time.All;

            eventListView.View = View.Details;
            eventListView.GridLines = true;
            eventListView.FullRowSelect = false;


        }



        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            wb.Save();
            wb.Close(true);
            excelApp.Quit();

            ReleaseExcelObject(ws);
            ReleaseExcelObject(wb);
            ReleaseExcelObject(excelApp);

            ThreadPause();
            serialConnect.PortClose();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.loadNow();
            Time.setNow();
            timeLabel.Text = Time.All;

            CheckHour = Time.GetHour();
            CheckMin = Time.GetMin();
            CheckDayOfWeek = Time.GetDayOfWeek();
        }

        public int TupleCount()
        {
            int count;
            try
            {
                sql = "select count(*) from idTable where roomid not in (select roomid from idtable where roomid = \'9999\')";

                command = new SQLiteCommand(sql, dbConn);

                object scalarValue = command.ExecuteScalar();
                count = Convert.ToInt32(scalarValue);

                return count;
            }
            catch (Exception er)
            {
                MessageBox.Show("SQLite3 Database Connection Error -> " + er.Message);
                return 0;
            }
        }

        public bool isSpecificFunctionExistInDB()
        {

            int count = 0;
            try
            {
                sql = "select count(*) from idTable where roomid in (select roomid from idtable where roomid = \'9999\')";

                command = new SQLiteCommand(sql, dbConn);

                object scalarValue = command.ExecuteScalar();
                count = Convert.ToInt32(scalarValue);
                
            }
            catch (Exception er)
            {
                MessageBox.Show("SQLite3 Database Connection Error -> " + er.Message);
            }
            if (count == 1)
            {
                return true;
            }
            else return false;
        }

        public void SetRoomIDString(int count)
        {
            DBViewHandle = false;
            roomID = new string[count];
            roomName = new string[count];

            sql = "select * from idTable where roomid not in (select roomid from idtable where roomid = \'9999\')";

            command = new SQLiteCommand(sql, dbConn);

            rdr = command.ExecuteReader();

            int i = 0;

            while (rdr.Read())
            {

                roomID[i] = Convert.ToInt32(rdr["roomID"]).ToString();
                roomName[i] = rdr["roomNum"].ToString();

                i++;
            }
            rdr.Close();
            DBViewHandle = true;
        }

        private int CheckReservationTuple_ON()
        {
            int count;
            try
            {
                sql = "select count(*) from idTable where not ReservationStartDay = \"\"";

                command = new SQLiteCommand(sql, dbConn);

                object scalarValue = command.ExecuteScalar();
                count = Convert.ToInt32(scalarValue);

                return count;
            }
            catch (Exception er)
            {
                MessageBox.Show("SQLite3 Database Connection Error -> " + er.Message);
                return 0;
            }
        }


        private void CheckReservation_ON(int count)
        {
            reservationTime_Mon_ON = new String[count];
            reservationTime_Tues_ON = new String[count];
            reservationTime_Wednes_ON = new String[count];
            reservationTime_Thurs_ON = new String[count];
            reservationTime_Fri_ON = new String[count];
            reservationTime_Satur_ON = new String[count];
            reservationTime_Sun_ON = new String[count];

            reservationTime_Mon_TEMP = new int[count];
            reservationTime_Tues_TEMP = new int[count];
            reservationTime_Wednes_TEMP = new int[count];
            reservationTime_Thurs_TEMP = new int[count];
            reservationTime_Fri_TEMP = new int[count];
            reservationTime_Satur_TEMP = new int[count];
            reservationTime_Sun_TEMP = new int[count];

            reservationTime_ON_ID = new String[count];
            reservationTime_ON_DAY = new String[count];

            sql = "select * from idTable where not ReservationStartDay = \"\"";

            command = new SQLiteCommand(sql, dbConn);

            rdr = command.ExecuteReader();

            int i = 0;

            while (rdr.Read())
            {
                reservationTime_ON_ID[i] = Convert.ToInt32(rdr["roomID"]).ToString();
                reservationTime_ON_DAY[i] = rdr["ReservationStartDay"].ToString();

                reservationTime_Mon_ON[i] = rdr["MondayStartTime"].ToString();
                reservationTime_Tues_ON[i] = rdr["TuesdayStartTime"].ToString();
                reservationTime_Wednes_ON[i] = rdr["WednesdayStartTime"].ToString();
                reservationTime_Thurs_ON[i] = rdr["ThursdayStartTime"].ToString();
                reservationTime_Fri_ON[i] = rdr["FridayStartTime"].ToString();
                reservationTime_Satur_ON[i] = rdr["SaturdayStartTime"].ToString();
                reservationTime_Sun_ON[i] = rdr["SundayStartTime"].ToString();

                reservationTime_Mon_TEMP[i] = Convert.ToInt32(rdr["MondayTemp"]);
                reservationTime_Tues_TEMP[i] = Convert.ToInt32(rdr["TuesdayTemp"]);
                reservationTime_Wednes_TEMP[i] = Convert.ToInt32(rdr["WednesdayTemp"]);
                reservationTime_Thurs_TEMP[i] = Convert.ToInt32(rdr["ThursdayTemp"]);
                reservationTime_Fri_TEMP[i] = Convert.ToInt32(rdr["FridayTemp"]);
                reservationTime_Satur_TEMP[i] = Convert.ToInt32(rdr["SaturdayTemp"]);
                reservationTime_Sun_TEMP[i] = Convert.ToInt32(rdr["SundayTemp"]);

                i++;
            }
            rdr.Close();

        }

        private int CheckReservationTuple_OFF()
        {
            int count;
            try
            {
                sql = "select count(*) from idTable where not ReservationEndDay = \"\"";

                command = new SQLiteCommand(sql, dbConn);

                object scalarValue = command.ExecuteScalar();
                count = Convert.ToInt32(scalarValue);

                return count;
            }
            catch (Exception er)
            {
                MessageBox.Show("SQLite3 Database Connection Error -> " + er.Message);
                return 0;
            }
        }


        private void CheckReservation_OFF(int count)
        {

            reservationTime_Mon_OFF = new String[count];
            reservationTime_Tues_OFF = new String[count];
            reservationTime_Wednes_OFF = new String[count];
            reservationTime_Thurs_OFF = new String[count];
            reservationTime_Fri_OFF = new String[count];
            reservationTime_Satur_OFF = new String[count];
            reservationTime_Sun_OFF = new String[count];

            reservationTime_OFF_ID = new String[count];
            reservationTime_OFF_DAY = new String[count];

            sql = "select * from idTable where not ReservationEndDay = \"\"";

            command = new SQLiteCommand(sql, dbConn);

            rdr = command.ExecuteReader();

            int i = 0;

            while (rdr.Read())
            {
                reservationTime_OFF_ID[i] = Convert.ToInt32(rdr["roomID"]).ToString();
                reservationTime_OFF_DAY[i] = rdr["ReservationEndDay"].ToString();

                reservationTime_Mon_OFF[i] = rdr["MondayEndTime"].ToString();
                reservationTime_Tues_OFF[i] = rdr["TuesdayEndTime"].ToString();
                reservationTime_Wednes_OFF[i] = rdr["WednesdayEndTime"].ToString();
                reservationTime_Thurs_OFF[i] = rdr["ThursdayEndTime"].ToString();
                reservationTime_Fri_OFF[i] = rdr["FridayEndTime"].ToString();
                reservationTime_Satur_OFF[i] = rdr["SaturdayEndTime"].ToString();
                reservationTime_Sun_OFF[i] = rdr["SundayEndTime"].ToString();

                i++;
            }
            rdr.Close();
            /** 18.5.11 
             * 저거는 배열 두개가 아니라 해시태그 사용해도 되는데 라는 생각이 지금들었다. 수정하도록하자 
             * 
             * */
        }


        private string[] ReservationEachDay_ON_Time(String day)
        {
            if (day == "월")
            {
                return reservationTime_Mon_ON;
            }
            else if (day == "화")
            {
                return reservationTime_Tues_ON;
            }
            else if (day == "수")
            {
                return reservationTime_Wednes_ON;
            }
            else if (day == "목")
            {
                return reservationTime_Thurs_ON;
            }
            else if (day == "금")
            {
                return reservationTime_Fri_ON;
            }
            else if (day == "토")
            {
                return reservationTime_Satur_ON;
            }
            else
                return reservationTime_Sun_ON;

        }

        private string[] ReservationEachDay_OFF_Time(String day)
        {
            if (day == "월")
            {
                return reservationTime_Mon_OFF;
            }
            else if (day == "화")
            {
                return reservationTime_Tues_OFF;
            }
            else if (day == "수")
            {
                return reservationTime_Wednes_OFF;
            }
            else if (day == "목")
            {
                return reservationTime_Thurs_OFF;
            }
            else if (day == "금")
            {
                return reservationTime_Fri_OFF;
            }
            else if (day == "토")
            {
                return reservationTime_Satur_OFF;
            }
            else
                return reservationTime_Sun_OFF;

        }

        private int[] ReservationEachDay_ON_Temp(String day)
        {
            if (day == "월")
            {
                return reservationTime_Mon_TEMP;
            }
            else if (day == "화")
            {
                return reservationTime_Tues_TEMP;
            }
            else if (day == "수")
            {
                return reservationTime_Wednes_TEMP;
            }
            else if (day == "목")
            {
                return reservationTime_Thurs_TEMP;
            }
            else if (day == "금")
            {
                return reservationTime_Fri_TEMP;
            }
            else if (day == "토")
            {
                return reservationTime_Satur_TEMP;
            }
            else
                return reservationTime_Sun_TEMP;

        }

        private String KorDayToEng(String day)
        {
            if (day == "월")
            {
                return "Monday";
            }
            else if (day == "화")
            {
                return "Tuesday";
            }
            else if (day == "수")
            {
                return "Wednesday";
            }
            else if (day == "목")
            {
                return "Thursday";
            }
            else if (day == "금")
            {
                return "Friday";
            }
            else if (day == "토")
            {
                return "Saturday";
            }
            else
            {
                return "Sunday";
            }
        }

        private void ExecuteEachDay_ON(String day, String time, int temp, int roomIDIndex, int onCount)
        {
            int hour = 0;
            int min = 0;
            String tt;
            int ttToInt = 0;
            String engDay;
            int roomInfoListIndex;
            RoomInfo roomInfo = new RoomInfo();

            engDay = KorDayToEng(day);
            tt = time.Substring(0, 2);
            if (tt == "오전") { }
            else ttToInt = 1;
            hour = Convert.ToInt32(time.Substring(2, 2));
            min = Convert.ToInt32(time.Substring(4, 2));


            if(reservationOnCount < onCount)
            {
                if (min == CheckMin)
                {
                    saveMin = min;
                }
                if (CheckHour == hour + ttToInt * 12)
                {
                    saveHour = hour + ttToInt * 12;
                }

                if (CheckDayOfWeek == engDay)
                {
                    saveDay = engDay;
                }


                if (engDay == saveDay && hour + ttToInt * 12 == saveHour && min == saveMin)
                {
                    
                    if (reservationTime_ON_ID[roomIDIndex].Length == 4)
                    {
                        id_H = reservationTime_ON_ID[roomIDIndex].Substring(0, 2);
                        id_L = reservationTime_ON_ID[roomIDIndex].Substring(2, 2);
                    }
                    else if (reservationTime_ON_ID[roomIDIndex].Length == 3)
                    {
                        id_H = reservationTime_ON_ID[roomIDIndex].Substring(0, 1);
                        id_L = reservationTime_ON_ID[roomIDIndex].Substring(1, 2);
                    }
                    else
                    {
                        id_H = "0";
                        id_L = reservationTime_ON_ID[roomIDIndex];
                    }

                    roomInfoListIndex = FindRoomInfoIndexInRoomList(reservationTime_ON_ID[roomIDIndex]);

                    roomInfo = serialConnect.GetSerialPacket(serialConnect.setPowerONTempCmd((Byte)temp), (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L));

                    roomInfoList[roomInfoListIndex].PowerOn = roomInfo.PowerOn;

                    reserveCheck_A = 1; Thread.Sleep(50);
                    reservationOnCount++;
                }
            }
            else
            {
                reservationOnCount = 0;
                saveMin = 0;
                saveHour = 0;
                saveDay = "";
            }


        }


        private void ExecuteEachDay_OFF(String day, String time, int roomIDIndex, int offCount)
        {
            int hour = 0;
            int min = 0;
            String tt;
            int ttToInt = 0;
            String engDay;
            int roomInfoListIndex;
            RoomInfo roomInfo = new RoomInfo();

            engDay = KorDayToEng(day);

            tt = time.Substring(0, 2);
            if (tt == "오전") { }
            else ttToInt = 1;

            hour = Convert.ToInt32(time.Substring(2, 2));
            min = Convert.ToInt32(time.Substring(4, 2));

            

            if(reservationOffCount < offCount)
            {
                if (min == CheckMin)
                {
                    saveMin = min;
                }
                if (CheckHour == hour + ttToInt * 12)
                {
                    saveHour = hour + ttToInt * 12;
                }

                if (CheckDayOfWeek == engDay)
                {
                    saveDay = engDay;
                }

                if (engDay == saveDay && hour + ttToInt * 12 == saveHour && min == saveMin)
                {
                    if (reservationTime_OFF_ID[roomIDIndex].Length == 4)
                    {
                        id_H = reservationTime_OFF_ID[roomIDIndex].Substring(0, 2);
                        id_L = reservationTime_OFF_ID[roomIDIndex].Substring(2, 2);
                    }
                    else if (reservationTime_OFF_ID[roomIDIndex].Length == 3)
                    {
                        id_H = reservationTime_OFF_ID[roomIDIndex].Substring(0, 1);
                        id_L = reservationTime_OFF_ID[roomIDIndex].Substring(1, 2);
                    }
                    else
                    {
                        id_H = "0";
                        id_L = reservationTime_OFF_ID[roomIDIndex];
                    }
                    roomInfoListIndex = FindRoomInfoIndexInRoomList(reservationTime_OFF_ID[roomIDIndex]);

                    roomInfo = serialConnect.GetSerialPacket(serialConnect.powerOffCmd, (byte)Convert.ToInt32(id_H), (byte)Convert.ToInt32(id_L));
                    roomInfoList[roomInfoListIndex].PowerOn = roomInfo.PowerOn;

                    reserveCheck_B = 1;
                    Thread.Sleep(50);
                    reservationOffCount++;
                }
            }
            else
            {
                reservationOffCount = 0;
                saveMin = 0;
                saveHour = 0;
                saveDay = "";
            }
            
        }

        private int FindRoomInfoIndexInRoomList(String roomID)
        {
            int index = 0;
            for(int i = 0; i <roomInfoList.Count; i++)
            {
                if (roomInfoList[i].ID == Convert.ToInt32(roomID))
                {
                    index = i;
                }
            }
            return index;
        }

        private void eventListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = eventListView.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void ExecuteReservation(int onCount, int OffCount)
        {
            
            String id_H;
            String id_L;

            String[] eachDay;

            
            for (int i = 0; i < onCount; i++)
            {
                eachDay = SeperateDay(reservationTime_ON_DAY[i]);

                /**
                 * 해당 방의, 시작 요일들을 나눠서 eachday에 넣어놓고,
                 * 아래에서 월요일이면, 월요일의 전체 time을 가져오고
                 * i번째에 해당하는 time을 추출하면 끝
                 * */

                for (int k = 0; k < eachDay.Length; k++)
                {
                    string[] onTimeEachDay = ReservationEachDay_ON_Time(eachDay[k]);
                    int[] tempEachDay = ReservationEachDay_ON_Temp(eachDay[k]);
                    ExecuteEachDay_ON(eachDay[k], onTimeEachDay[i], tempEachDay[i], i, onCount); //여기는 오전0800이 들어감
                }
            }


            for (int i = 0; i < OffCount; i++)
            {
                eachDay = SeperateDay(reservationTime_OFF_DAY[i]);
                /**
                 * 해당 방의, 시작 요일들을 나눠서 eachday에 넣어놓고,
                 * 아래에서 월요일이면, 월요일의 전체 time을 가져오고
                 * i번째에 해당하는 time을 추출하면 끝
                 * */

                for (int k = 0; k < eachDay.Length; k++)
                {
                    //여기서 문제 생김
                    string[] onTimeEachDay = ReservationEachDay_OFF_Time(eachDay[k]);
                    ExecuteEachDay_OFF(eachDay[k], onTimeEachDay[i], i, OffCount); //여기는 오전0800이 들어감
                }
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            GroupSetting grset = new GroupSetting(this);
            grset.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            filter = new ScrollPanelMessageFilter(ViewPanel);
            Application.AddMessageFilter(filter);
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            Application.AddMessageFilter(filter);
        }

        public void ResetAllVariable()
        {
            resetViewHandle = false;

            check_UI = 1;
            roominfoControl = 1;
            check = 0;
            reserveCheck_A = 0;
            reserveCheck_B = 0;
            roomInfoList.Clear();

            for (int i = 0; i < roomView.Length; i++)
            {
                roomView[i].current_Temp.Invoke((MethodInvoker)delegate ()
                {
                    roomView[i].current_Temp.Text = "0";
                });
                roomView[i].desired_Temp.Invoke((MethodInvoker)delegate ()
                {
                    roomView[i].desired_Temp.Text = "0";
                });
                roomView[i].picture_Lock.Invoke((MethodInvoker)delegate ()
                {
                    roomView[i].picture_Lock.Visible = false;
                });
                roomView[i].picture_Heat.Invoke((MethodInvoker)delegate ()
                {
                    roomView[i].picture_Heat.Visible = false;
                });
            }
        }



        private String[] SeperateDay(String str)
        {
            String[] strArray = new String[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                strArray[i] = str.Substring(i, 1);
            }
            return strArray;
        }

        private void SetReservationButton_Click(object sender, EventArgs e)
        {

            ReservationSetting reSet = new ReservationSetting(this);
            reSet.ShowDialog();
        }

        private void SetAllButton_Click(object sender, EventArgs e)
        {
            AllRoomSetting arset = new AllRoomSetting(this);
            arset.ShowDialog();
        }

        private void SetAdminButton_Click(object sender, EventArgs e)
        {
            AdminSetting adset = new AdminSetting(this);
            adset.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdateEventLog(string time, string id, string content)
        {
            try
            {
                // Excel 첫번째 워크시트 가져오기                

                Excel.Range range = ws.Cells[1, 4];
                excelIndex = (int)range.Value;

                ws.Cells[excelIndex, 1] = time;
                ws.Cells[excelIndex, 2] = id;
                ws.Cells[excelIndex, 3] = content;

                excelIndex++;
                ws.Cells[1, 4] = excelIndex;

            }catch(System.Runtime.InteropServices.InvalidComObjectException excelException)
            {

            }
            finally
            {
                // Clean up

            }
        }

        public void SetCOMInfo(string com)
        {
            try
            {
                ws.Cells[1, 5] = com;
            }
            finally { }
        }

        public String GetCOMInfo()
        {
            String com;
            Excel.Range range = ws.Cells[1, 5];
            com = range.Value.ToString();
            if (com != "COM")
                return com;
            return "COM";
        }
        
       

    }





    /** 18.5.10
     * 중복되는 코드가 많음 리펙토링 필수
     * 
     * 
     * */
}
