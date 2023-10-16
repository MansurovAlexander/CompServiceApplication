using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompServiceApplication.Components.CreatePanel
{
    public class CreateTask : ViewComponent
    {
        AppDatabaseContext _db;
        public CreateTask(AppDatabaseContext db)
        { _db = db; }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int roleid = _db.usertypes.First(ut => ut.usertypename == "Client").usertypeid;
            SelectList users = new SelectList(from u in _db.users.Where(u=>u.usertypeid==roleid).ToList()
                                               select new
                                               {
                                                   UserID = u.userid,
                                                   UserData = u.lastname + " " + u.firstname + " " + u.middlename + " " + u.passseries.ToString() + " " + u.passnum.ToString()
                                               },
                "UserID",
                "UserData",
                null);
            ViewBag.Users = users;
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
            return View("CreatePanel\\CreateTask.cshtml");
        }
    }
}
