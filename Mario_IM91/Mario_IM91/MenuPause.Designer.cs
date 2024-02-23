
namespace Mario_IM91
{
    partial class MenuPause
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPause));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btChoiLai = new System.Windows.Forms.Button();
            this.btQuayLai = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(887, 512);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btChoiLai
            // 
            this.btChoiLai.BackColor = System.Drawing.Color.SkyBlue;
            this.btChoiLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btChoiLai.ForeColor = System.Drawing.Color.Red;
            this.btChoiLai.Location = new System.Drawing.Point(37, 100);
            this.btChoiLai.Name = "btChoiLai";
            this.btChoiLai.Size = new System.Drawing.Size(142, 90);
            this.btChoiLai.TabIndex = 1;
            this.btChoiLai.Text = "Chơi lại";
            this.btChoiLai.UseVisualStyleBackColor = false;
            this.btChoiLai.Click += new System.EventHandler(this.btChoiLai_Click);
            // 
            // btQuayLai
            // 
            this.btQuayLai.BackColor = System.Drawing.Color.SkyBlue;
            this.btQuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQuayLai.ForeColor = System.Drawing.Color.Red;
            this.btQuayLai.Location = new System.Drawing.Point(367, 98);
            this.btQuayLai.Name = "btQuayLai";
            this.btQuayLai.Size = new System.Drawing.Size(142, 98);
            this.btQuayLai.TabIndex = 1;
            this.btQuayLai.Text = "Quay lại menu";
            this.btQuayLai.UseVisualStyleBackColor = false;
            this.btQuayLai.Click += new System.EventHandler(this.btQuayLai_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SkyBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(751, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 102);
            this.button2.TabIndex = 1;
            this.button2.Text = "Thoát game";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MenuPause
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 525);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btQuayLai);
            this.Controls.Add(this.btChoiLai);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenuPause";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPause";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btChoiLai;
        private System.Windows.Forms.Button btQuayLai;
        private System.Windows.Forms.Button button2;
    }
}