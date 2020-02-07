using System.Data;

namespace HotelManager.DAL
{
    public static class GoodsDAL
    {
        public static DataTable LoadGoodsList()
        {
            return SQLHelper.Get("SELECT * FROM [Goods]");
        }

        public static Model.Goods LoadGoodsInfo(Model.Goods Goods)
        {
            DataTable dt = SQLHelper.Get("SELECT * FROM [Goods] WHERE [ID]=" + Goods.ID);

            Goods.Name = dt.Rows[0]["Name"].ToString();
            Goods.Price = int.Parse(dt.Rows[0]["Price"].ToString());
            Goods.Note = dt.Rows[0]["Note"].ToString();

            return Goods;

        }

        public static void InsertGoods(Model.Goods Goods)
        {
            string sqlstr = "INSERT INTO[Goods]([Name],[Price],[Note]) VALUES ('_Name',_Price,'_Note') ";

            sqlstr = sqlstr.Replace("_Name", Goods.Name.ToString());
            sqlstr = sqlstr.Replace("_Price", Goods.Price.ToString());
            sqlstr = sqlstr.Replace("_Note", Goods.Note.ToString());

            SQLHelper.Set(sqlstr);
        }

        public static void UpdateGoods(Model.Goods Goods)
        {
            string sqlstr = "UPDATE [Goods] SET [Name]='_Name',[Price]=_Price,[Note]='_Note' WHERE [Goods].[ID]="+Goods.ID;

            sqlstr = sqlstr.Replace("_Name", Goods.Name.ToString());
            sqlstr = sqlstr.Replace("_Price", Goods.Price.ToString());
            sqlstr = sqlstr.Replace("_Note", Goods.Note.ToString());

            SQLHelper.Set(sqlstr);
        }

        public static void DeleteGoods(Model.Goods Goods)
        {
            SQLHelper.Set("DELETE FROM [Goods] WHERE [ID]="+Goods.ID);
        }

        public static DataTable LoadSelectedGoods(Model.Goods Goods)
        {
            return SQLHelper.Get("SELECT * FROM [Goods] WHERE [ID]=" + Goods.ID);
        }
    }

    
}
