using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Components.CreatePanel
{
    public class CreateDevice : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("CreatePanel\\CreateDevice.cshtml");
        }
    }
}
