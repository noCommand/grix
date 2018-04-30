using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GrixControler
{
    public class RoomInfo : INotifyPropertyChanged
    {
        /**
         * INotifyPropertyChanged 필요할까 하고 썼는데, 어차피 
         * read보내면 받아서 다시 기입하는구조라 필요없을 듯
         * */
        public event PropertyChangedEventHandler PropertyChanged;

        int _Index;

        string _roomName;

        int _ID;

        string _Group;

        bool _ConnectOn;

        bool _StepOn;

        bool _HeaterOn;

        bool _LockOn;

        int _NowTemp;

        int _SetTemp;

        int _TempStep;

        public RoomInfo()
        {

        }

        public int Index
        {
            get { return _Index; }
            set
            {
                _Index = value;
                _notifyPropertyChanged();
            }
        }

        public string Name
        {
            get { return _roomName; }
            set
            {
                _roomName = value;
                _notifyPropertyChanged();
            }
        }

        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                _notifyPropertyChanged();
            }
        }

        public string Group
        {
            get { return _Group; }
            set
            {
                _Group = value;
                _notifyPropertyChanged();
            }
        }

        public bool ConnectOn
        {
            get { return _ConnectOn; }
            set
            {
                _ConnectOn = value;
                _notifyPropertyChanged();
            }
        }

        public bool StepOn
        {
            get { return _StepOn; }
            set
            {
                _StepOn = value;
                _notifyPropertyChanged();
            }
        }

        public bool HeaterOn
        {
            get { return _HeaterOn; }
            set
            {
                _HeaterOn = value;
                _notifyPropertyChanged();
            }
        }

        public bool LockOn
        {
            get { return _LockOn; }
            set
            {
                _LockOn = value;
                _notifyPropertyChanged();
            }
        }

        public int NowTemp
        {
            get { return _NowTemp; }
            set
            {
                _NowTemp = value;
                _notifyPropertyChanged();
            }
        }

        public int SetTemp
        {
            get { return _SetTemp; }
            set
            {
                _SetTemp = value;
                _notifyPropertyChanged();
            }
        }

        public int TempStep
        {
            get { return _TempStep; }
            set
            {
                _TempStep = value;
                _notifyPropertyChanged();
            }
        }

        private void _notifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    // Create the OnPropertyChanged method to raise the event
  
}
