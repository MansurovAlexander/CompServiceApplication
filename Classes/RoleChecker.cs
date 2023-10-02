using CompServiceApplication.Models;

namespace CompServiceApplication.Classes
{
    public static class RoleChecker
    {
        public static void Check(UserLoginView user, AppDatabaseContext db)
        {;
            user.UserRole = "";
            int roleNumber=0;
            foreach (User model in db.users)
            {
                if (model.userlogin==user.UserLogin && model.userpassword==HashPasswordHelper.HashPassword(user.UserPassword)) 
                {
                    user.UserID = model.userid;
                    roleNumber = model.usertypeid;
                }
            }
            foreach (UserType type in db.usertypes)
            {
                if (type.usertypeid == roleNumber)
                    user.UserRole = type.usertypename;
            }
        }
    }
}
