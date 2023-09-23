using CompServiceApplication.Classes;
using CompServiceApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CompServiceApplication.Controllers
{
    public class Authorization : Controller
    {
        private readonly AppDatabaseContext _db;
        public Authorization(AppDatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Login(User user)
        {
            string role = RoleChecker.Check(user, _db).ToLower();
            switch (role)
            {
                case "admin":
                    {
                        return Redirect("~/Admin");
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
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
