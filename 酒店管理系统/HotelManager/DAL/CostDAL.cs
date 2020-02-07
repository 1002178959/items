using System.Data;

namespace HotelManager.DAL
{
    public static class CostDAL
    {
        public static DataTable LoadCostList(Model.Cost Cost)
        {
            return SQLHelper.Get("SELECT [Cost].[ID],[Goods].[Name],[Goods].[Price],[Cost].[Number],[Cost].[Time],[Cost].[Note] FROM [Cost],[Goods] WHERE [Cost].[GoodsID]=[Goods].[ID] AND [CheckInID]="+Cost.CheckInID);
        }

        public static void InsertCost(Model.Cost Cost)
        {
            string sqlstr = "INSERT INTO[Cost]([CheckInID],[GoodsID],[Number],[Time],[Note]) VALUES(_CheckInID,_GoodsID,_Number,'_Time','_Note')";

            sqlstr = sqlstr.Replace("_CheckInID", Cost.CheckInID.ToString());
            sqlstr = sqlstr.Replace("_GoodsID", Cost.GoodsID.ToString());
            sqlstr = sqlstr.Replace("_Number", Cost.Number.ToString());
            sqlstr = sqlstr.Replace("_Time", Cost.Time.ToString());
            sqlstr = sqlstr.Replace("_Note", Cost.Note.ToString());

            SQLHelper.Set(sqlstr);

        }

        public static Model.Cost LoadCostInfo(Model.Cost Cost)
        {
            DataTable dt = SQLHelper.Get("SELECT * FROM [Cost] WHERE [ID]="+Cost.ID);

            Cost.CheckInID = int.Parse(dt.Rows[0]["CheckInID"].ToString());
            Cost.GoodsID = int.Parse(dt.Rows[0]["GoodsID"].ToString());
            Cost.Number = int.Parse(dt.Rows[0]["Number"].ToString());
            Cost.Time = dt.Rows[0]["Time"].ToString();
            Cost.Note = dt.Rows[0]["Note"].ToString();

            return Cost;
        }

        public static void UpdateCost(Model.Cost Cost)
        {
            string sqlstr = "UPDATE [Cost] SET [CheckInID]=_CheckInID,[GoodsID]=_GoodsID,[Number]=_Number,[Time]='_Time',[Note]='_Note'";

            sqlstr = sqlstr.Replace("_CheckInID", Cost.CheckInID.ToString());
            sqlstr = sqlstr.Replace("_GoodsID", Cost.GoodsID.ToString());
            sqlstr = sqlstr.Replace("_Number", Cost.Number.ToString());
            sqlstr = sqlstr.Replace("_Time", Cost.Time.ToString());
            sqlstr = sqlstr.Replace("_Note", Cost.Note.ToString());

            SQLHelper.Set(sqlstr);

        }

        public static void DeleteCost(Model.Cost Cost)
        {
            SQLHelper.Set("DELETE FROM [Cost] WHERE [ID]=" + Cost.ID);
        }

        
    }
}
