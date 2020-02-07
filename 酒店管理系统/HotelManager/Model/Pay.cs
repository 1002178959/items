using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model
{
    public class Pay
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Total { get; set; }
        public string Note { get; set; }
        public int RoomID { get; set; }
        public int CheckInID { get; set; }
        public int CustomerID { get; set; }
    }
}
