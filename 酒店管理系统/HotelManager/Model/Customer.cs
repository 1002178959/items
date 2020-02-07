using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string IDType { get; set; }
        public string IDNumber { get; set; }
        public string Note { get; set; }
        public string PhoneNumber { get; set; }
    }
}
