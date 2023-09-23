using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Controllers
{
	public class Admin : Controller
	{
		AppDatabaseContext _db;
		public Admin(AppDatabaseContext db)
		{
			_db = db;
		}
		public IActionResult CreateUser() {
			return View();
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
