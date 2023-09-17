using CompServiceApplication.Models;

namespace CompServiceApplication.Classes
{
    public static class RoleChecker
    {
        public static string Check(User user, AppDatabaseContext db)
        {
            foreach (User model in db.Users)
            {
                if (model.UserLogin==user.UserLogin && model.UserPassword==HashPasswordHelper.HashPassword(user.UserPassword)) 
                {
                    foreach (UserType type in db.UserTypes)
                    {
                        if (type.UserTypeID == model.UserTypeId)
                            return type.UserTypeName;
                    }
                }
            }
            return "";
        }
    }
}
