using System.Data;

namespace HotelManager.DAL
{
    public static class UserDAL
    {
        public static DataTable UsernameVerify(Model.User User)
        {
            return SQLHelper.Get("select * from [User] where Username=" + "'" + User.Username + "'");
        }

        public static DataTable PasswordVerify(Model.User User)
        {
            return SQLHelper.Get("select * from [User] where Username=" + "'" + User.Username + "'");
        }

    }
}
