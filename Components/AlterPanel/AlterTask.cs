using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompServiceApplication.Components.AlterPanel
{
    public class AlterTask : ViewComponent
    {
        AppDatabaseContext _db;
        public AlterTask(AppDatabaseContext db)
        { _db = db; }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            SelectList tasks = new SelectList(from t in _db.taskorders.ToList()
                                              select new
                                              {
                                                  TaskID = t.taskorderid,
                                                  TaskData = "Дата создания: " + t.createdate.ToString() + "\tОписание проблемы: " + t.problemdescription
                                              },
                "TaskID",
                "TaskData",
                null);
            ViewBag.Tasks = tasks;
            SelectList users = new SelectList(from u in _db.users.ToList()
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
            return View("AlterPanel\\AlterTask.cshtml");
        }
    }
}
