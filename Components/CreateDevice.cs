using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Components
{
	public class CreateDevice:ViewComponent
	{

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("CreateDevice.cshtml");
		}
	}
}
