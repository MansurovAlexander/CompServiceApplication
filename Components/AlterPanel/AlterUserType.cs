using CompServiceApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompServiceApplication.Components.AlterPanel
{
    public class AlterUserType:ViewComponent
    {
        private readonly IUserTypeRepository _userTypeRepository;
        public AlterUserType(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            SelectList usertypes = new SelectList(_userTypeRepository.GetAll().Result, "usertypeid", "usertypename");
            ViewBag.UserTypes = usertypes;
            return View("AlterPanel\\AlterUserType.cshtml");
        }
    }
}
