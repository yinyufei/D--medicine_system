using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using medicine_system.classinfo;
using System.Windows.Forms;

namespace medicine_system.methods
{
    class InInfoMethod
    {

        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader qlddr = null;

        #region 查询进货信息并显示在出库表格里
        public void InInfo_Find(InInfo tb_in, Object DataObject)
        {
            getSqlConnection getConnection = new getSqlConnection();
            conn = getConnection.GetCon();
            cmd = new SqlCommand("keeper_out", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@inID", System.Data.SqlDbType.NVarChar).Value = tb_in.aInID;
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

        #region 添加
        public int InInfoMethod_Add(InInfo tb_meidicine)
        {
            int intFlag = 0;
            try
            {
                string str_Add = "insert into InInfo values( '";
                str_Add += tb_meidicine.aInID + "','"+ tb_meidicine.aMedicineID + "','";
                str_Add += tb_meidicine.aCompanyID + "','"+tb_meidicine.aEmployID+"',";
                str_Add += tb_meidicine.aInOnePrice + "," + tb_meidicine.aInCount + ",'";
                str_Add += tb_meidicine.aInTime + "'," + tb_meidicine.aInPay + ",'";
                str_Add += tb_meidicine.aProduceTime + "'," + 0 + ")";
                getSqlConnection getConnection = new getSqlConnection();
                conn = getConnection.GetCon();
                cmd = new SqlCommand(str_Add, conn);
                intFlag = cmd.ExecuteNonQuery();
                conn.Dispose();
                return intFlag=1;
            }            
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return intFlag;
            }
        }
        #endregion

        #region 查询入库ID是否存在
        public int InInfoMethod_Find(string strObject)
        {
            int intCount = 0;
            string strSecar = null;

            try
            {
                strSecar = "select * from InInfo where InID= '" + strObject + "'";// and EmpFlag=0";
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

        #region 查询Flag标记
        public int InInfoMethod_Flag(string strObject)
        {
            string strSecar = null;
            strSecar = "select Flag from InInfo where InID= '" + strObject + "'";

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
