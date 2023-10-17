using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Components.CreatePanel
{
    public class CreateUserType : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("CreatePanel\\CreateUserType.cshtml");
        }
    }
}
