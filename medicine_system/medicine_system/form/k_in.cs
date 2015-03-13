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
    public partial class k_in : Form
    {
        String loader;
        public k_in(String Loader)
        {
            InitializeComponent();
            loader = Loader;
        }
        
       InInfo EmpClass = new InInfo();//创建一个入库信息对象，用来承载各种操作//
       MedicineInfoMethod tbMethod = new MedicineInfoMethod();
       InInfoMethod tbMethodtwo = new InInfoMethod();
       
      
        private void toolStripButton3_Click(object sender, EventArgs e)//点击 查询
        {
            string P_Str_selectcondition = this.toolStripComboBox1.Text;
            if (P_Str_selectcondition == null)
            {
                MessageBox.Show("请选择查询条件！");
                return;
            }
           
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
                     tbMethod.MedicineInfoMethod_Find("", 5, dataGridView1);//5 查找所有记录
                    break;
            }
        }

        private void k_in_Load(object sender, EventArgs e)
        {
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//点击后自动填充
        {
            FillControls();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)//保存
        {
            if (getPan() == 1)
            {

                if (tbMethodtwo.InInfoMethod_Find(textBox6.Text) == 1)//防止用户ID重复
                    {
                        MessageBox.Show("入库ID已被占用!！");
                        textBox6.Text = "";
                        textBox6.Focus();
                        return;
                    }

                if (tbMethodtwo.InInfoMethod_Add(EmpClass) == 1)
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

        private void toolStripButton2_Click(object sender, EventArgs e)//点击 取消
        {
            ClearControls();
          
        }
        private void ClearControls()//对窗体中文本框清空
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            
            textBox8.Text = "";
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
                    textBox5.Text = sqldr[0].ToString();
                    textBox2.Text = sqldr[5].ToString();

                    double inonecount;
                    inonecount=Double.Parse(sqldr[5].ToString());
                    EmpClass.aInOnePrice = inonecount;
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


            if (textBox1.Text == "")
            {
                MessageBox.Show("药品名称不能为空！", "提示");
                textBox1.Focus();
                return intFlag1;
            }
            if (textBox6.Text == "")
            {
                MessageBox.Show("药品ID不能为空！", "提示");
                return intFlag1;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("药品单价不能为空！", "提示");
                return intFlag1;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("进货数量不能为空！", "提示");
                return intFlag1;
            }



            EmpClass.aInID = textBox6.Text;
            EmpClass.aMedicineID = textBox5.Text;
            EmpClass.aCompanyID = textBox8.Text;
            EmpClass.aEmployID = loader;//***********登录用户*************

            int incount;
            int.TryParse(textBox3.Text, out incount);
            EmpClass.aInCount = incount;

            EmpClass.aInTime = DateTime.Now;

            EmpClass.aProduceTime =DateTime.Now.AddDays(-7);
            EmpClass.aFlag = 0;

            double inoneprice;
            inoneprice = double.Parse(textBox2.Text);
            EmpClass.aInOnePrice = inoneprice;

            double inpay;
            inpay = inoneprice * incount;
            EmpClass.aInPay = inpay;

            intFlag1 = 1;
            return intFlag1;
        }

       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void C_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
