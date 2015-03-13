using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using medicine_system.classinfo;
using System.Windows.Forms;

namespace medicine_system.methods
{
    class EmployInfoMethod
        
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader qlddr = null;

        #region 登录时核对用户名及密码
        public bool LogSelect(String LogUserID, String LogUserPwd)
        {
            bool ex = false;
            String StrPwd = null;

            StrPwd = "select Password from EmployInfo where EmployID = '" + LogUserID + "' ";
            getSqlConnection getConnection = new getSqlConnection();
            conn = getConnection.GetCon();
            cmd = new SqlCommand(StrPwd, conn);
            qlddr = cmd.ExecuteReader();
            while (qlddr.Read()) { StrPwd = qlddr[0].ToString(); }
            if (StrPwd == LogUserPwd)
            {
                ex = true;
                return ex;
            }
            else
            {
                return ex;
            }                    
        }
        #endregion

        #region 返回职位
        public String PosSelect(String LogUserID, String LogUserPwd)
        {
            String UserPos = null;
            UserPos = "select EmployPosition from  EmployInfo where EmployID = '" + LogUserID + "'";
            UserPos += " And Password = '" + LogUserPwd + "'";
            getSqlConnection getConnection = new getSqlConnection();
            conn = getConnection.GetCon();
            cmd = new SqlCommand(UserPos, conn);
            qlddr = cmd.ExecuteReader();
            while (qlddr.Read()) { UserPos = qlddr[0].ToString(); }
            return UserPos;
        }
        #endregion

        #region 查询
        public void EmployInfoMethod_Find(string strObject, int intFlag, Object DataObject)
        {
            string strSecar = null;
            try
            {
                switch (intFlag)//判断条件
                {
                    case 1://根据员工姓名来查询
                        strSecar = "select * from EmployInfo where EmployName like  '%" + strObject + "%'";// and EmpFlag=0";
                        break;
                    case 2://根据员工ID来查询
                        strSecar = "select  * from  EmployInfo  where  EmployID  = '" + strObject + "' ";//and EmpFlag=0";
                        break;
                    case 3://根据职位来查询
                        strSecar = "select * from EmployInfo where EmployPosition = '" + strObject + "' ";// and EmpFlag=0";
                        break;
                    
                    case 5://查找所有员工
                        strSecar = "select * from EmployInfo";// where EmpFlag=0";
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
                        dv[0, i].Value = qlddr[1].ToString();
                        dv[1, i].Value = qlddr[0].ToString();
                        dv[2, i].Value = qlddr[2].ToString();
                        dv[3, i].Value = qlddr[4].ToString();
                        dv[4, i].Value = qlddr[3].ToString();
                        dv[5, i].Value = qlddr[5].ToString();
                        dv[6, i].Value = qlddr[6].ToString();
                        dv[7, i].Value = qlddr[7].ToString();
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
        //用于单击单元格时
        public SqlDataReader EmployInfoMethod_Find(string strObject, int intFlag)
        {
            string strSecar = null;

            try
            {
                switch (intFlag)
                {
                    case 1:
                        strSecar = "select * from EmployInfo where EmployID= '" + strObject + "'";// and EmpFlag=0";
                        break;
                    case 2:
                        strSecar = "select * from EmployInfo ";//where EmpFlag=0";
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
        #endregion*/

        #region 查询（添加员工时查询登录名是否已被占用）
        public int EmployInfoMethod_Find(string strObject)
        {
            int intCount = 0;
            string strSecar = null;

            try
            {              
                strSecar = "select * from EmployInfo where EmployID= '" + strObject + "'";// and EmpFlag=0";
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

        #region 修改
        public int EmployInfoMethod_Update(EmployInfo Empinfo)
        {
            int intFlag = 0;
            try
            {
                string str_Update = "update EmployInfo set ";
                str_Update +=  "'EmployName='" + Empinfo.aEmployName + "',";
                str_Update += "Password='" + Empinfo.aPassword + "',EmploySex='" + Empinfo.aEmploySex + "',EmployBirty='" + Empinfo.aEmployBirty + "',";
                str_Update += "EmployPhone= '" + Empinfo.aEmployPhone + "',EmployAddress='" + Empinfo.aEmployAddress + "',EmployPosition='" + Empinfo.aEmployPosition + "'";
                str_Update += "where EmployID='"+Empinfo.aEmployID+"'";
                
                getSqlConnection getConnection = new getSqlConnection();
                conn = getConnection.GetCon();
                cmd = new SqlCommand(str_Update, conn);
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

        #region 删除
        public int EmployInfoMethod_Delete(EmployInfo Empinfo)
        {
            int intFlag = 0;
            try
            {
                string str_Delete = "delete from EmployInfo where EmployID='" + Empinfo.aEmployID + "'";

                getSqlConnection getConnection = new getSqlConnection();
                conn = getConnection.GetCon();
                cmd = new SqlCommand(str_Delete, conn);
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

        #region 添加
        public int EmployInfoMethod_Add(EmployInfo Empinfo)
        {
            int intFlag = 0;
            try
            {
                string str_Add = "insert into EmployInfo ( EmployID,EmployName,Password,EmploySex,EmployBirty,EmployPhone,EmployAddress,EmployPosition,Flag) values(";
                str_Add += "'" + Empinfo.aEmployID + "','" + Empinfo.aEmployName + "',";
                str_Add += "'" + Empinfo.aPassword + "','" + Empinfo.aEmploySex + "','" + Empinfo.aEmployBirty + "',";
                str_Add += "'" + Empinfo.aEmployPhone + "','" + Empinfo.aEmployAddress + "','" + Empinfo.aEmployPosition +  "',0)";
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
    }
}
