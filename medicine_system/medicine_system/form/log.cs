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

namespace medicine_system
{
    public partial class log : Form
    {
        String password;
        String loader;
        public log()
        {
            InitializeComponent();
            //skinEngine1.SkinFile = Application.StartupPath + @"\MP10.ssk";
        }


        //输入用户密码
        private void tBPwd_TextChanged(object sender, EventArgs e)
        {
            password = tBPwd.Text;
        }

        private void cBUserPos_SelectedIndexChanged(object sender, EventArgs e)
        {
                   
        }

        private void tBUserID_TextChanged(object sender, EventArgs e)
        {
            loader = tBUserID.Text;
        }

        private void labUserID_Click(object sender, EventArgs e)
        {

        }

        private void labUserPwd_Click(object sender, EventArgs e)
        {

        }

        private void labUserPos_Click(object sender, EventArgs e)
        {

        }

        private void log_Load(object sender, EventArgs e)
        {

        }

        private void btLog_Click(object sender, EventArgs e)
        {
            EmployInfoMethod EmpInfo = new EmployInfoMethod();
            if (tBUserID.Text == "")
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            else if (tBPwd.Text == "")
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            else if (EmpInfo.LogSelect(tBUserID.Text, password) == true)
            {
                switch (EmpInfo.PosSelect(tBUserID.Text, password))
                {
                    case "销售员":
                        toseller Seller = new toseller(loader);
                        Seller.Show();
                        break;
                    case "仓管":
                        tokeeper Keeper = new tokeeper(loader);
                        Keeper.Show();
                        break;
                    case "经理":
                        toboss Boss = new toboss(loader);
                        Boss.Show();
                        break;
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("用户名或密码不正确！");
            }
        }

        private void log_Load_1(object sender, EventArgs e)
        {

        }

    }
}
