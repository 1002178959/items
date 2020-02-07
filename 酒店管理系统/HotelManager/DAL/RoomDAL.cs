using System.Data;

namespace HotelManager.DAL
{
    public static class RoomDAL
    {
        public static DataTable LoadRoomList()
        {
            return SQLHelper.Get("SELECT * FROM [Room]");
        }

        public static void InsertRoom(Model.Room Room)
        {
            string sqlstr = "INSERT INTO[Room]([Number],[Price],[Type],[Status],[Note]) VALUES(_Number,_Price, '_Type', '_Status', '_Note')";

            sqlstr = sqlstr.Replace("_Number", Room.Number.ToString());
            sqlstr = sqlstr.Replace("_Price", Room.Price.ToString());
            sqlstr = sqlstr.Replace("_Type", Room.Type.ToString());
            sqlstr = sqlstr.Replace("_Status", Room.Status.ToString());
            sqlstr = sqlstr.Replace("_Note", Room.Note.ToString());

            SQLHelper.Set(sqlstr);
        }

        public static void DeleteRoom(Model.Room Room)
        {
            SQLHelper.Set("DELETE FROM [Room] WHERE [ID]=" + Room.ID);
        }

        public static void UpdateRoom(Model.Room Room)
        {
            string sqlstr = "UPDATE [Room] SET [Number]=_Number,[Price]=_Price,[Type]='_Type',[Status]='_Status',[Note]='_Note' WHERE [ID]=" + Room.ID;

            sqlstr = sqlstr.Replace("_Number", Room.Number.ToString());
            sqlstr = sqlstr.Replace("_Price", Room.Price.ToString());
            sqlstr = sqlstr.Replace("_Type", Room.Type.ToString());
            sqlstr = sqlstr.Replace("_Status", Room.Status.ToString());
            sqlstr = sqlstr.Replace("_Note", Room.Note.ToString());

            SQLHelper.Set(sqlstr);
        }

        public static Model.Room LoadRoomInfo(Model.Room Room)
        {
            DataTable dt = SQLHelper.Get("SELECT * FROM [Room] WHERE [ID]=" + Room.ID);


            Room.Number = int.Parse(dt.Rows[0]["Number"].ToString());
            Room.Price = int.Parse(dt.Rows[0]["Price"].ToString());
            Room.Type = dt.Rows[0]["Type"].ToString();
            Room.Note = dt.Rows[0]["Note"].ToString();
            Room.Status = dt.Rows[0]["Status"].ToString();

            return Room;
        }

        public static DataTable LoadFreeRoomList()
        {
            return SQLHelper.Get("SELECT * FROM [Room] WHERE [Status]='空闲'");
        }

        public static DataTable LoadSelectedRoom(Model.Room Room)
        {
            return SQLHelper.Get("SELECT * FROM [Room] WHERE ID="+Room.ID);
        }

    }
}
