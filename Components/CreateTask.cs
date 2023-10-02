using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompServiceApplication.Components
{
	public class CreateTask:ViewComponent
	{
		AppDatabaseContext _db;
		public CreateTask(AppDatabaseContext db)
		{ _db = db; }
		public async Task<IViewComponentResult> InvokeAsync()
		{
			SelectList users = new SelectList((from u in _db.users.ToList()
											   select new
											   {
												   UserID = u.userid,
												   UserData = u.lastname + " " + u.firstname + " " + u.middlename + " " + u.passseries.ToString() + " " + u.passnum.ToString()
											   }),
				"UserID",
				"UserData",
				null);
			ViewBag.Users = users;
			SelectList devices = new SelectList(from d in _db.devices.ToList()
												select new
												{
													DeviceID = d.deviceid,
													DeviceData = d.manufacturer + " " + d.serialnumber + " " + d.devicedescription
												},
				"DeviceID",
				"DeviceData",
				null);
			ViewBag.Devices = devices;
			return View("\\CreateTask.cshtml");
		}
	}
}
