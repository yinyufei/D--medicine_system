using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using medicine_system.classinfo;

namespace medicine_system.methods
{
    class OutInfoMethod
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader qlddr = null;

        #region 插入一条出货记录
        public int OutInfo_Add(OutInfo tb_out)
        {

            getSqlConnection getConnection = new getSqlConnection();
            conn = getConnection.GetCon();
            cmd = new SqlCommand("insert_out", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@outID", System.Data.SqlDbType.NVarChar).Value = tb_out.aOutID;
            cmd.Parameters.Add("@inID", System.Data.SqlDbType.NVarChar).Value = tb_out.aInID;
            cmd.Parameters.Add("@employID", System.Data.SqlDbType.NVarChar).Value = tb_out.aEmployID;
            cmd.Parameters.Add("@outDate", System.Data.SqlDbType.DateTime2).Value = tb_out.aOutDate;
            cmd.Parameters.Add("@OutPay", System.Data.SqlDbType.Money).Value = tb_out.aOutPay;
            cmd.Parameters.Add("@OutOnePrice", System.Data.SqlDbType.Money).Value = tb_out.aOutOnePrice;
            cmd.Parameters.Add("@OutCount", System.Data.SqlDbType.Int).Value = tb_out.aOutCount;
            int intFlag = 0;
            intFlag = cmd.ExecuteNonQuery();
            conn.Dispose();
            return intFlag;
        }
        #endregion

        #region 判断出库ID是否被占用
        public int OutInfoMethod_Find(String strObject)
        {
            int intFlag = 0;
            String strSecar = null;
            strSecar = "select * from OutInfo where OutID = '" + strObject + "'";

            getSqlConnection getConnection = new getSqlConnection();
            conn = getConnection.GetCon();
            cmd = new SqlCommand(strSecar, conn);
            qlddr = cmd.ExecuteReader();
            qlddr.Read();
            if (qlddr.HasRows)
            {
                intFlag = 1;
            }
            return intFlag;
        }
        #endregion
    }
}
