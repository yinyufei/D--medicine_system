using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace medicine_system.methods
{
    class getSqlConnection
    {
        #region 连接
        string G_Str_ConnectionString = "Data Source=.;Initial Catalog=medicine_system;Integrated Security=SSPI";//
        SqlConnection G_Con;  //声明链接对象
        #endregion

        #region  构造函数
        public getSqlConnection()
        {
        }
        #endregion

        #region   连接数据库
        public SqlConnection GetCon()
        {
            G_Con = new SqlConnection(G_Str_ConnectionString);
            try
            {
                G_Con.Open();
            }
            catch
            {
                MessageBox.Show("fail");
            }
            return G_Con;
        }
        #endregion
    }
}
