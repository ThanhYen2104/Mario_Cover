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
    
    public partial class Lv4 : Form
    {
        private SoundPlayer soundPlayer;
        #region BienCucBo
        int soLanBan = 0;
        bool sangTrai, sangPhai, dangNhay = false, duoiDat = true, batTu;
        bool trangThaiBan = false, trangThaiTo = false;
        int timeBatTu, doDaiBatTu, mang;
        int tocDoHoa;
        int tocDoRoi;
        int diem;
        int khoangNhay = 5;
        int tocdoBosss=5;
        int tocDoPlayer = 9;
        int soLanDanhBoss;
        int dx1, dx2,dx3,dx4,dx5;
        int tocDoLuaRoi = 8, tocDoThanhNgang = 5 , tocDoThanhDoc = 5 ;
        bool xuong;//Check đè nút xuống
        int xFireBoss, yFireBoss;
        int tocDoLuaBoss=0; //  Check tốc độ ra lửa
        string path = Application.StartupPath + @"\picture\";
        #endregion
        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        Random randX = new Random();
        Random randY = new Random();

        private void bossTimer_Tick(object sender, EventArgs e)
        {
            if (tocDoLuaBoss >= 70)
            {
                xFireBoss = picBoss.Left;
                yFireBoss = randY.Next(picItem2.Bottom, cot.Top);
                Fire fire = new Fire();
                fire.path = path + "lua.png";
                fire.canhPhai = ClientRectangle.Width;
                fire.canhTrai = 0;
                fire.huong = "trai";
                fire.fireTop = yFireBoss;
                fire.fireLeft = xFireBoss;
                fire.tag = "luaBoss";
                fire.MakeFire(this);
                tocDoLuaBoss = 0;
            }
            else
                tocDoLuaBoss += 1;
        }
        public Lv4()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer("ThemeSong.wav");
        }

        private void Lv4_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            menu.formToanCuc.lvHienTai = "4";
            menu.formToanCuc.fHienTai = this;
            xuong = false;
            tocDoHoa = 1;
            dx1 = 5;
            dx2 = 5;
            dx3 = 3;
            dx4 = 5;
            dx5 = 5;
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            mang = 1;
            soundPlayer.PlayLooping();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                MenuPause Menu = new MenuPause();
                Menu.Show();
                this.Close();
            }
        }
        private void MainEvent_Tick(object sender, EventArgs e)
        {
            if (mang == 1)
                trangThaiTo = false;
            if (soLanBan == 0)
                trangThaiBan = false;
            //Di chuyển thanh ngang
            thanhNgang.Left -= tocDoThanhNgang;
            if (thanhNgang.Left < 0 || thanhNgang.Left + thanhNgang.Width > picGachMoc2.Left)
            {
                tocDoThanhNgang = -tocDoThanhNgang;
            }

            //di chuyen thanh dọc
            thanhDoc.Top += tocDoThanhDoc;
            if(thanhDoc.Top>=Bien.Top-25||thanhDoc.Top<186)
            {
                tocDoThanhDoc = -tocDoThanhDoc;
            }
            if (mang == 0)
            {
                MainEvent.Stop();
                PictureBox pic = new PictureBox();
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Size = new Size(this.Width, this.Height);
                pic.Image = Image.FromFile(path + "over.jpg");
                this.Controls.Add(pic);
                pic.BringToFront();
                MessageBox.Show("Game Over, Nhấn ESC để chơi lại");
            }
            if (player.Bounds.IntersectsWith(LauDai.Bounds)&& LauDai.Visible==true)
            {
                LauDai.Visible = false;
                PictureBox pic = new PictureBox();
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Size = new Size(this.Width,this.Height );
                pic.Image = Image.FromFile(path + "end.jpg");
                this.Controls.Add(pic);
                pic.BringToFront();
            }    
                
            lbMang.Text = "Mang " + mang.ToString();

            lbDiem.Text = "Điểm:" + diem;
            if (tocDoRoi != 0)
                duoiDat = false;
            player.Top += tocDoRoi;// Nhân  vật luôn rơi khi không chạm được vào vật thể
            if (sangTrai == true && player.Left>5)
            {
                player.Left -= tocDoPlayer;
            }
            if (sangPhai == true && player.Right<this.ClientSize.Width)
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
                    if ((string)x.Tag == "coin")
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
                    if((string)x.Tag == "thanhDoc")
                    {
                        if(player.Bounds.IntersectsWith(x.Bounds) && dangNhay == false)
                        {
                            if (player.Bottom-20 <= x.Top)// Nhảy lên trên gạch
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
                                if (player.Bottom > x.Top + 10) //Dưới cống
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
            if (player.Bounds.IntersectsWith(Bien.Bounds))
                mang = 0;
        }
        private void TimerLuaRoi_Tick(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "lua")
                {
                    x.Top += tocDoLuaRoi;

                    if (x.Top + x.Height >  this.ClientSize.Height )
                    {
                        x.Visible = true;
                        x.Top = randY.Next(32, 350) * -1;
                        x.Left = randX.Next(5, 1500);
                    }
                }
            }
        }
        private void TimerVaChamQuai_Tick(object sender, EventArgs e)
        {
            if (timeBatTu >= 50)
            {
                timeBatTu = 0;
                batTu = false;
            }
            timeBatTu += doDaiBatTu;

            //QUÁI DI CHUYỂN
            if (picHoaThit.Bottom > ground.Top || picHoaThit.Bottom < cot.Top)
                tocDoHoa = -tocDoHoa;
            picHoaThit.Top += tocDoHoa;
            if (picNam1.Left < 10 || picNam1.Right >= picGachMoc.Left )
            {
                dx1 = -dx1;
            }

            picNam1.Left += dx1;
            if (picNam3.Left < 120 || picNam3.Right > 285)
            {
                dx3 = -dx3;
            }
            picNam3.Left += dx3;

            if (picBoss.Left <= cot2.Right || picBoss.Right >= LauDai.Left)
            {
                tocdoBosss = -tocdoBosss;
            }
            picBoss.Left += tocdoBosss;
            picMauBoss.Left += tocdoBosss;
            if (picNam4.Left < 1010 || picNam4.Right > this.ClientSize.Width)
            {
                dx4 = -dx4;
            }
            picNam4.Left += dx4;
           

      
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "nam" )//Đụng quái nấm
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
                    if ((string)x.Tag == "Boss")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && batTu == false &&x.Visible==true)
                        {
                            batTu = true;
                            doDaiBatTu = 1;
                            mang -= 1;
                        }
                    }
                    // Xóa boom rơi và lửa boss
                    if((string)x.Tag == "lua" || (string)x.Tag == "luaBoss")
                    {
                        foreach (Control j in this.Controls)
                        {
                            if (x.Bounds.IntersectsWith(j.Bounds) && j.Visible == true && ((string)j.Tag == "gach1" || (string)j.Tag == "dat" 
                                || (string)j.Tag == "cot" || (string)j.Tag == "item1" 
                                || (string)j.Tag == "itemNone" || (string)j.Tag == "bien" || (string)j.Tag == "thanhDoc" ||
                                (string)j.Tag == "item2"))
                                x.Visible = false;
                        }
                    }
                    // Xét đụng boom, lửa boss, hoa ăn thịt
                    if ((string)x.Tag == "hoaAnThit" ||(string)x.Tag=="lua" || (string)x.Tag == "luaBoss")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && batTu == false && x.Visible == true)
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

                    }
                    //bắn lửa vào quái
                    foreach (Control j in this.Controls)
                    {
                        if(j is PictureBox && (string)j.Tag == "luaBoss")
                            if (j.Left <= 0 || j.Right >= ClientRectangle.Width)
                                this.Controls.Remove(j);
                        if (j is PictureBox && (string)j.Tag == "Fire")
                        {
                            if (j.Bounds.IntersectsWith(x.Bounds))
                            {
                                if (((string)x.Tag == "hoaAnThit" || (string)x.Tag == "nam") && x.Visible == true)
                                    x.Visible = false;
                                if ((string)x.Tag == "cot" || (string)x.Tag == "gach1" ||(string)x.Tag=="Boss")
                                    this.Controls.Remove(j);
                                if ((string)x.Tag == "Boss")
                                    soLanDanhBoss += 1;
                            }
                            if (j.Left <= 0 || j.Right >= ClientRectangle.Width)
                                this.Controls.Remove(j);
                        }
                    }
                }
                }
           
            if (soLanDanhBoss == 1)
                picMauBoss.Image = Image.FromFile(path + "80.jpg");
            if (soLanDanhBoss == 2)
                picMauBoss.Image = Image.FromFile(path + "70.jpg");
            if (soLanDanhBoss == 3)
                picMauBoss.Image = Image.FromFile(path + "60.jpg");
            if (soLanDanhBoss == 4)
                picMauBoss.Image = Image.FromFile(path + "50.jpg");
            if (soLanDanhBoss == 5)
                picMauBoss.Image = Image.FromFile(path + "40.jpg");
           
            if (soLanDanhBoss == 6 && picBoss.Visible==true)
            {
                bossTimer.Enabled = false;
                picBoss.Visible = false;
                picMauBoss.Visible = false;
               
            }

        }
        private void Lv4_KeyDown(object sender, KeyEventArgs e)
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
            if (e.KeyCode == Keys.Space && trangThaiBan == true)// Bắn lửa
            {
                ShootFire();
            }
        }
        private void Lv4_KeyUp(object sender, KeyEventArgs e)
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
        private void ShootFire()
        {
            if (soLanBan > 0)
            {
                Fire fire = new Fire();
                fire.path = path + "fire.gif";
                fire.tag = "Fire";
                fire.canhPhai = ClientRectangle.Width;
                fire.canhTrai = 0;
                fire.fireTop = player.Top + 15;
                if (sangTrai)
                {
                    fire.fireLeft = player.Left - 10;
                    fire.huong = "trai";
                }
                else
                {
                    fire.fireLeft = player.Right + 5;
                    fire.huong = "phai";
                }
                fire.MakeFire(this);
                soLanBan--;
            }
            else
            {
                trangThaiBan = false;
            }
        }
    }
}
