using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrixControler
{
    class EventInfo
    {
        string _Time;

        string _RoomID;

        string _Content;

        public EventInfo()
        {

        }

        public string Content
        {
            get { return _Content; }
            set
            {
                _Content = value;
            }
        }



        public string RoomID
        {
            get { return _RoomID; }
            set
            {
                _RoomID = value;
            }
        }

        public string Time
        {
            get { return _Time; }
            set
            {
                _Time = value;
            }
        }
    }
}
