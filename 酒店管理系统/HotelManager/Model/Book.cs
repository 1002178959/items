using System;

namespace HotelManager.Model
{
    public class Book
    {
        public int ID { get; set; }
        public int RoomID { get; set; }
        public int CustomerID { get; set; }
        public string Time { get; set; }
        public int Days { get; set; }
        public string Note { get; set; }
    }
}
