using CompServiceApplication.Models;
using Microsoft.AspNetCore.Mvc;
using CompServiceApplication.Classes;

namespace CompServiceApplication.Components
{
    public class TaskList:ViewComponent
	{
		AppDatabaseContext _db;
		public TaskList(AppDatabaseContext db)
		{ _db = db; }
		public async Task<IViewComponentResult> InvokeAsync(bool choiced)
		{
			if (!choiced)
			{
				var taskList = new List<TaskViewModel>();
				var taskOrders = _db.taskorders.ToList();
				foreach (var task in taskOrders)
				{
					var inWork = _db.inwork.Where(w => w.taskorderid == task.taskorderid).ToList();
					if (inWork.Count == 0)
					{
						var newTask = new TaskViewModel();
						newTask.taskorderid = task.taskorderid;
						newTask.createdate = task.createdate;
						newTask.problemdescription = task.problemdescription;
						newTask.images = new();
						newTask.taken = false;
						foreach (var image in _db.visualflows.Where(p => p.taskorderid == task.taskorderid))
						{
							newTask.images.Add(ImageConverter.ByteToImage(image.visualflow, image.imageextension));
						}
						taskList.Add(newTask);
					}
				}
				return View("TaskList.cshtml", taskList);
			}
			else
			{
				string userName = _db.users.First(u => u.userid == int.Parse(User.Identity.Name)).lastname+" "+ _db.users.First(u => u.userid == int.Parse(User.Identity.Name)).firstname;
                var taskList = new List<TaskViewModel>();
                var taskOrders = new List<TaskOrder>();
				var userInWork = _db.userinwork.Where(u => u.userid == int.Parse(User.Identity.Name)).ToList();
				var works = userInWork.Join(_db.inwork, uw => uw.workid, iw => iw.workid, (uw, iw) => new
				{
					task = iw.taskorderid
				});
                foreach (var work in works)
                {
					taskOrders.Add(_db.taskorders.First(t => t.taskorderid == work.task));
                }
				foreach (var task in taskOrders)
				{
					var newTask = new TaskViewModel();
					newTask.taskorderid = task.taskorderid;
					newTask.createdate = task.createdate;
					newTask.problemdescription = task.problemdescription;
					newTask.lastworker = userName;
					newTask.images = new();
					newTask.taken = true;
					foreach (var image in _db.visualflows.Where(p => p.taskorderid == task.taskorderid))
					{
						newTask.images.Add(ImageConverter.ByteToImage(image.visualflow, image.imageextension));
					}
					taskList.Add(newTask);
				}
                return View("TaskList.cshtml", taskList);
            }
		}
	}
}
