using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompServiceApplication.Components.CreatePanel
{
    public class CreateUser : ViewComponent
    {
        AppDatabaseContext _db;
        public CreateUser(AppDatabaseContext db)
        { _db = db; }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            SelectList usertypes = new SelectList(_db.usertypes.ToList(), "usertypeid", "usertypename");
            ViewBag.UserTypes = usertypes;
            return View("CreatePanel\\CreateUser.cshtml");
        }
    }
}
