﻿using System;
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
            
        }
        

        private void roomName_Click(object sender, EventArgs e)
        {
            show_RoomSetting();
        }
        

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            show_RoomSetting();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            show_RoomSetting();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            show_RoomSetting();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            show_RoomSetting();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            show_RoomSetting();
        }

        public void show_RoomSetting()
        {
            RoomSetting roomSet = new RoomSetting();
            roomSet.ShowDialog();
        }
    }
}