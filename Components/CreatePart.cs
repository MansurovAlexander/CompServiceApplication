using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Components
{
    public class CreatePart:ViewComponent
    {
        AppDatabaseContext _db;
        public CreatePart(AppDatabaseContext db)
        { _db = db; }
        public async Task<IViewComponentResult> InvokeAsync()
        {
			SelectList devices = new SelectList(from d in _db.devices.ToList()
												select new
												{
													DeviceID = d.deviceid,
													DeviceData = d.manufacturer + " " + d.model + " " + d.devicedescription
												},
				"DeviceID",
				"DeviceData",
				null);
			ViewBag.Devices = devices;
			return View("\\CreatePart.cshtml");
        }
    }
}
