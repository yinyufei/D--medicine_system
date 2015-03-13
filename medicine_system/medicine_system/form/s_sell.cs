using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using medicine_system.classinfo;
using System.Data.SqlClient;
using medicine_system.methods;

namespace medicine_system
{
    public partial class s_sell : Form
    {
        String loader;
        public s_sell(String Loader)
        {
            InitializeComponent();
            loader = Loader;
        }
        SellInfo EmpClass = new SellInfo();//创建一个入库信息对象，用来承载各种操作//
        MedicineInfoMethod tbMethod = new MedicineInfoMethod();
        SellInfoMethod tbMethodtwo = new SellInfoMethod();

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void s_sell_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)//保存
        {
            if (getPan() == 1)
            {

                if (tbMethodtwo.SellInfoMethod_Find(textBox6.Text) == 1)//防止sellID重复
                {
                    MessageBox.Show("销售ID已被占用!！");
                    textBox6.Text = "";
                    textBox6.Focus();
                    return;
                }

                if (tbMethodtwo.SellInfoMethod_Add(EmpClass) == 1)
                {
                    MessageBox.Show("添加成功");
                    ClearControls();

                }
                else
                {
                    MessageBox.Show("添加失败");

                    ClearControls();

                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)//点击 查询
        {
            string P_Str_selectcondition = this.toolStripComboBox1.Text;

            switch (P_Str_selectcondition)
            {
                case "药品名称":    //根据药品名称姓名进行查找 find函数1
                    tbMethod.MedicineInfoMethod_Find(toolStripTextBox1.Text, 1, dataGridView1);//medicine里面的函数
                    break;
                case "药品ID"://根据员工ID进行查找
                    tbMethod.MedicineInfoMethod_Find(toolStripTextBox1.Text, 2, dataGridView1);
                    break;
                case "生产厂家"://根据员工ID进行查找
                    tbMethod.MedicineInfoMethod_Find(toolStripTextBox1.Text, 3, dataGridView1);
                    break;
                default:
                    tbMethod.MedicineInfoMethod_Find(toolStripTextBox1.Text, 5, dataGridView1);//5 查找所有记录
                    break;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//点击后自动填充
        {
            FillControls();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()//对窗体中文本框清空
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            
            toolStripTextBox1.Text = "";
            toolStripComboBox1.SelectedIndex = 0;

        }

        private void FillControls()//用来单击网格中单元格时将该记录信息填充到网格上方信息区
        {
            try
            {
                SqlDataReader sqldr = tbMethod.MedicineInfoMethod_Find(this.dataGridView1[0, this.dataGridView1.CurrentCell.RowIndex].Value.ToString(), 1);//find2
                sqldr.Read();
                if (sqldr.HasRows)
                {
                    textBox1.Text = sqldr[1].ToString();
                    textBox2.Text = sqldr[0].ToString();
                    textBox5.Text = sqldr[5].ToString();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        //辅助函数
        public int getPan()
        {
            int intFlag1 = 0;

            if (textBox6.Text == "")
            {
                MessageBox.Show("销售单号不能为空！", "提示");
                textBox6.Focus();
                return intFlag1;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("药品名称不能为空！", "提示");
                textBox1.Focus();
                return intFlag1;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("药品ID不能为空！", "提示");
                textBox2.Focus();
                return intFlag1;
            }
            if (textBox5.Text == "")
            {
                MessageBox.Show("药品单价不能为空！", "提示");
                textBox5.Focus();
                return intFlag1;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("进货数量不能为空！", "提示");
                textBox4.Focus();
                return intFlag1;
            }



            EmpClass.aSellID = textBox6.Text;
            EmpClass.aMedicineID = textBox2.Text;
            EmpClass.aEmployID = loader;//***********登录用户*************


            int incount;
            int.TryParse(textBox4.Text, out incount);
            EmpClass.aSellCount = incount;

            EmpClass.aSellTime = DateTime.Now;

            double inoneprice;
            Double.TryParse(textBox5.Text, out inoneprice);
            EmpClass.aSellOnePrice = inoneprice;

            double inpay;
            inpay = inoneprice * incount;
            EmpClass.aSellPay = inpay;

            intFlag1 = 1;
            return intFlag1;
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


       
    }
}
