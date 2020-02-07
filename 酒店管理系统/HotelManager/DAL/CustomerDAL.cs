using System.Data;

namespace HotelManager.DAL
{
    public static class CustomerDAL
    {
        public static void InsertCustomer(Model.Customer Customer)
        {
            string sqlstr = "INSERT INTO[Customer]([Name],[Sex],[IDType],[IDNumber],[Note],[PhoneNumber]) VALUES('_Name', '_Sex', '_IDType', '_IDNumber','_Note','_PhoneNumber')";

            sqlstr = sqlstr.Replace("_Name", Customer.Name.ToString());
            sqlstr = sqlstr.Replace("_Sex", Customer.Sex.ToString());
            sqlstr = sqlstr.Replace("_IDType", Customer.IDType.ToString());
            sqlstr = sqlstr.Replace("_IDNumber", Customer.IDNumber.ToString());
            sqlstr = sqlstr.Replace("_Note", Customer.Note.ToString());
            sqlstr = sqlstr.Replace("_PhoneNumber", Customer.Note.ToString());

            SQLHelper.Set(sqlstr);

        }

        public static Model.Customer LoadInsertCustomer(Model.Customer Customer)
        {
            DataTable dt = SQLHelper.Get("SELECT MAX([ID]) FROM [Customer]");

            Customer.ID=int.Parse(dt.Rows[0][0].ToString());

            return Customer;

        }

        public static Model.Customer LoadCustomerInfo(Model.Customer Customer)
        {
            DataTable dt = SQLHelper.Get("SELECT * FROM [Customer] WHERE [ID]="+Customer.ID.ToString());

            Customer.ID = int.Parse(dt.Rows[0]["ID"].ToString());
            Customer.Name = dt.Rows[0]["Name"].ToString();
            Customer.Sex = dt.Rows[0]["Sex"].ToString();
            Customer.IDType = dt.Rows[0]["IDType"].ToString();
            Customer.IDNumber = dt.Rows[0]["IDNumber"].ToString();
            Customer.Note = dt.Rows[0]["Note"].ToString();
            Customer.PhoneNumber = dt.Rows[0]["PhoneNumber"].ToString();

            return Customer;
        }

        public static void UpdateCustomer(Model.Customer Customer)
        {
            string sqlstr = "UPDATE [Customer] SET [Name]='_Name',[Sex]='_Sex',[IDType]='_IDType',[IDNumber]='_IDNumber',[Note]='_Note',[PhoneNumber]='_PhoneNumber' WHERE [ID]=" + Customer.ID;

            sqlstr = sqlstr.Replace("_Name", Customer.Name.ToString());
            sqlstr = sqlstr.Replace("_Sex", Customer.Sex.ToString());
            sqlstr = sqlstr.Replace("_IDType", Customer.IDType.ToString());
            sqlstr = sqlstr.Replace("_IDNumber", Customer.IDNumber.ToString());
            sqlstr = sqlstr.Replace("_Note", Customer.Note.ToString());
            sqlstr = sqlstr.Replace("_PhoneNumber", Customer.PhoneNumber.ToString());

            SQLHelper.Set(sqlstr);
        }
    }
}
