using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HotelManager.DAL
{
    class SQLHelper
    {
        static readonly string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public static SqlConnection createConnection()
        {
            //连接数据库
            SqlConnection cnn = new SqlConnection(conn);
            return cnn;
        }
        public static DataTable Get(string SetStr)
        {
            //获取数据函数

            SqlConnection tmpCnn = SQLHelper.createConnection();
            if (tmpCnn.State != 0) //如果状态异常关闭连接
            {
                tmpCnn.Close();
            }
            tmpCnn.Open();
            SqlDataAdapter cmd = new SqlDataAdapter(SetStr, tmpCnn);
            DataSet tmpDataSet = new DataSet();
            cmd.Fill(tmpDataSet);
            tmpCnn.Close();
            return tmpDataSet.Tables[0];
        }
        public static void Set(string sqlStr)
        {
            //数据库查询函数
            SqlConnection tmpCnn = createConnection();
            if (tmpCnn.State != 0)
            {
                tmpCnn.Close();
            }
            tmpCnn.Open();

            SqlCommand cmd = new SqlCommand
            {
                CommandText = sqlStr,
                Connection = tmpCnn
            };
            cmd.ExecuteNonQuery();
            tmpCnn.Close();
        }
    }
}
