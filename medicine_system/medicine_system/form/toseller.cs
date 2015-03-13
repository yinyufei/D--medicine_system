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
    public partial class toseller : Form
    {
        String loader;
        public toseller(String Loader)
        {
            InitializeComponent();
            loader = Loader;
        }

        private void button1_Click(object sender, EventArgs e) //销售：销售药品
        {
            s_sell frmrt = new s_sell(loader);
            frmrt.Owner = this;
            frmrt.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e) //销售：退还药品
        {
            s_return frmrt = new s_return(loader);
            frmrt.Owner = this;
            frmrt.ShowDialog();

        }

        private void toseller_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
