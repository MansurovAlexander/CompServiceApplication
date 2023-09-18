using CompServiceApplication.Classes;
using CompServiceApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Controllers
{
    public class Authorization : Controller
    {
        private readonly AppDatabaseContext _db;
        public Authorization(AppDatabaseContext db)
        {
            _db = db;
        }

        [HttpPost]
        public void Login(User user)
        {
            string role = RoleChecker.Check(user, _db).ToLower();
            switch (role)
            {
                case "admin":
                    {
                        Redirect("/Views/AdminView");
                        break;
                    }
                case "worker":
                    {
                        Redirect("/Views/AdminView");
                        break;
                    }
                case "manager":
                    {
                        Redirect("/AdminView");
                        break;
                    }
                case "":
                    {
                        Redirect("/Error");
                        break;
                    }
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
