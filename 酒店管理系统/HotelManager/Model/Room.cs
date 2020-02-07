using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model
{
    public class Room
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
    }
}
