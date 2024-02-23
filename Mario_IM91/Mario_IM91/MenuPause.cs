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
    public partial class MenuPause : Form
    {
        public MenuPause()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            menu.formToanCuc.fMenu.Close();
        }
        private void btQuayLai_Click(object sender, EventArgs e)
        {
            menu.formToanCuc.fMenu.Show();
            menu.formToanCuc.fHienTai.Close();
            this.Close();
           
        }

        private void btChoiLai_Click(object sender, EventArgs e)
        {
            menu.formToanCuc.fHienTai.Close();
            if (menu.formToanCuc.lvHienTai == "1")
            {
                lv1 lv1 = new lv1();
                lv1.Show();
                
            }
            if (menu.formToanCuc.lvHienTai == "2")
            {
               
                lv2 lv2 = new lv2();
                lv2.Show();
            }
            if (menu.formToanCuc.lvHienTai == "3")
            {
                lv3 lv3 = new lv3();
                lv3.Show();
               
            }
            if (menu.formToanCuc.lvHienTai == "4")
            {
                Lv4 lv4 = new Lv4();
                lv4.Show();
                
            }
            this.Close();
        }
    }
}
