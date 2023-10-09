using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Controllers
{
	public class Admin : Controller
	{
		public IActionResult CreatePanel()
		{
			return View();
		}
        public IActionResult AlterPanel()
        {
            return View();
        }
        public IActionResult Index()
		{
			return View();
		}
	}
}
