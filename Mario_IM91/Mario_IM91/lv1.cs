using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Mario_IM91
{
    public partial class lv1 : Form
    {

        private SoundPlayer soundPlayer;
        public lv1()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer("ThemeSong.wav");

        }

        #region BienCucBo
        int soLanBan = 0;
        bool sangTrai, sangPhai, dangNhay = false, duoiDat = true, batTu;
        bool trangThaiBan = false, trangThaiTo = false;
        int timeBatTu, doDaiBatTu, mang ;
        int tocDoHoa;
        int tocDoRoi;
        int diem;
        int khoangNhay = 5;
        int tocDoPlayer = 9;
        int dx1, dx2;
        //private const int NocloseButton = 0x200;
        //protected override CreateParams CreateParams
        //{
        //}

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void gachchan_Click(object sender, EventArgs e)
        {

        }

        private void picItem1_Click(object sender, EventArgs e)
        {

        }

        bool xuong;//Check đè nút xuống
        string path = Application.StartupPath + @"\picture\";
        #endregion
        private void lv1_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            mang = 1;
            menu.formToanCuc.lvHienTai = "1";
            menu.formToanCuc.fHienTai = this;
            xuong = false;
            tocDoHoa = 1;
            dx1 = 5;
            dx2 = 5;
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            //mang = 1;
            soundPlayer.PlayLooping();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                MenuPause menu = new MenuPause();
                menu.Show();
                this.Close();
            }
        }
        private void lv1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && xuong == false)
            {
                sangTrai = false;
                if (trangThaiTo == true)
                    player.Image = Image.FromFile(path + "Bm.png");
                else
                {
                    if (trangThaiBan == true)
                        player.Image = Image.FromFile(path + "Pm.png");
                    else
                        player.Image = Image.FromFile(path + "m.gif");
                }
            }
            if (e.KeyCode == Keys.Right && xuong == false)
            {
                sangPhai = false;
                if (trangThaiTo == true)
                    player.Image = Image.FromFile(path + "Bm.png");
                else
                {
                    if (trangThaiBan == true)
                        player.Image = Image.FromFile(path + "Pm.png");
                    else
                        player.Image = Image.FromFile(path + "m.gif");
                }
            }
            if (e.KeyCode == Keys.Down && xuong == true && (trangThaiTo == true || trangThaiBan == true))
            {
                xuong = false;
                player.Size = new Size(player.Width, player.Height + 20);
                player.Top -= 5;
                if (trangThaiTo == true)
                    player.Image = Image.FromFile(path + "Bm.png");
                else
                {
                    if (trangThaiBan == true)
                        player.Image = Image.FromFile(path + "Pm.png");
                }
            }
            if (e.KeyCode == Keys.Up && xuong == false)
            {
                if (trangThaiTo == true)
                    player.Image = Image.FromFile(path + "Bm.png");
                else
                {
                    if (trangThaiBan == true)
                        player.Image = Image.FromFile(path + "Pm.png");
                    else
                        player.Image = Image.FromFile(path + "m.gif");
                }
            }
        }

        private void lv1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && xuong == false && (trangThaiTo == true || trangThaiBan == true))
            {
                xuong = true;
                sangPhai = false;
                sangTrai = false;
                player.Size = new Size(player.Width, player.Height - 20);
                if (trangThaiTo == true)
                    player.Image = Image.FromFile(path + "DownBm.png");
                else
                {
                    if (trangThaiBan == true)
                        player.Image = Image.FromFile(path + "DownPM.png");
                }
            }
            if (e.KeyCode == Keys.Left && xuong == false)
            {
                sangTrai = true;
                if (trangThaiTo == true)
                    player.Image = Image.FromFile(path + "LeftBm.gif");
                else
                {
                    if (trangThaiBan == true)
                        player.Image = Image.FromFile(path + "LeftPM.gif");
                    else
                        player.Image = Image.FromFile(path + "LeftM.gif");
                }
            }
            if (e.KeyCode == Keys.Right && xuong == false)
            {
                sangPhai = true;
                if (trangThaiTo == true)
                    player.Image = Image.FromFile(path + "RightBm.gif");
                else
                {
                    if (trangThaiBan == true)
                        player.Image = Image.FromFile(path + "RightPM.gif");
                    else
                        player.Image = Image.FromFile(path + "RightM.gif");
                }
            }
            if (e.KeyCode == Keys.Up && dangNhay == false && duoiDat == true && xuong == false)
            {
                dangNhay = true;
                string st = "";
                if (sangTrai == true)
                    st = "Left";
                else
                    st = "Right";
                if (trangThaiTo == true)
                    player.Image = Image.FromFile(path + "jump" + st + "Bm.png");
                else
                {
                    if (trangThaiBan == true)
                        player.Image = Image.FromFile(path + "jump" + st + "Pm.png");
                    else
                        player.Image = Image.FromFile(path + "jump" + st + "M.png");
                }
                duoiDat = false;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            lbMang.Text = "Mạng:" + mang;
            if (player.Right >= this.ClientSize.Width)
            {
                enemyTimer.Stop();
                gameTimer.Stop();
                lv2 lv2 = new lv2();
                lv2.Show();
                this.Close();

            }
            if (mang == 0)
            {
                gameTimer.Stop();
                PictureBox pic = new PictureBox();
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Size = new Size(this.Width, this.Height);
                pic.Image = Image.FromFile(path + "over.jpg");
                this.Controls.Add(pic);
                pic.BringToFront();
                MessageBox.Show("Game Over, Nhấn ESC để chơi lại");
            }
           
            lbDiem.Text = "Điểm:" + diem;
            if (tocDoRoi != 0)
                duoiDat = false;
            player.Top += tocDoRoi;// Nhân  vật luôn rơi khi không chạm được vào vật thể
            if (sangTrai == true && player.Left > 5)
            {
                player.Left -= tocDoPlayer;
            }
            if (sangPhai == true && player.Right < this.ClientSize.Width)
            {
                player.Left += tocDoPlayer;
            }
            if (dangNhay == true) //Nhảy lên
            {
                tocDoRoi = -12;
                khoangNhay -= 1;
                if (khoangNhay <= 0)
                {
                    dangNhay = false;
                }
            }
            else//Rớt xuống
            {
                tocDoRoi = 12;
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "hoa") //Ăn hoa được lửa
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            player.Image = Image.FromFile(path + "Pm.png");
                            trangThaiBan = true;
                            trangThaiTo = false;
                            player.Size = new Size(70, 80);
                            soLanBan += 3;
                            x.Visible = false;
                            mang++;
                        }
                    if ((string)x.Tag == "coin" && x.Visible == true)
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            diem ++;
                        }
                    if (x is PictureBox && (string)x.Tag == "namDo")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            if (trangThaiBan != true)
                                player.Image = Image.FromFile(path + "Bm.png");
                            trangThaiTo = true;
                            x.Visible = false;
                            player.Size = new Size(70, 80);
                            mang++;
                        }

                    }
                    //-------------Xét xem có vật để đứng không
                    if ((string)x.Tag == "dat") // Xét đất 
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && dangNhay == false)
                        {
                            khoangNhay = 8;
                            player.Top = x.Top - player.Height;
                            tocDoRoi = 0;
                            duoiDat = true;
                        }
                    }
                    if ((string)x.Tag == "gach1" || (string)x.Tag == "item1" || (string)x.Tag == "item2" || (string)x.Tag == "itemNone")//Xét gạch nhỏ
                    {

                        if (player.Bounds.IntersectsWith(x.Bounds) && dangNhay == false && x.Visible == true)
                        {
                            //---------------------- Xét phá gạch
                            if (player.Right > x.Right + 3 && player.Left < x.Right - 3 && player.Top > x.Top && player.Top < x.Bottom && x.Visible == true && (string)x.Tag == "gach1")
                            {
                                if (trangThaiTo == true || trangThaiBan == true)
                                {
                                    x.Visible = false;
                                }
                            }
                            //------------------------------
                            if (player.Bottom - 15 <= x.Top )// Nhảy lên trên gạch
                            {
                                khoangNhay = 8;
                                player.Top = x.Top - player.Height;
                                tocDoRoi = 0;
                                duoiDat = true;
                                x.BringToFront();
                            }
                            else
                            {
                                if (player.Bottom > x.Top + 2) //Dưới cục gạch
                                {
                                    int tocDoNay = 9;
                                    if (player.Right >= x.Left && player.Right <= x.Right) //Bật sang trái
                                        player.Left -= tocDoNay;
                                    else
                                        if (player.Left <= x.Right && player.Left >= x.Left) //Bật sang phải
                                        player.Left += tocDoNay;
                                }
                            }
                        }
                    }
                    ////-----------------------------------------------Tạo item khi đụng hỏi
                    if (player.Bounds.IntersectsWith(x.Bounds) && ((string)x.Tag == "item1" || (string)x.Tag == "item2") && dangNhay == true && player.Top <= x.Bottom && player.Bottom > x.Bottom)
                    {
                        PictureBox picture = (PictureBox)x;
                        PictureBox pic = new PictureBox();
                        pic.SizeMode = PictureBoxSizeMode.StretchImage;
                        if ((string)x.Tag == "item1")// Nấm đỏ 
                        {
                            pic.Size = new Size(65, 55);
                            pic.Image = Image.FromFile(path + "nam.png");
                            pic.Tag = "namDo";
                        } //Hoa
                        else
                        {
                            pic.Size = new Size(65, 55);
                            pic.Image = Image.FromFile(path + "flower.gif");
                            pic.Tag = "hoa";
                        }
                        pic.Location = new Point(x.Location.X, x.Location.Y - x.Height);
                        pic.Anchor = AnchorStyles.Bottom;
                        pic.BringToFront();
                        this.Controls.Add(pic);
                        picture.Image = Image.FromFile(path + "noneItem.png");
                        picture.Tag = "itemNone";

                    }
                    ////-----------------------------------------------
                    if ((string)x.Tag == "cot")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            if (player.Bottom <= x.Bottom - 20)//Trên cống
                            {
                                khoangNhay = 8;
                                player.Top = x.Top - player.Height;
                                tocDoRoi = 0;
                                duoiDat = true;
                                x.BringToFront();
                            }
                            else
                                if (player.Bottom > x.Top + 5) //Dưới cống
                            {
                                if (player.Right >= x.Left && player.Right <= x.Right) //Bật sang trái
                                    player.Left -= 10;
                                else
                                    if (player.Left <= x.Right && player.Left >= x.Left) //Bật sang phải
                                    player.Left += 10;
                            }
                        }
                    }
                }
            }
        }

        private void enemyTimer_Tick(object sender, EventArgs e)
        {
            if (timeBatTu >= 50)
            {
                timeBatTu = 0;
                batTu = false;
            }
            timeBatTu += doDaiBatTu;
            //------------------------------------------------QUÁI DI CHUYỂN

            if (picNam1.Left < gachchan.Right || picNam1.Right > cot.Left)
            {
                dx1 = -dx1;
            }
            picNam1.Left += dx1;
            if (picNam2.Left < cot2.Right || picNam2.Right > this.ClientSize.Width)
            {
                dx2 = -dx2;
            }
            picNam2.Left += dx2;
            //------------------------------------------------QUÁI DI CHUYỂN
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "nam")//Đụng quái nấm
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && duoiDat == true && batTu == false && x.Visible == true)
                        {
                            xuong = false;
                            batTu = true;
                            doDaiBatTu = 1;
                            duoiDat = true;
                            mang--;
                            if (mang == 1)
                            {
                                player.Image = Image.FromFile(path + "m.gif");
                                trangThaiTo = false;
                                player.Size = new Size(60, 70);
                            }
                        }
                        else
                        {
                            if (player.Bounds.IntersectsWith(x.Bounds) && duoiDat == false)
                            {
                                x.Visible = false;
                            }
                        }
                    }
                }
            }
        }
    }
}
    

    

