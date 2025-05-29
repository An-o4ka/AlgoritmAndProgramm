using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DopYpr2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Стартовая форма";

            Button openButton = new Button
            {
                Text = "Открыть форму GREENPEACE",
                Size = new System.Drawing.Size(250, 40),
                Location = new System.Drawing.Point(
                    (Screen.PrimaryScreen.Bounds.Width - 250) / 2,
                    (Screen.PrimaryScreen.Bounds.Height - 40) / 2)
            };
            openButton.Click += (s, e) =>
            {
                GreenForm gf = new GreenForm();
                gf.Show();
            };

            this.Controls.Add(openButton);
        }
    }
}