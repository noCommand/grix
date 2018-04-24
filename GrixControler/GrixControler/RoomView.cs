using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrixControler
{
    public partial class RoomView : UserControl
    {
        public RoomView()
        {
            InitializeComponent();
            roomclickbtn.FlatStyle = FlatStyle.Flat;
            roomclickbtn.FlatAppearance.BorderColor = BackColor;
            roomclickbtn.FlatAppearance.MouseOverBackColor = BackColor;
            roomclickbtn.FlatAppearance.MouseDownBackColor = BackColor;
        }

      
    }
}
