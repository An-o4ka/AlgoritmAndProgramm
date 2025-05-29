using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DopYpr1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Размер окна
            this.ClientSize = new Size(300, 200);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightSkyBlue;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Кнопка закрытия
            Button closeButton = new Button();
            closeButton.Text = "Закрыть";
            closeButton.Size = new Size(100, 30);
            closeButton.Location = new Point(
                (this.ClientSize.Width - closeButton.Width) / 2,
                (this.ClientSize.Height - closeButton.Height) / 2
            );
            closeButton.Click += (s, args) => this.Close();
            this.Controls.Add(closeButton);
        }

        // Обработка изменения размеров — создание овальной формы
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddEllipse(0, 0, this.Width, this.Height);
            this.Region = new Region(myPath);
        }
    }
}