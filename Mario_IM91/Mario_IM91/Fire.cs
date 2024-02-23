using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Mario_IM91
{
    class Fire
    {
        public string huong;
        public string path;
        public int canhTrai, canhPhai;
        public int fireTop;
        public int fireLeft;
        public string tag;
        private int tocDoDan = 5;
        private PictureBox fire = new PictureBox();
        private Timer FireTimer = new Timer();

        public void MakeFire(Form form)
        {
            fire.Image = Image.FromFile(path);
            fire.Name = "cauLua";
            fire.Size = new Size(30, 30);
            fire.SizeMode = PictureBoxSizeMode.StretchImage;
            fire.Left = fireLeft;
            fire.Top = fireTop;
            fire.BringToFront();
            fire.Tag = tag;
            form.Controls.Add(fire);

            FireTimer.Interval = tocDoDan;
            FireTimer.Tick += new EventHandler(FireTimerEvent);
            FireTimer.Start();
        }
        private void FireTimerEvent(object sender, EventArgs e)
        {
            if (huong == "trai")
            {
                fire.Left -= tocDoDan;
            }
            if (huong == "phai")
            {
                fire.Left += tocDoDan;
            }

            if (fire.Left < 0 || fire.Left > canhPhai)
            {
                FireTimer.Stop();
                FireTimer.Dispose();
                FireTimer = null;
                fire = null;
            }
        }

    }
}
