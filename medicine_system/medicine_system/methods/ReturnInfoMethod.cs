using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using medicine_system.classinfo;

namespace medicine_system.methods
{
    class ReturnInfoMethod
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader qlddr = null;

        #region 插入一条退货记录
        public int ReturnInfo_Add(ReturnInfo tb_return)
        {

            getSqlConnection getConnection = new getSqlConnection();
            conn = getConnection.GetCon();
            cmd = new SqlCommand("sell_return", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@returnID", System.Data.SqlDbType.NVarChar).Value = tb_return.aReturnID;
            cmd.Parameters.Add("@sellID", System.Data.SqlDbType.NVarChar).Value = tb_return.aSellID;
            cmd.Parameters.Add("@employID", System.Data.SqlDbType.NVarChar).Value = tb_return.aEmployID;
            cmd.Parameters.Add("@returnDate", System.Data.SqlDbType.DateTime2).Value = tb_return.aReturnDate;
            cmd.Parameters.Add("@returnPay", System.Data.SqlDbType.Money).Value = tb_return.aReturnPay;
            cmd.Parameters.Add("@ReturnOnePrice", System.Data.SqlDbType.Money).Value = tb_return.aReturnOnePrice;
            cmd.Parameters.Add("@returnCount", System.Data.SqlDbType.Int).Value = tb_return.aReturnCount;
            int intFlag = 0;
            intFlag = cmd.ExecuteNonQuery();
            conn.Dispose();
            return intFlag;
        }
        #endregion 

        #region 判断退货ID是否被占用
        public int ReturnInfoMethod_Find(String strObject)
        {
            int intFlag = 0;
            String strSecar = null;
            strSecar = "select * from ReturnInfo where ReturnID = '" + strObject + "'";

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
