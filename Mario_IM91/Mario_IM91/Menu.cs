using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mario_IM91
{
    public partial class menu : Form
    {
        public static class formToanCuc
        {
            public static Form fMenu;
            public static Form fHienTai;
            public static string lvHienTai;
        }
        public menu()
        {
            InitializeComponent();

        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
         
          
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void bChoi_Click(object sender, EventArgs e)
        {
           
            lv1 lv1 = new lv1();
            lv1.Show();
            this.Hide();
        }

        private void btHuongDan_Click(object sender, EventArgs e)
        {
            HuongDan hd = new HuongDan();
            hd.Show();
            this.Hide();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            formToanCuc.fMenu = this;
        }
    }
}
