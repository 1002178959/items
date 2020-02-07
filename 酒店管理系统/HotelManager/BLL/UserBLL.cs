using System.Data;

namespace HotelManager.BLL
{
    public static class UserBLL
    {
        public static int LoginVerify(Model.User User) //验证
        {
            DataTable dt;

            dt = DAL.UserDAL.UsernameVerify(User); //验证用户名

            if (dt.Rows.Count > 0)
            {
                dt = DAL.UserDAL.PasswordVerify(User); //验证密码

                if (dt.Rows.Count > 0)
                {
                    User.Name = dt.Rows[0]["Name"].ToString();
                    User.Permission = int.Parse(dt.Rows[0]["Permission"].ToString());
                    return 2; //密码正确
                }

                else
                {
                    return 1; //密码错误
                }
            }

            else
            {
                return 0; //用户名不存在
            }
        }
    }
}

