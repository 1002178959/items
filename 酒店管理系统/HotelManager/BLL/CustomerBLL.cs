using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.BLL
{
    public static class CustomerBLL
    {
        public static void InsertCustomer(Model.Customer Customer)
        {
            DAL.CustomerDAL.InsertCustomer(Customer);
        }

        public static Model.Customer LoadInsertCustomer(Model.Customer Customer)
        {
            return DAL.CustomerDAL.LoadInsertCustomer(Customer);
        }

        public static Model.Customer LoadCustomerInfo(Model.Customer Customer)
        {
            return DAL.CustomerDAL.LoadCustomerInfo(Customer);
        }

        public static void UpdateCustomer(Model.Customer Customer)
        {
            DAL.CustomerDAL.UpdateCustomer(Customer);
        }
    }
}
