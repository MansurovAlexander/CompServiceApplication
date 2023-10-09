using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompServiceApplication.Components.AlterPanel
{
    public class AlterDevice : ViewComponent
    {
		AppDatabaseContext _db;
		public AlterDevice(AppDatabaseContext db)
		{
			_db = db;
		}
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
			return View("AlterPanel\\AlterDevice.cshtml");
        }
    }
}
