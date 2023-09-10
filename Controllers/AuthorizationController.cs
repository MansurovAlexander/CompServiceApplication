using CompServiceApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore;

namespace CompServiceApplication.Controllers
{
    public class AuthorizationController : Controller
    {
        private List<User> _users =new List<User>();
        private readonly AppDatabaseContext _db;
        public AuthorizationController()
        {
            _db = new AppDatabaseContext();
        }
        [HttpPost]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Users.FirstOrDefault(u => u.UserLogin == model.UserLogin && u.UserPassword == model.UserPassword);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, model.RememberMe);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Не верное имя пользователя или пароль.\");
                    return View(model);
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
