using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Controllers
{
    public class WorkPanel : Controller
    {
        public IActionResult WareHouse()
        { 
            return View();
        }
        public IActionResult AcceptedTasks()
        {
            return View();
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}
