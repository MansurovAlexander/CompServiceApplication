using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Components.AlterPanel
{
    public class AlterUser:ViewComponent
    {
        AppDatabaseContext _db;
        public AlterUser(AppDatabaseContext db)
        { _db = db; }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            SelectList users = new SelectList(from u in _db.users.ToList()
                                              select new
                                              {
                                                  UserID = u.userid,
                                                  UserData = u.lastname + " " + u.firstname + " " + u.middlename +" " + u.dateofbirth.ToString() + " "
                                                  + u.phonenumber.ToString() +" " + u.passseries.ToString() + " " + u.passnum.ToString()
                                                  +" "+u.userlogin
                                              },
                "UserID",
                "UserData",
                null);
            ViewBag.Users = users; 
            SelectList usertypes = new SelectList(_db.usertypes.ToList(), "usertypeid", "usertypename");
            ViewBag.UserTypes = usertypes;
            return View("AlterPanel\\AlterUser.cshtml");
        }
    }
}
