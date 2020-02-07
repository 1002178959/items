using System.Data;
using System.Linq;

namespace HotelManager.BLL
{
    public static class RoomBLL
    {
        private static DataTable DTRename(DataTable Source) 
        {
            Source.Columns["Number"].ColumnName = "房间号";
            Source.Columns["Price"].ColumnName = "单价";
            Source.Columns["Type"].ColumnName = "类型";
            Source.Columns["Status"].ColumnName = "状态";
            Source.Columns["Note"].ColumnName = "备注";
            return Source;
        }

        public static DataTable LoadRoomList()
        {
            DataTable dt = DAL.RoomDAL.LoadRoomList();
            DTRename(dt);
            return dt;
        }

        public static int[] LoadRoomStatus()
        {
            DataTable dt = DAL.RoomDAL.LoadRoomList();
            int[] Status = new int[4];
            Status[0] = dt.Rows.Count;
            Status[1] = dt.Select("Status = '预订'").Count();
            Status[2] = dt.Select("Status = '入住'").Count(); ;

            float a = Status[2];
            float b = Status[0];

            Status[3] = (int)((a / b) * 100);

            return Status;
        }

        public static DataTable QueryRoom(Model.Room Room)
        {
            DataTable dt = DAL.RoomDAL.LoadRoomList();
            DataTable newdt = dt.Clone();
            string SelectStr = null;

            int a = Room.Number;


            if (Room.Number != 0)
            {
                SelectStr += "Number=" + Room.Number + "_";
            }

            if (Room.Price != 0)
            {
                SelectStr += "Price=" + Room.Price + "_";
            }

            if (Room.Type != null)
            {
                SelectStr += "Type='" + Room.Type + "'_";
            }

            if (Room.Note != null)
            {
                SelectStr += "Note='" + Room.Note + "'_";
            }

            if (Room.Status != null)
            {
                SelectStr += "Status='" + Room.Status + "'_";
            }

            if (SelectStr != null)
            {
                SelectStr = SelectStr.Replace("_", " and ");
                SelectStr = SelectStr.Remove(SelectStr.Length - 5, 5);
                DataRow[] rows = dt.Select(SelectStr);
                foreach (DataRow row in rows)
                {
                    newdt.Rows.Add(row.ItemArray);
                }

                return DTRename(newdt);
            }

            else
            {
                return DTRename(dt);
            }


        }

        public static void DeleteRoom(Model.Room Room)
        {
            DAL.RoomDAL.DeleteRoom(Room);
        }

        public static void InsertRoom(Model.Room Room)
        {
            DAL.RoomDAL.InsertRoom(Room);
        }

        public static void UpdateRoom(Model.Room Room)
        {
            DAL.RoomDAL.UpdateRoom(Room);
        }

        public static Model.Room LoadRoomInfo(Model.Room Room)
        {
            return DAL.RoomDAL.LoadRoomInfo(Room);
        }

        public static DataTable LoadFreeRoomList()
        {
            return DTRename(DAL.RoomDAL.LoadFreeRoomList());
        }

        public static DataTable LoadSelectedRoom(Model.Room Room)
        {
            return DTRename(DAL.RoomDAL.LoadSelectedRoom(Room));
        }
    }
}
