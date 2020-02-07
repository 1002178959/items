using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model
{
    public class Cost
    {
        public int ID { get; set; }
        public int CheckInID { get; set; }
        public int GoodsID { get; set; }
        public int Number { get; set; }
        public string Time { get; set; }
        public string Note { get; set; }
    }
}
