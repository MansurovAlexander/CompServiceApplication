using CompServiceApplication.Classes;
using CompServiceApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore;

namespace CompServiceApplication.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly AppDatabaseContext _db;
        public AuthorizationController(AppDatabaseContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            string role = RoleChecker.Check(user, _db).ToLower();
            switch (role)
            {
                case "admin":
                    {
                        Redirect("/Pages/Views/AdminView.cshtml");
                        break;
                    }
                case "worker":
                    {
                        Redirect("/Pages/Views/AdminView.cshtml");
                        break;
                    }
                case "manager":
                    {
                        Redirect("/Pages/Views/AdminView.cshtml");
                        break;
                    }
                case "":
                    {
                        return View();
                    }
            }
            return View();
        }
        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
