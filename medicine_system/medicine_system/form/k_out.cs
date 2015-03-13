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
    public partial class k_out : Form
    {
        String loader;
        public k_out(String Loader)
        {
            InitializeComponent();
            loader = Loader;
        }

        InInfo inInfo = new InInfo();
        InInfoMethod inMethod = new InInfoMethod();
        OutInfo outInfo = new OutInfo();
        OutInfoMethod outMethod = new OutInfoMethod();

        private void k_out_Load(object sender, EventArgs e)
        {

        }

        private void btchaxun_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入入库ID！");
            }
            else
            {
                if (inMethod.InInfoMethod_Find(textBox1.Text) == 1)
                {
                    inInfo.aInID = textBox1.Text;
                    inMethod.InInfo_Find(inInfo, dataGridView1);
                    bytijiao.Enabled = true;
                }
                else 
                { 
                    MessageBox.Show("入库ID不存在！");
                }
            }

        }

        private void bytijiao_Click(object sender, EventArgs e)
        {
            int intflag = 0;

            outInfo.aOutID = textBox3.Text;
            outInfo.aInID = textBox1.Text;
            if (textBox3.Text == "")
            {
                MessageBox.Show("出库ID不能为空");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("出库数量不能为空");
            }
            else
            {
                if (inMethod.InInfoMethod_Flag(textBox1.Text) == 1)
                {
                    MessageBox.Show("该批货物已出库！");
                }
                else
                {
                    int outCount;
                    int.TryParse(textBox2.Text, out outCount);
                    outInfo.aOutCount = outCount;
                    int inCount;
                    int.TryParse(this.dataGridView1.Rows[0].Cells[5].Value.ToString(), out inCount);
                    if (outCount > inCount)
                    {
                        MessageBox.Show("出库商品数不能大于入库数量！");
                    }
                    else
                    {
                        outInfo.aEmployID = loader;
                        outInfo.aOutDate = DateTime.Now;

                        double outoneprice;
                        Double.TryParse(this.dataGridView1.Rows[0].Cells[4].Value.ToString(), out outoneprice);
                        outInfo.aOutOnePrice = outoneprice;

                        outInfo.aOutPay = outCount * outoneprice;

                        int flag;
                        flag = outMethod.OutInfoMethod_Find(textBox3.Text);
                        if (flag == 0)
                        {
                            intflag = outMethod.OutInfo_Add(outInfo);
                            if (intflag != 0)
                            {
                                MessageBox.Show("出库成功！");
                            }
                            else
                            {
                                MessageBox.Show("出库失败！");
                            }
                        }
                        else
                        {
                            MessageBox.Show("出库ID已存在！");
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
