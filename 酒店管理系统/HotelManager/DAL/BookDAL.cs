using System.Data;

namespace HotelManager.DAL
{
    public static class BookDAL
    {
        public static DataTable LoadBookList()
        {
            return SQLHelper.Get("SELECT [Book].[ID],[Customer].[Name],[Customer].[PhoneNumber],[Room].[Number],[Room].[Type],[Book].[Time],[Book].[Days],[Book].[Note] FROM [Book],[Customer],[Room] WHERE [Book].[RoomID]=[Room].[ID] AND [Book].[CustomerID]=[Customer].[ID]");
        }

        public static void InsertBook(Model.Book Book)
        {
            string sqlstr = "INSERT INTO[Book]([RoomID],[CustomerID],[Time],[Days],[Note]) VALUES(_RoomID,_CustomerID, '_Time', '_Days', '_Note')";

            sqlstr = sqlstr.Replace("_RoomID", Book.RoomID.ToString());
            sqlstr = sqlstr.Replace("_CustomerID", Book.CustomerID.ToString());
            sqlstr = sqlstr.Replace("_Time", Book.Time.ToString());
            sqlstr = sqlstr.Replace("_Days", Book.Days.ToString());
            sqlstr = sqlstr.Replace("_Note", Book.Note.ToString());

            SQLHelper.Set(sqlstr);
        }

        public static Model.Book LoadBookInfo(Model.Book Book)
        {
            DataTable dt = SQLHelper.Get("SELECT * FROM [Book] WHERE [ID]=" + Book.ID);

            Book.RoomID = int.Parse(dt.Rows[0]["RoomID"].ToString());
            Book.CustomerID = int.Parse(dt.Rows[0]["CustomerID"].ToString());
            Book.Time =  dt.Rows[0]["Time"].ToString();
            Book.Days = int.Parse(dt.Rows[0]["Days"].ToString());
            Book.Note = dt.Rows[0]["Note"].ToString();

            return Book;
        }

        public static void UpdateBook(Model.Book Book)
        {
            string sqlstr = "UPDATE [Book] SET [RoomID]=_RoomID,[CustomerID]=_CustomerID,[Time]='_Time',[Days]=_Days,[Note]='_Note' WHERE [ID]=" + Book.ID;

            sqlstr = sqlstr.Replace("_RoomID", Book.RoomID.ToString());
            sqlstr = sqlstr.Replace("_CustomerID", Book.CustomerID.ToString());
            sqlstr = sqlstr.Replace("_Time", Book.Time.ToString());
            sqlstr = sqlstr.Replace("_Days", Book.Days.ToString());
            sqlstr = sqlstr.Replace("_Note", Book.Note.ToString());

            SQLHelper.Set(sqlstr);
        }

        public static void DeleteBook(Model.Book Book)
        {
            SQLHelper.Set("DELETE FROM [Book] WHERE [ID]=" + Book.ID);
        }
    }
}
