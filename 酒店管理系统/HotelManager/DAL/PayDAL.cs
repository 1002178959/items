using System.Data;

namespace HotelManager.DAL
{
    public static class PayDAL
    {
        public static DataTable LoadPayList()
        {
            return SQLHelper.Get("SELECT * FROM [Pay]");
        }

        public static void InsertPay(Model.Pay Pay)
        {
            string sqlstr = "INSERT INTO[Pay]([Name],[StartTime],[EndTime],[Total],[Note]) VALUES('_Name','_StartTime','_EndTime',_Total,'_Note')";

            sqlstr = sqlstr.Replace("_Name", Pay.Name.ToString());
            sqlstr = sqlstr.Replace("_StartTime", Pay.StartTime.ToString());
            sqlstr = sqlstr.Replace("_EndTime", Pay.EndTime.ToString());
            sqlstr = sqlstr.Replace("_Total", Pay.Total.ToString());
            sqlstr = sqlstr.Replace("_Note", Pay.Note.ToString());

            SQLHelper.Set(sqlstr);
        }
    }
}
