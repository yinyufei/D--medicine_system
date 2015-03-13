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
    public partial class s_return : Form
    {
        String loader;
        public s_return(String Loader)
        {
            InitializeComponent();
            loader = Loader;
        }

        SellInfo sellInfo = new SellInfo();
        SellInfoMethod sellMethod = new SellInfoMethod();
        ReturnInfo returnInfo = new ReturnInfo();
        ReturnInfoMethod returnMethod = new ReturnInfoMethod();

        private void s_return_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btchaxun_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入销售ID！");
            }
            else
            {
                if (sellMethod.SellInfoMethod_Find(textBox1.Text) == 1)
                {
                    sellInfo.aSellID = textBox1.Text;
                    sellMethod.SellInfo_Find(sellInfo, dataGridView1);
                    bttijiao.Enabled = true;
                }
                else
                {
                    MessageBox.Show("销售ID不存在！");
                }
            }
        }

        private void bttijiao_Click(object sender, EventArgs e)
        {
            int intflag = 0;

            returnInfo.aReturnID = textBox3.Text;
            returnInfo.aSellID = textBox1.Text;
            if (textBox3.Text == "")
            {
                MessageBox.Show("请输入退货ID！");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("请输入退货数量！");
            }
            else
            {
                if (sellMethod.SellInfoMethod_Flag(textBox1.Text) == 1)
                {
                    MessageBox.Show("该批货物已被退货！");
                }
                else
                {
                    int returnCount;
                    int.TryParse(textBox2.Text, out returnCount);
                    returnInfo.aReturnCount = returnCount;
                    int sellCount;
                    int.TryParse(this.dataGridView1.Rows[0].Cells[5].Value.ToString(), out sellCount);
                    if (returnCount > sellCount)
                    {
                        MessageBox.Show("退货数不能大于出售数！");
                    }
                    else
                    {
                        returnInfo.aEmployID = loader;
                        returnInfo.aReturnDate = DateTime.Now;

                        double outoneprice;
                        Double.TryParse(this.dataGridView1.Rows[0].Cells[4].Value.ToString(), out outoneprice);
                        returnInfo.aReturnOnePrice = outoneprice;

                        returnInfo.aReturnPay = returnCount * outoneprice;

                        int flag;
                        flag = returnMethod.ReturnInfoMethod_Find(textBox3.Text);
                        if (flag == 0)
                        {
                            intflag = returnMethod.ReturnInfo_Add(returnInfo);
                            if (intflag != 0)
                            {
                                MessageBox.Show("退货成功！");
                            }
                            else
                            {
                                MessageBox.Show("退货失败！");
                            }
                        }
                        else
                        {
                            MessageBox.Show("退货ID已存在！");
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
