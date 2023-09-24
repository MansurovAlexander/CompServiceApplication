using CompServiceApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompServiceApplication.Controllers
{
	public class Admin : Controller
	{
		AppDatabaseContext _db;
		public Admin(AppDatabaseContext db)
		{
			_db = db;
		}
		public IActionResult CreateDevice()
		{
			return View();
		}
		public IActionResult CreateUser() {
			//ViewBag.UserTypes = new SelectList(_db.usertypes.ToList(), "ID", "UserType");
			SelectList usertypes=new SelectList(_db.usertypes.ToList(), "usertypeid", "usertypename");
			ViewBag.UserTypes = usertypes;
            return View();
		}
		public IActionResult Index()
		{
			return View();
		}

        
    }
}
