using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using CompServiceApplication.Interfaces;

namespace CompServiceApplication.Components.AlterPanel
{
    public class AlterUser:ViewComponent
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserTypeRepository _userTypeRepository;
        public AlterUser(IUserRepository userRepository, IUserTypeRepository userTypeRepository)
        {
            _userRepository = userRepository;
            _userTypeRepository = userTypeRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            SelectList users = new SelectList(from u in _userRepository.GetAll().Result
                                              select new
                                              {
                                                  UserID = u.userid,
                                                  UserData = u.lastname + " " + u.firstname + " " + u.middlename +" " + u.dateofbirth.ToString() + " "
                                                  + u.phonenumber.ToString() +" " + u.passseries.ToString() + " " + u.passnum.ToString()
                                                  +" "+u.userlogin
                                              },
                "UserID",
                "UserData",
                null);
            ViewBag.Users = users; 
            SelectList usertypes = new SelectList(_userTypeRepository.GetAll().Result, "usertypeid", "usertypename");
            ViewBag.UserTypes = usertypes;
            return View("AlterPanel\\AlterUser.cshtml");
        }
    }
}
