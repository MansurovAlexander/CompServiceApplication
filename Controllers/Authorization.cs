using CompServiceApplication.Classes;
using CompServiceApplication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace CompServiceApplication.Controllers
{
    public class Authorization : Controller
    {
        private readonly AppDatabaseContext _db;
        public Authorization(AppDatabaseContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Login(UserLoginView user)
        {
			RoleChecker.Check(user, _db);
				var result = Authentification(user);
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(result));
				switch (user.UserRole.ToLower())
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

		private ClaimsIdentity Authentification(UserLoginView user)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserLogin),
			new Claim(ClaimsIdentity.DefaultRoleClaimType, user.UserRole)
			};
			return new ClaimsIdentity(claims, "Undefined");
		}
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> LogOut()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Authorization");
		}

		public IActionResult Index()
        {
            return View();
        }
    }
}
