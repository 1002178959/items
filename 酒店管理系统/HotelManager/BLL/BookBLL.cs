using System.Data;

namespace HotelManager.BLL
{
    public static class BookBLL
    {
        private static DataTable DTRename(DataTable Source)
        {
            Source.Columns["Name"].ColumnName = "姓名";
            Source.Columns["PhoneNumber"].ColumnName = "电话号码";
            Source.Columns["Number"].ColumnName = "房间号";
            Source.Columns["Type"].ColumnName = "房间类型";
            Source.Columns["Time"].ColumnName = "预计时间";
            Source.Columns["Days"].ColumnName = "预计天数";
            Source.Columns["Note"].ColumnName = "备注";
            return Source;
        }

        public static DataTable LoadBookList()
        {
            return DTRename(DAL.BookDAL.LoadBookList());
        }

        public static void InsertBook(Model.Book Book)
        {
            DAL.BookDAL.InsertBook(Book);
        }

        public static Model.Book LoadBookInfo(Model.Book Book)
        {
            return DAL.BookDAL.LoadBookInfo(Book);
        }

        public static void UpdateBook(Model.Book Book)
        {
            DAL.BookDAL.UpdateBook(Book);
        }

        public static void DeleteBook(Model.Book Book)
        {
            DAL.BookDAL.LoadBookInfo(Book);

            Model.Room Room = new Model.Room() { ID = Book.RoomID };

            BLL.RoomBLL.LoadRoomInfo(Room);

            Room.Status = "空闲";

            BLL.RoomBLL.UpdateRoom(Room);

            DAL.BookDAL.DeleteBook(Book);
        }
    }
}
