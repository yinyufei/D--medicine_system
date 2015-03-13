using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using medicine_system.classinfo;
using medicine_system.methods;
using medicine_system.form;

namespace medicine_system
{
    public partial class toboss : Form
    {
        String loader;
        public toboss(String Loader)
        {
            InitializeComponent();
            loader = Loader;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b_medicine frmrt = new b_medicine(loader);
            frmrt.Owner = this;
            frmrt.ShowDialog();
        }

        private void btyuangongxinxiguanli_Click(object sender, EventArgs e)
        {
            b_employ frmrt = new b_employ(loader);
            frmrt.Owner = this;
            frmrt.ShowDialog();
        }

        private void toboss_Load(object sender, EventArgs e)
        {

        }

        private void btxiaoshouxinxichaxun_Click(object sender, EventArgs e)
        {
            b_manage frmrt = new b_manage();
            frmrt.Owner = this;
            frmrt.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
