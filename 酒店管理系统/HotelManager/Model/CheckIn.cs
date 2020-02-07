namespace HotelManager.Model
{
    public class CheckIn
    {
        public int ID { get; set; }
        public int RoomID { get; set; }
        public int Customer1ID { get; set; }
        public int Customer2ID { get; set; }
        public string Time { get; set; }
        public int Days { get; set; }
        public int Deposit { get; set; }
        public string Note { get; set; }
    }
}
