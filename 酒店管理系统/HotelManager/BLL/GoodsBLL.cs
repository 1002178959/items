using System.Data;

namespace HotelManager.BLL
{
    public class GoodsBLL
    {
        public static DataTable DTRename(DataTable Source)
        {
            Source.Columns["Name"].ColumnName = "商品名";
            Source.Columns["Price"].ColumnName = "价格";
            Source.Columns["Note"].ColumnName = "备注";

            return Source;
        }

        public static DataTable LoadGoodsList()
        {
            return DTRename(DAL.GoodsDAL.LoadGoodsList());
        }

        public static void InsertGoods(Model.Goods Goods)
        {
            DAL.GoodsDAL.InsertGoods(Goods);
        }

        public static Model.Goods LoadGoodsInfo(Model.Goods Goods)
        {
            return DAL.GoodsDAL.LoadGoodsInfo(Goods);
        }

        public static void UpdateGoods(Model.Goods Goods)
        {
            DAL.GoodsDAL.UpdateGoods(Goods);
        }

        public static DataTable LoadSelectedGoods(Model.Goods Goods)
        {
            return DTRename(DAL.GoodsDAL.LoadSelectedGoods(Goods));
        }
    }
}
