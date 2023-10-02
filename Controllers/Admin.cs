using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Controllers
{
	public class Admin : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
