using System.Data;

namespace HotelManager.DAL
{
    public static class CheckInDAL
    {
        public static DataTable LoadCheckInList()
        {

            //查询全部双用户SQL语句
            //SELECT [CheckIn].[ID],[Room].[Number],[Room].[Type],[Customer1].[Name] AS 'Customer1Name',[Customer2].[Name] AS 'Customer2Name',[CheckIn].[Time],[CheckIn].[Days],[CheckIn].[Deposit]FROM [Customer] AS [Customer1],[Customer] AS [Customer2],[CheckIN],[Room]WHERE [CheckIN].[Customer1ID] = [Customer1].[ID] AND [CheckIN].[Customer2ID]=[Customer2].[ID] AND [CheckIn].[RoomID]=[Room].[ID]

            return SQLHelper.Get("SELECT [CheckIn].[ID],[Room].[Number],[Room].[Type],[Customer].[Name],[CheckIn].[Time],[CheckIn].[Days],[CheckIn].[Deposit] FROM [CheckIn],[Customer],[Room] WHERE [CheckIn].[RoomID]=[Room].[ID] AND [CheckIn].[Customer1ID]=[Customer].[ID]");
        }

        public static void InsertCheckIn(Model.CheckIn CheckIn)
        {
            string sqlstr = "INSERT INTO[CheckIn]([RoomID],[Customer1ID],[Customer2ID],[Time],[Days],[Deposit],[Note]) VALUES(_RoomID,_Customer1ID,_Customer2ID,'_Time',_Days,_Deposit,'_Note')";

            sqlstr = sqlstr.Replace("_RoomID", CheckIn.RoomID.ToString());
            sqlstr = sqlstr.Replace("_Customer1ID", CheckIn.Customer1ID.ToString());
            sqlstr = sqlstr.Replace("_Customer2ID", CheckIn.Customer2ID.ToString());
            sqlstr = sqlstr.Replace("_Time", CheckIn.Time.ToString());
            sqlstr = sqlstr.Replace("_Days", CheckIn.Days.ToString());
            sqlstr = sqlstr.Replace("_Deposit", CheckIn.Deposit.ToString());
            sqlstr = sqlstr.Replace("_Note", CheckIn.Note.ToString());

            SQLHelper.Set(sqlstr);
        }

        public static Model.CheckIn LoadCheckInInfo(Model.CheckIn CheckIn)
        {
            DataTable dt = SQLHelper.Get("SELECT * FROM [CheckIn] WHERE [ID]=" + CheckIn.ID);

            CheckIn.RoomID = int.Parse(dt.Rows[0]["RoomID"].ToString());
            CheckIn.Customer1ID = int.Parse(dt.Rows[0]["Customer1ID"].ToString());
            CheckIn.Customer2ID = int.Parse(dt.Rows[0]["Customer2ID"].ToString());
            CheckIn.Time = dt.Rows[0]["Time"].ToString();
            CheckIn.Days = int.Parse(dt.Rows[0]["Days"].ToString());
            CheckIn.Note = dt.Rows[0]["Note"].ToString();
            CheckIn.Deposit= int.Parse(dt.Rows[0]["Deposit"].ToString());

            return CheckIn;
        }

        public static void UpdateCheckIn(Model.CheckIn CheckIn)
        {
            string sqlstr = "UPDATE [CheckIn] SET [RoomID]=_RoomID,[Customer1ID]=_Customer1ID,[Customer2ID]=_Customer2ID,[Time]='_Time',[Days]=_Days,[Note]='_Note',[Deposit]=_Deposit WHERE [ID]=" + CheckIn.ID;

            sqlstr = sqlstr.Replace("_RoomID", CheckIn.RoomID.ToString());
            sqlstr = sqlstr.Replace("_Customer1ID", CheckIn.Customer1ID.ToString());
            sqlstr = sqlstr.Replace("_Customer2ID", CheckIn.Customer2ID.ToString());
            sqlstr = sqlstr.Replace("_Time", CheckIn.Time.ToString());
            sqlstr = sqlstr.Replace("_Days", CheckIn.Days.ToString());
            sqlstr = sqlstr.Replace("_Note", CheckIn.Note.ToString());
            sqlstr = sqlstr.Replace("_Deposit", CheckIn.Deposit.ToString());

            SQLHelper.Set(sqlstr);
        }

        public static void DeleteCheckIn(Model.CheckIn CheckIn)
        {
            SQLHelper.Set("DELETE FROM [CheckIn] WHERE [ID]=" + CheckIn.ID);
        }

        public static DataTable LoadSelectedCheckIn(Model.CheckIn CheckIn)
        {
            return SQLHelper.Get("SELECT[CheckIn].[ID],[Room].[Number],[Room].[Type],[Customer].[Name],[CheckIn].[Time],[CheckIn].[Days],[CheckIn].[Deposit] FROM[CheckIn],[Customer],[Room] WHERE[CheckIn].[RoomID] =[Room].[ID] AND [CheckIn].[Customer1ID]=[Customer].[ID] AND [CheckIn].[ID]=" + CheckIn.ID);
        }
    }
}
