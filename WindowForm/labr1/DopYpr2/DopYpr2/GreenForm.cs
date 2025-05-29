using System.Drawing.Drawing2D;

namespace DopYpr2
{
    public partial class GreenForm : Form
    {
        public GreenForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Green;
            this.ClientSize = new Size(300, 300);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Point[] diamondPoints = new Point[]
            {
                new Point(this.Width / 2, 0),
                new Point(this.Width, this.Height / 2),
                new Point(this.Width / 2, this.Height),
                new Point(0, this.Height / 2)
            };

            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(diamondPoints);
            this.Region = new Region(path);

            Button closeButton = new Button
            {
                Text = "GREENPEACE",
                Size = new Size(120, 40),
                Location = new Point((Width - 120) / 2, (Height - 40) / 2)
            };
            closeButton.Click += (s, eArgs) => this.Close();

            this.Controls.Add(closeButton);
        }
    }
}
