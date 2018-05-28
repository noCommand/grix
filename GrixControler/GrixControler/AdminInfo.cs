using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrixControler
{
    public class AdminInfo
    {
        int _DF;

        int _UH;

        int _UL;

        int _HT;

        int _PD;

        int _OD;

        int _TC;

        public AdminInfo()
        {

        }

        public int DF
        {
            get { return _DF; }
            set
            {
                _DF = value;
            }
        }

        public int UH
        {
            get { return _UH; }
            set
            {
                _UH = value;
            }
        }
        public int UL
        {
            get { return _UL; }
            set
            {
                _UL = value;
            }
        }

        public int HT
        {
            get { return _HT; }
            set
            {
                _HT = value;
            }
        }

        public int PD
        {
            get { return _PD; }
            set
            {
                _PD = value;
            }
        }

        public int OD
        {
            get { return _OD; }
            set
            {
                _OD = value;
            }
        }

        public int TC
        {
            get { return _TC; }
            set
            {
                _TC = value;
            }
        }
        
    }
}
