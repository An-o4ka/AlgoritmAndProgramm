﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTimer2
{
    public partial class UserControlTimer2: UserControl
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            g.FillRectangle(Brushes.Blue, 0, 0, this.Width,
            this.Height);
            pe.Graphics.DrawString(DateTime.Now.ToLongTimeString(),
            this.Font, new SolidBrush(this.ForeColor), 0, 0);
        }
        public UserControlTimer2()
        {
            InitializeComponent();
        }

        private void UserControlTimer2_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh(); 
        }
    }
}
