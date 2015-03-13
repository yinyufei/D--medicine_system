using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using medicine_system.classinfo;
using System.Windows.Forms;

namespace medicine_system.methods
{
    class SellInfoMethod
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader qlddr = null;

        #region 添加
        public int SellInfoMethod_Add(SellInfo tb_meidicine)
        {
            int intFlag = 0;
            try
            {
                getSqlConnection getConnection = new getSqlConnection();
                conn = getConnection.GetCon();
                cmd = new SqlCommand("insertSell", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@sellID", System.Data.SqlDbType.NVarChar).Value = tb_meidicine.aSellID;
                cmd.Parameters.Add("@medicineID", System.Data.SqlDbType.NVarChar).Value = tb_meidicine.aMedicineID;
                cmd.Parameters.Add("@employID", System.Data.SqlDbType.NVarChar).Value = tb_meidicine.aEmployID;
                cmd.Parameters.Add("@onePrice", System.Data.SqlDbType.Money).Value = tb_meidicine.aSellOnePrice;
                cmd.Parameters.Add("@sellCount", System.Data.SqlDbType.Int).Value = tb_meidicine.aSellCount;
                cmd.Parameters.Add("@sellTime", System.Data.SqlDbType.DateTime2).Value = tb_meidicine.aSellTime;
                cmd.Parameters.Add("@sellPay", System.Data.SqlDbType.Money).Value = tb_meidicine.aSellPay;
                intFlag = cmd.ExecuteNonQuery();
                conn.Dispose();
                return intFlag = 1;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return intFlag;
            }
        }
        #endregion

        #region 判断入库ID是否存在
        public int SellInfoMethod_Find(string strObject)
        {
            int intCount = 0;
            string strSecar = null;

            try
            {
                strSecar = "select * from SellInfo where SellID= '" + strObject + "'";
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

        #region 查询进货信息并显示在出库表格里
        public void SellInfo_Find(SellInfo tb_sell, Object DataObject)
        {
            getSqlConnection getConnection = new getSqlConnection();
            conn = getConnection.GetCon();
            cmd = new SqlCommand("seller_out", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@sellID", System.Data.SqlDbType.NVarChar).Value = tb_sell.aSellID;
            System.Windows.Forms.DataGridView dv = (DataGridView)DataObject;
            qlddr = cmd.ExecuteReader();
            while (qlddr.Read())
            {
                dv[0, 0].Value = qlddr[0].ToString();
                dv[1, 0].Value = qlddr[1].ToString();
                dv[2, 0].Value = qlddr[2].ToString();
                dv[3, 0].Value = qlddr[3].ToString();
                dv[4, 0].Value = qlddr[4].ToString();
                dv[5, 0].Value = qlddr[5].ToString();
                dv[6, 0].Value = qlddr[6].ToString();
                dv[7, 0].Value = qlddr[7].ToString();
            }
            qlddr.Close();
            conn.Dispose();
        }
        #endregion

        #region 查询Flag标记
        public int SellInfoMethod_Flag(string strObject)
        {
            string strSecar = null;
            strSecar = "select Flag from SellInfo where SellID= '" + strObject + "'";

            getSqlConnection getConnection = new getSqlConnection();
            conn = getConnection.GetCon();
            cmd = new SqlCommand(strSecar, conn);
            qlddr = cmd.ExecuteReader();
            int flag = 0;
            while (qlddr.Read())
            {
                int.TryParse(qlddr[0].ToString(), out flag);
            }
            return flag;
        }
        #endregion
    }
}
