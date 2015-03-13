using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using medicine_system.methods;

namespace medicine_system.form
{
    public partial class b_manage : Form
    {
        public b_manage()
        {
            InitializeComponent();
        }

        MedicineInfoMethod medicineInfoMethod = new MedicineInfoMethod();

        private void alarm_Click(object sender, EventArgs e)
        {
            medicineInfoMethod.alarm_count(dataGridView2);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void order_Click(object sender, EventArgs e)
        {
            medicineInfoMethod.employ_sell(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void b_manage_Load(object sender, EventArgs e)
        {

        }
    }
}
