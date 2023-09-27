using CompServiceApplication.Classes;
using CompServiceApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompServiceApplication.Controllers
{
	public class Admin : Controller
	{
		AppDatabaseContext _db;
		public Admin(AppDatabaseContext db)
		{
			_db = db;
		}
		public IActionResult CreateDevice()
		{
			return View();
		}
		public IActionResult CreateUser() {
			//ViewBag.UserTypes = new SelectList(_db.usertypes.ToList(), "ID", "UserType");
			SelectList usertypes=new SelectList(_db.usertypes.ToList(), "usertypeid", "usertypename");
			ViewBag.UserTypes = usertypes;
            return View();
		}
        public IActionResult CreateTask()
        {
            SelectList users = new SelectList((from u in _db.users.ToList() select new
            {
                UserID = u.userid,
                UserData = u.lastname+" "+u.firstname+" "+u.middlename + " "+u.passseries.ToString() +" "+u.passnum.ToString()}),
                "UserID",
                "UserData",
				null);
            ViewBag.Users = users;
            SelectList devices = new SelectList(from d in _db.devices.ToList() select new
            {
                DeviceID = d.deviceid,
                DeviceData = d.manufacturer+" "+d.serialnumber+" "+d.devicedescription},
                "DeviceID",
                "DeviceData",
				null);
            ViewBag.Devices = devices;
            return View();
        }
        public IActionResult TaskList()
        {
            var taskList=new List<TaskViewModel>();
            foreach (var task in _db.taskorders)
            {
                var newTask=new TaskViewModel();
                newTask.taskorderid=task.taskorderid;
                newTask.createdate = task.createdate;
                newTask.problemdescription = task.problemdescription;
                foreach (var image in _db.visualflows.Where(p=>p.taskorderid==task.taskorderid))
                {
                    newTask.images.Add(ImageConverter.ByteToImage(Convert.FromBase64String(image.visualflow)));
                }
            }
            return View(taskList);
        }
        public IActionResult Index()
		{
			return View();
		}

        
    }
}
