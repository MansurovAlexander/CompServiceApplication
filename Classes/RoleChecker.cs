using CompServiceApplication.Models;

namespace CompServiceApplication.Classes
{
    public static class RoleChecker
    {
        public static string Check(User user, AppDatabaseContext db)
        {
            List<User> users=db.users.ToList();
            int roleNumber=0;
            foreach (User model in db.users)
            {
                if (model.userlogin==user.userlogin && model.userpassword==HashPasswordHelper.HashPassword(user.userpassword)) 
                {
                    roleNumber = model.usertypeid;
                }
            }
            foreach (UserType type in db.usertypes)
            {
                if (type.usertypeid == roleNumber)
                    return type.usertypename;
            }
            return "";
        }
    }
}
