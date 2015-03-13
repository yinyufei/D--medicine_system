using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using medicine_system.classinfo;
using medicine_system.methods;

namespace medicine_system
{
    public partial class b_medicine : Form
    {
        String loader;
        public b_medicine(String Loader)
        {
            InitializeComponent();
            loader = Loader;
        }

        MedicineInfo medicineInfo = new MedicineInfo();
        MedicineInfoMethod medicineMethod = new MedicineInfoMethod();
        int flag = 0;

        private void b_medicine_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            medicineInfo.aMedicineID = textBox4.Text;
            medicineInfo.aMedicineName = textBox7.Text;
            medicineInfo.aProduceCompany = textBox1.Text;

            int acount;
            int.TryParse(textBox8.Text, out acount);
            medicineInfo.aAlarmCount = acount;

            double inprice;
            inprice = Double.Parse(textBox5.Text);
            medicineInfo.aInPrice = inprice;

            double outprice;
            outprice = Double.Parse(textBox2.Text);
            medicineInfo.aOutPrice = outprice;

            medicineInfo.aType = comboBox1.Text;
            medicineInfo.aUnit = textBox6.Text;
            medicineInfo.aTime = textBox3.Text;
            int intflag;
            if (flag == 1)
            {
                if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null
                    && textBox4.Text != null && textBox5.Text != null && textBox6.Text != null
                    && textBox7.Text != null && textBox8.Text != null && comboBox1.Text != null)
                {
                    if (medicineMethod.MedicineInfoMethod_Find(textBox4.Text) == 1)//防止用户ID重复
                    {
                        MessageBox.Show("药品ID已被占用!！");
                        textBox4.Text = "";
                        textBox4.Focus();
                        return;
                    }
                    else
                    {
                        intflag = medicineMethod.Medicine_Add(medicineInfo);
                        if (intflag == 1)
                        {
                            MessageBox.Show("添加成功！");
                        }
                        else
                        {
                            MessageBox.Show("添加失败！");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("不能有信息为空！");
                }
            }
            else if (flag == 2)
            {
                textBox4.Enabled = false;
                if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null
                    && textBox4.Text != null && textBox5.Text != null && textBox6.Text != null
                    && textBox7.Text != null && textBox8.Text != null && comboBox1.Text != null)
                {
                    intflag = medicineMethod.Medicine_Update(medicineInfo);
                    if (intflag == 1)
                    {
                        MessageBox.Show("修改成功！");
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                }
                else
                {
                    MessageBox.Show("不能有信息为空！");
                }
            }
            else
            {
                intflag = medicineMethod.Medicine_Delete(medicineInfo);
                if (intflag == 1)
                {
                    MessageBox.Show("删除成功！");
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }

            toolStripButton3.Enabled = true;
            toolStripButton4.Enabled = false;
            toolStripButton5.Enabled = false;
            toolStripButton2.Enabled = false;
            toolStripButton1.Enabled = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            toolStripButton3.Enabled = true;
            toolStripButton4.Enabled = false;
            toolStripButton5.Enabled = false;
            toolStripButton1.Enabled = false;
            toolStripButton2.Enabled = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            flag = 1;
            toolStripButton1.Enabled = true;
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = false;
            toolStripButton4.Enabled = false;
            toolStripButton5.Enabled = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            flag = 2;
            toolStripButton1.Enabled = true;
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = false;
            toolStripButton4.Enabled = false;
            toolStripButton5.Enabled = false;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            flag = 3;
            toolStripButton1.Enabled = true;
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = false;
            toolStripButton4.Enabled = false;
            toolStripButton5.Enabled = false;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            textBox4.Enabled = false;
            switch (toolStripComboBox1.Text)
            {

                case "药品名称":
                    flag = 1;
                    break;
                case "药品ID":
                    flag = 2;
                    break;
                case "生产厂家":
                    flag = 3;
                    break;
                default:
                    flag = 5;
                    break;
            }
            medicineMethod.MedicineInfoMethod_Find(toolStripTextBox1.Text, flag, dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FillControls();
        }

        private void FillControls()//单击网格单元格时，自动将该条记录信息填充到网格上方
        {
            toolStripButton4.Enabled = true;
            toolStripButton5.Enabled = true;
            toolStripButton3.Enabled = false;
            try
            {
                SqlDataReader sqldr = medicineMethod.MedicineInfoMethod_Find(this.dataGridView1[1, this.dataGridView1.CurrentCell.RowIndex].Value.ToString(), 1);

                sqldr.Read();
                if (sqldr.HasRows)
                {
                    textBox7.Text = sqldr[1].ToString();
                    textBox4.Text = sqldr[2].ToString();
                    textBox1.Text = sqldr[3].ToString();
                    textBox8.Text = sqldr[5].ToString();
                    textBox5.Text = sqldr[6].ToString();
                    textBox2.Text = sqldr[7].ToString();
                    comboBox1.Text = sqldr[8].ToString();
                    textBox6.Text = sqldr[9].ToString();
                    textBox3.Text = sqldr[10].ToString();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
