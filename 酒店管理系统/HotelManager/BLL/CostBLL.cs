using System.Data;

namespace HotelManager.BLL
{
    public static class CostBLL
    {
        public static DataTable DTRename(DataTable Source)
        {
            Source.Columns["Name"].ColumnName = "商品名";
            Source.Columns["Price"].ColumnName = "单价";
            Source.Columns["Number"].ColumnName = "数量";
            Source.Columns["Time"].ColumnName = "消费时间";
            Source.Columns["Note"].ColumnName = "备注";
            return Source;
        }

        public static DataTable LoadCostList(Model.Cost Cost)
        {
            return DTRename(DAL.CostDAL.LoadCostList(Cost));
        }

        public static void InsertCost(Model.Cost Cost)
        {
            DAL.CostDAL.InsertCost(Cost);
        }

        public static Model.Cost LoadCostInfo(Model.Cost Cost)
        {
            return DAL.CostDAL.LoadCostInfo(Cost);
        }

        public static void UpdateCost(Model.Cost Cost)
        {
            DAL.CostDAL.UpdateCost(Cost);
        }
    }
}

