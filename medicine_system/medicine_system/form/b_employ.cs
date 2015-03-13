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
    public partial class b_employ : Form
    {
        String loader;
        public b_employ(String Loader)
        {
            InitializeComponent();
            loader = Loader;
        }
        EmployInfo EmpClass = new  EmployInfo();
        EmployInfoMethod tbMethod = new EmployInfoMethod();
        public static int intFlag = 0;

        private void label4_Click(object sender, EventArgs e)
        {
           

        }

        private void b_employ_Load(object sender, EventArgs e)
        {
            tbMethod.EmployInfoMethod_Find("", 5, dataGridView1);//5 查找所有员工
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FillControls();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)//点击 保存
        {
            if (getPan() == 1)
            {
                if (intFlag == 1)//添加
                {
                    if (tbMethod.EmployInfoMethod_Find(textBox2.Text) == 1)//防止用户ID重复
                    {
                        MessageBox.Show("登录ID已被占用!！");
                        textBox2.Text = "";
                        textBox2.Focus();
                        return;
                    }
                    
                    if (tbMethod.EmployInfoMethod_Add(EmpClass) == 1)
                    {
                        MessageBox.Show("添加成功");
                        intFlag = 0;
                        tbMethod.EmployInfoMethod_Find("", 5, dataGridView1);
                        ClearControls();
                        ControlStatus();
                    }
                    else
                    {
                        MessageBox.Show("添加失败");
                        intFlag = 0;
                        ClearControls();
                        ControlStatus();                      
                    }             
                }
                if (intFlag == 2)//修改
                {
                    if (tbMethod.EmployInfoMethod_Update(EmpClass)==1)
                    {
                        MessageBox.Show("修改成功");
                        intFlag = 0;
                        tbMethod.EmployInfoMethod_Find("", 5, dataGridView1);
                        ClearControls();
                        ControlStatus();
                    }
                    else
                    {
                        MessageBox.Show("修改失败");
                        intFlag = 0;
                        ClearControls();
                        ControlStatus();
                    }          
                }
                if (intFlag == 3)//删除
                {
                    if (tbMethod.EmployInfoMethod_Delete(EmpClass) == 1)
                    {
                        MessageBox.Show("删除成功");
                        intFlag = 0;
                        tbMethod.EmployInfoMethod_Find("", 5, dataGridView1);
                        ClearControls();
                        ControlStatus();
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                        intFlag = 0;
                        ClearControls();
                        ControlStatus();
                    }
                }
            
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)//点击 添加
        {
            ClearControls();//清空文本框内容
            ControlStatus();//控件状态取反
            intFlag = 1;//添加标记
        }

        private void toolStripButton2_Click(object sender, EventArgs e) //点击 取消
        {
            ClearControls();
            ControlStatus();
        }

        private void toolStripButton5_Click(object sender, EventArgs e) //点击 删除
        {
               ControlStatus();
            intFlag = 3;//删除标记
        }

        private void toolStripButton6_Click(object sender, EventArgs e) //点击 查询
        {
             string P_Str_selectcondition = this.toolStripComboBox1.Text;
            if (P_Str_selectcondition == null)
            {
                MessageBox.Show("请选择查询条件！");
                return;
            }

            switch (P_Str_selectcondition)
            {
                case "员工姓名"://根据员工姓名进行查找 find函数1
                    tbMethod.EmployInfoMethod_Find(toolStripTextBox1.Text,1,dataGridView1);
                    break;
                case "员工ID"://根据员工ID进行查找
                    tbMethod.EmployInfoMethod_Find(toolStripTextBox1.Text, 2, dataGridView1);
                    break;
                case "职位"://根据员工职位进行查找
                    tbMethod.EmployInfoMethod_Find(toolStripTextBox1.Text, 3, dataGridView1);
                    break;
                default:
                    break;
            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e) //单击 修改
        {
            textBox2.Enabled = false;
            ControlStatus();
            intFlag = 2;//修改标记
        }







            #region 辅助函数
        public int getPan()
        {
            int intFlag1 = 0;
            
            
                if (textBox1.Text == "")
                {
                    MessageBox.Show("员工姓名不能为空！", "提示");
                    textBox1.Focus();
                    return intFlag1;
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("用户ID不能为空！", "提示");
                    return intFlag1;
                }
                if (textBox3.Text == "")
                {
                    MessageBox.Show("用户密码不能为空！", "提示");
                    return intFlag1;
                }
                if (comboBox2.Text == "")
                {
                    MessageBox.Show("用户职位不能为空！", "提示");
                    return intFlag1;
                }
               

            EmpClass.aEmployID = textBox2.Text;
            EmpClass.aEmployName = textBox1.Text;
            EmpClass.aPassword = textBox3.Text;
            EmpClass.aEmploySex =  comboBox1.Text;
            EmpClass.aEmployBirty = dateTimePicker1.Text;
            EmpClass.aEmployPosition =  comboBox2.Text;
            EmpClass.aEmployPhone = textBox8.Text;
            EmpClass.aEmployAddress = textBox7.Text;
           
          
            if (intFlag != 3)
            {
                EmpClass.aFlag = 0;
            }
            else
            {
                EmpClass.aFlag = 1;
            }
            intFlag1 = 1;
            return intFlag1;

        
            }

        private void ControlStatus()//当要进行添加等操作时，将相关按钮状态取反
        {
            this.toolStripButton1.Enabled = !this.toolStripButton1.Enabled;
            this.toolStripButton2.Enabled = !this.toolStripButton2.Enabled;
            this.toolStripButton3.Enabled = !this.toolStripButton3.Enabled;
            this.toolStripButton4.Enabled = !this.toolStripButton4.Enabled;
            this.toolStripButton5.Enabled = !this.toolStripButton5.Enabled;
        }

        private void ClearControls()//对窗体中文本框清空
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            toolStripTextBox1.Text = "";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            toolStripComboBox1.SelectedIndex = 0;
            this.dateTimePicker1.Value = DateTime.Now;
        }

        private void FillControls()//用来单击网格中单元格时将该记录信息填充到网格上方信息区
        {
            try
            {
                SqlDataReader sqldr = tbMethod.EmployInfoMethod_Find(this.dataGridView1[1, this.dataGridView1.CurrentCell.RowIndex].Value.ToString(), 1);//find2
                sqldr.Read();
                if (sqldr.HasRows)
                {
                    textBox1.Text = sqldr[1].ToString();
                    textBox2.Text = sqldr[0].ToString();
                    textBox3.Text = sqldr[2].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(sqldr[4].ToString());
                    comboBox1.Text = sqldr[3].ToString();
                    comboBox2.Text = sqldr[5].ToString();
                    textBox7.Text = sqldr[7].ToString();
                    textBox8.Text = sqldr[6].ToString();
                   
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        #endregion

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
        
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


