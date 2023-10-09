using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Components.CreatePanel
{
    public class CreateRepairType : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("CreatePanel\\CreateRepairType.cshtml");
        }
    }
}
