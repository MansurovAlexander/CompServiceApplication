using CompServiceApplication.Models;
using Microsoft.AspNetCore.Mvc;
using CompServiceApplication.Classes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CompServiceApplication.Components
{
	public class TaskList:ViewComponent
	{
		AppDatabaseContext _db;
		public TaskList(AppDatabaseContext db)
		{ _db = db; }
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var taskList = new List<TaskViewModel>();
			var taskOrders = _db.taskorders.ToList();
			foreach (var task in taskOrders)
			{
                var inWork=_db.inwork.Where(w=>w.taskorderid==task.taskorderid).ToList();
				if (inWork.Count==0)
				{
					var newTask = new TaskViewModel();
					newTask.taskorderid = task.taskorderid;
					newTask.createdate = task.createdate;
					newTask.problemdescription = task.problemdescription;
					newTask.images = new();
					foreach (var image in _db.visualflows.Where(p => p.taskorderid == task.taskorderid))
					{
						newTask.images.Add(ImageConverter.ByteToImage(image.visualflow, image.imageextension));
					}
					taskList.Add(newTask);
				}
			}
			return View("\\TaskList.cshtml", taskList);
		}
	}
}
