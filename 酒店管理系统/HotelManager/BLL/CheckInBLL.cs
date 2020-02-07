using System.Data;

namespace HotelManager.BLL
{
    public static class CheckInBLL
    {
        public static DataTable DTRename(DataTable Source)
        {
            Source.Columns["Number"].ColumnName = "房间号";
            Source.Columns["Type"].ColumnName = "房间类型";
            Source.Columns["Name"].ColumnName = "姓名";
            Source.Columns["Time"].ColumnName = "入住时间";
            Source.Columns["Days"].ColumnName = "预计天数";
            Source.Columns["Deposit"].ColumnName = "押金";

            return Source;
        }

        public static DataTable LoadCheckInList()
        {
            return DTRename(DAL.CheckInDAL.LoadCheckInList());
        }

        public static void InsertCheckIn(Model.CheckIn CheckIn)
        {
            DAL.CheckInDAL.InsertCheckIn(CheckIn);
        }

        public static Model.CheckIn LoadCheckInInfo(Model.CheckIn CheckIn)
        {
            return DAL.CheckInDAL.LoadCheckInInfo(CheckIn);
        }

        public static void UpdateCheckIn(Model.CheckIn CheckIn)
        {
            DAL.CheckInDAL.UpdateCheckIn(CheckIn);
        }

        public static void DeleteCheckIn(Model.CheckIn CheckIn)
        {
            DAL.CheckInDAL.LoadCheckInInfo(CheckIn);

            Model.Room Room = new Model.Room() { ID = CheckIn.RoomID };

            BLL.RoomBLL.LoadRoomInfo(Room);

            Room.Status = "空闲";

            BLL.RoomBLL.UpdateRoom(Room);

            DAL.CheckInDAL.DeleteCheckIn(CheckIn);
        }

        public static DataTable LoadSelectedCheckIn(Model.CheckIn CheckIn)
        {
            return DTRename(DAL.CheckInDAL.LoadSelectedCheckIn(CheckIn));
        }
    }
}
