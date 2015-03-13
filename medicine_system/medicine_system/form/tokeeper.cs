using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace medicine_system
{
    public partial class tokeeper : Form
    {
        String loader;
        public tokeeper(String Loader)
        {
            InitializeComponent();
            loader = Loader;
        }

        private void btrukuguanli_Click(object sender, EventArgs e) //仓管：入库管理
        {
            k_in frmrt = new k_in(loader);
            frmrt.Owner = this;
            frmrt.ShowDialog();
        }

        private void btchukuguanli_Click(object sender, EventArgs e) //仓管：出库管理
        {
            k_out frmrt = new k_out(loader);
            frmrt.Owner = this;
            frmrt.ShowDialog();
        }

        private void tokeeper_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
