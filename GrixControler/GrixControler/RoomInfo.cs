using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GrixControler
{
    public class RoomInfo
    {
        /**
         * INotifyPropertyChanged 필요할까 하고 썼는데, 어차피 
         * read보내면 받아서 다시 기입하는구조라 필요없을 듯
         * */
        int _Index;

        string _roomName;

        int _ID;

        string _Group;

        bool _ConnectOn;

        bool _StepOn;

        bool _HeaterOn;

        bool _LockOn;

        bool _PowerOn;

        int _NowTemp;

        int _SetTemp;

        int _TempStep;

        int _CheckSum;

        int _ReservationTime_H;

        int _ReservationTime_M;
        
        public RoomInfo()
        {

        }

        public int Index
        {
            get { return _Index; }
            set
            {
                _Index = value;
            }
        }

     

        public string Name
        {
            get { return _roomName; }
            set
            {
                _roomName = value;
            }
        }

        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }

        public string Group
        {
            get { return _Group; }
            set
            {
                _Group = value;
            }
        }

        public bool ConnectOn
        {
            get { return _ConnectOn; }
            set
            {
                _ConnectOn = value;
            }
        }

        public bool StepOn
        {
            get { return _StepOn; }
            set
            {
                _StepOn = value;
            }
        }

        public bool HeaterOn
        {
            get { return _HeaterOn; }
            set
            {
                _HeaterOn = value;
            }
        }

        public bool LockOn
        {
            get { return _LockOn; }
            set
            {
                _LockOn = value;
            }
        }

        public bool PowerOn
        {
            get { return _PowerOn; }
            set
            {
                _PowerOn = value;
            }
        }

        public int NowTemp
        {
            get { return _NowTemp; }
            set
            {
                _NowTemp = value;
            }
        }

        public int SetTemp
        {
            get { return _SetTemp; }
            set
            {
                _SetTemp = value;
            }
        }

        public int TempStep
        {
            get { return _TempStep; }
            set
            {
                _TempStep = value;
            }
        }

        public int CheckSum
        {
            get { return _CheckSum; }
            set
            {
                _CheckSum = value;
            }
        }

        public int ReservationTime_H
        {
            get { return _ReservationTime_H; }
            set
            {
                _ReservationTime_H = value;
            }
        }

        public int ReservationTime_M
        {
            get { return _ReservationTime_M; }
            set
            {
                _ReservationTime_M = value;
            }
        }
    }
    /**
     * INotifyPropertyChanged의 인터페이스를 상속 받고, 메서드를 생성해서 데이터의 변화를 감지하도록 
     * 셋팅하고 View(XAML)에서 데이터의 송수신이 필요한 곳에 {Binding ___}를 하면 값들을 가져오도록 설계하는 것입니다.
     * 
     * ->xaml을 사용하지 않으므로 삭제
     * */

}
