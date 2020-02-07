using System.Data;

namespace HotelManager.BLL
{
    public static class PayBLL
    {
        public static DataTable DTRename(DataTable Source)
        {
            Source.Columns["Name"].ColumnName = "客户姓名";
            Source.Columns["StartTime"].ColumnName = "入住时间";
            Source.Columns["EndTime"].ColumnName = "结算时间";
            Source.Columns["Total"].ColumnName = "总消费";
            Source.Columns["Note"].ColumnName = "备注";

            return Source;
        }

        public static DataTable LoadPayList()
        {
            return DTRename(DAL.PayDAL.LoadPayList());
        }

        public static void InsertPay(Model.Pay Pay)
        {
            DAL.PayDAL.InsertPay(Pay);
        }
    }
}
