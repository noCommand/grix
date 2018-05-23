using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrixControler
{
    public class GroupRoomInfo
    {/**
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

        bool _Exist;

        public GroupRoomInfo()
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
        
        public bool Exist
        {
            get { return _Exist; }
            set
            {
                _Exist = value;
            }
        }
    }
}
