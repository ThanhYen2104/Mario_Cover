
namespace Mario_IM91
{
    partial class menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu));
            this.btThoat = new System.Windows.Forms.Button();
            this.bChoi = new System.Windows.Forms.Button();
            this.btHuongDan = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btThoat
            // 
            this.btThoat.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btThoat.BackColor = System.Drawing.Color.SkyBlue;
            this.btThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.ForeColor = System.Drawing.Color.Red;
            this.btThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btThoat.Location = new System.Drawing.Point(665, 393);
            this.btThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(141, 92);
            this.btThoat.TabIndex = 2;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = false;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // bChoi
            // 
            this.bChoi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bChoi.BackColor = System.Drawing.Color.SkyBlue;
            this.bChoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bChoi.ForeColor = System.Drawing.Color.Red;
            this.bChoi.Location = new System.Drawing.Point(69, 394);
            this.bChoi.Name = "bChoi";
            this.bChoi.Size = new System.Drawing.Size(129, 92);
            this.bChoi.TabIndex = 3;
            this.bChoi.Text = "Chơi";
            this.bChoi.UseVisualStyleBackColor = false;
            this.bChoi.Click += new System.EventHandler(this.bChoi_Click);
            // 
            // btHuongDan
            // 
            this.btHuongDan.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btHuongDan.BackColor = System.Drawing.Color.SkyBlue;
            this.btHuongDan.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHuongDan.ForeColor = System.Drawing.Color.Red;
            this.btHuongDan.Location = new System.Drawing.Point(257, 393);
            this.btHuongDan.Name = "btHuongDan";
            this.btHuongDan.Size = new System.Drawing.Size(348, 95);
            this.btHuongDan.TabIndex = 3;
            this.btHuongDan.Text = "Hướng dẫn";
            this.btHuongDan.UseVisualStyleBackColor = false;
            this.btHuongDan.Click += new System.EventHandler(this.btHuongDan_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-29, -18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(883, 512);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 490);
            this.Controls.Add(this.btHuongDan);
            this.Controls.Add(this.bChoi);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.Load += new System.EventHandler(this.menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Button bChoi;
        private System.Windows.Forms.Button btHuongDan;
    }
}