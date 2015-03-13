using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using medicine_system.classinfo;
using System.Windows.Forms;

namespace medicine_system.methods
{
    class MedicineInfoMethod
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader qlddr = null;

        #region 增加一种药品
        public int Medicine_Add(MedicineInfo tb_meidicine)
        {
            string str_Add = "insert into MedicineInfo values( '";
            str_Add += tb_meidicine.aMedicineID + "','" + tb_meidicine.aMedicineName + "','";
            str_Add += tb_meidicine.aProduceCompany + "'," + 0 + "," + tb_meidicine.aAlarmCount + ",";
            str_Add += tb_meidicine.aInPrice + "," + tb_meidicine.aOutPrice + ",'";
            str_Add += tb_meidicine.aType + "','" + tb_meidicine.aUnit + "','";
            str_Add += tb_meidicine.aTime + "'," + 0 + ")";

            getSqlConnection getConnection = new getSqlConnection();
            cmd = new SqlCommand(str_Add, conn);
            int intFlag = 0;
            intFlag = cmd.ExecuteNonQuery();
            conn.Dispose();
            return intFlag;
        }
        #endregion

        #region 删除一种药品
        public int Medicine_Delete(MedicineInfo tb_meidicine)
        {
            string str_Delete = "update MedicineInfo set ";
            str_Delete += "flag= " + 1 + " where MedicineID='" + tb_meidicine.aMedicineID + "'";
            getSqlConnection getConnection = new getSqlConnection();
            conn = getConnection.GetCon();
            cmd = new SqlCommand(str_Delete, conn);
            int intFlag = 0;
            intFlag = cmd.ExecuteNonQuery();
            conn.Dispose();
            return intFlag;
        }
        #endregion

        #region 修改药品信息
        public int Medicine_Update(MedicineInfo tb_meidicine)
        {
            string str_Update = "update MedicineInfo set ";
            str_Update += "MedicineName='" + tb_meidicine.aMedicineName + "',ProduceCompany='" + tb_meidicine.aProduceCompany;
            str_Update += "',MedicineCount=" + tb_meidicine.aMedicineCount + ",AlarmCount=" + tb_meidicine.aAlarmCount + ",";
            str_Update += "InPrice=" + tb_meidicine.aInPrice + ",OutPrice=" + tb_meidicine.aOutPrice + ",";
            str_Update += "Type='" + tb_meidicine.aType + "',Unit='" + tb_meidicine.aUnit + "',";
            str_Update += "Time='" + tb_meidicine.aTime + "' where MedicineID = '" + tb_meidicine.aMedicineID + "'";

            getSqlConnection getConnection = new getSqlConnection();
            conn = getConnection.GetCon();
            cmd = new SqlCommand(str_Update, conn);
            int intFlag = 0;
            intFlag = cmd.ExecuteNonQuery();
            conn.Dispose();
            return intFlag;
        }
        #endregion

        #region 查询药品
        public void MedicineInfoMethod_Find(string strObject, int intFlag, Object DataObject)
        {
            string strSecar = null;
            try
            {
                switch (intFlag)//判断条件
                {
                    case 1://根据药品名称来查询
                        strSecar = "select * from MedicineInfo where MedicineName like  '%" + strObject + "%'";
                        strSecar += " and Flag =  0";// and EmpFlag=0";
                        break;
                    case 2://根据药品ID来查询
                        strSecar = "select  * from  MedicineInfo  where  MedicineID  = '" + strObject + "'";//and EmpFlag=0";
                        strSecar += " and Flag = " + 0;
                        break;
                    case 3://根据生产厂家来查询
                        strSecar = "select * from MedicineInfo where ProduceCompany like '%" + strObject + "%'";// and EmpFlag=0";
                        strSecar += " and Flag = " + 0;
                        break;
                    case 5://查找所有
                        strSecar = "select * from MedicineInfo where Flag = " + 0;
                        break;
                }
                getSqlConnection getConnection = new getSqlConnection();
                conn = getConnection.GetCon();
                cmd = new SqlCommand(strSecar, conn);
                int ii = 0;
                qlddr = cmd.ExecuteReader();
                while (qlddr.Read())
                {
                    ii++;
                }
                qlddr.Close();
                System.Windows.Forms.DataGridView dv = (DataGridView)DataObject;
                if (ii != 0)
                {
                    int i = 0;
                    dv.RowCount = ii;
                    qlddr = cmd.ExecuteReader();
                    while (qlddr.Read())
                    {
                        dv[0, i].Value = qlddr[0].ToString();
                        dv[1, i].Value = qlddr[1].ToString();
                        dv[2, i].Value = qlddr[2].ToString();
                        dv[3, i].Value = qlddr[3].ToString();
                        dv[4, i].Value = qlddr[4].ToString();
                        dv[5, i].Value = qlddr[5].ToString();
                        dv[6, i].Value = qlddr[6].ToString();
                        dv[7, i].Value = qlddr[7].ToString();
                        dv[8, i].Value = qlddr[8].ToString();
                        dv[9, i].Value = qlddr[9].ToString();
                        i++;
                    }
                    qlddr.Close();
                }
                else
                {
                    for (int i = 0; i < dv.RowCount; i++)
                    {
                        dv[0, i].Value = "";
                        dv[1, i].Value = "";
                        dv[2, i].Value = "";
                        dv[3, i].Value = "";
                        dv[4, i].Value = "";
                        dv[5, i].Value = "";
                        dv[6, i].Value = "";
                        dv[7, i].Value = "";
                        dv[8, i].Value = "";
                        dv[9, i].Value = "";
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        #endregion

        #region 查询（用于单击单元格时）
        public SqlDataReader MedicineInfoMethod_Find(string strObject, int intFlag)
        {
            string strSecar = null;

            try
            {
                switch (intFlag)
                {
                    case 1:
                        strSecar = "select * from MedicineInfo where MedicineID= '" + strObject + "'";
                        strSecar += " and Flag = " + 0;
                        break;
                    case 2:
                        strSecar = "select * from MedicineInfo where Flag = " + 0;
                        break;
                }

                getSqlConnection getConnection = new getSqlConnection();
                conn = getConnection.GetCon();
                cmd = new SqlCommand(strSecar, conn);

                qlddr = cmd.ExecuteReader();

                return qlddr;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return qlddr;
            }
        }
        #endregion

        #region 查询
        public int MedicineInfoMethod_Find(string strObject)
        {
            int intCount = 0;
            string strSecar = null;

            try
            {
                strSecar = "select * from MedicineInfo where MedicineID= '" + strObject + "'";
                strSecar += " and Flag = " + 0;
                getSqlConnection getConnection = new getSqlConnection();
                conn = getConnection.GetCon();
                cmd = new SqlCommand(strSecar, conn);

                qlddr = cmd.ExecuteReader();
                qlddr.Read();
                if (qlddr.HasRows)
                {
                    intCount = 1;
                }

                return intCount;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
                return intCount = 2;
            }
        }
        #endregion

        #region 员工售药成绩
        public void employ_sell(Object DataObject)
        {
            string strnumber = null;
            strnumber = "select * from number";
            getSqlConnection getConnection = new getSqlConnection();
            conn = getConnection.GetCon();
            cmd = new SqlCommand(strnumber, conn);

            int ii = 0;
            qlddr = cmd.ExecuteReader();
            while (qlddr.Read())
            {
                ii++;
            }
            qlddr.Close();
            System.Windows.Forms.DataGridView dv = (DataGridView)DataObject;

            if (ii != 0)
            {
                int i = 0;
                dv.RowCount = ii;
                qlddr = cmd.ExecuteReader();
                while (qlddr.Read())
                {
                    dv[0, i].Value = qlddr[0].ToString();
                    dv[1, i].Value = qlddr[1].ToString();

                    i++;
                }
                qlddr.Close();
            }
            else
            {
                for (int i = 0; i < dv.RowCount; i++)
                {
                    dv[0, i].Value = "";
                    dv[1, i].Value = "";

                }
            }
        }

        #endregion

        #region 警戒库存
        public void alarm_count(Object DataObject)
        {
            getSqlConnection getConnection = new getSqlConnection();
            conn = getConnection.GetCon();
            cmd = new SqlCommand("alarm_count", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            int ii = 0;
            qlddr = cmd.ExecuteReader();
            while (qlddr.Read())
            {
                ii++;
            }
            qlddr.Close();
            System.Windows.Forms.DataGridView dv = (DataGridView)DataObject;

            if (ii != 0)
            {
                int i = 0;
                dv.RowCount = ii;
                qlddr = cmd.ExecuteReader();
                while (qlddr.Read())
                {
                    dv[0, i].Value = qlddr[0].ToString();
                    dv[1, i].Value = qlddr[1].ToString();
                    dv[2, i].Value = qlddr[2].ToString();
                    i++;
                }
                qlddr.Close();
            }
            else
            {
                for (int i = 0; i < dv.RowCount; i++)
                {
                    dv[0, i].Value = "";
                    dv[1, i].Value = "";
                    dv[2, i].Value = "";
                }
            }
        }
        #endregion
    }       
}
