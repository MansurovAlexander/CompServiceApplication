using CompServiceApplication.Models;
using Microsoft.AspNetCore.Mvc;
using CompServiceApplication.Classes;
using CompServiceApplication.Interfaces;

namespace CompServiceApplication.Components
{
    public class TaskList:ViewComponent
	{
		private readonly ITaskOrderRepository _taskOrderRepository;
		private readonly IVisualFlowRepository _visualFlowRepository;
		public TaskList(ITaskOrderRepository taskOrderRepository, IVisualFlowRepository visualFlowRepository)
		{
			_taskOrderRepository = taskOrderRepository;
			_visualFlowRepository = visualFlowRepository;
		}
		public async Task<IViewComponentResult> InvokeAsync(bool choiced)//choiced true-вывод задач конкретного пользователя false-вывод свободных задач
		{
			if (!choiced)
			{
				var taskList=_taskOrderRepository.GetOpenedTaskOrders();
				var taskViewModelList=new List<TaskViewModel>();
				foreach(var task in taskList.Result)
                {
                    var newTask = new TaskViewModel();
                    newTask.taskorderid = task.taskorderid;
                    newTask.createdate = task.createdate;
                    newTask.problemdescription = task.problemdescription;
                    newTask.images = new();
                    newTask.taken = false;
                    foreach (var image in _visualFlowRepository.GetAllByTaskID(task.taskorderid).Result)
                    {
                        newTask.images.Add(ImageConverter.ByteToImage(image.visualflow, image.imageextension));
                    }
                    taskViewModelList.Add(newTask);
                }
				return View("TaskList.cshtml", taskViewModelList);
			}
			else
			{
                var taskList = _taskOrderRepository.GetTaskOrdersByWorker(int.Parse(User.Identity.Name));
                var taskViewModelList = new List<TaskViewModel>();
                foreach (var task in taskList)
                {
                    var newTask = new TaskViewModel();
                    newTask.taskorderid = task.taskorderid;
                    newTask.createdate = task.createdate;
                    newTask.problemdescription = task.problemdescription;
                    newTask.images = new();
                    newTask.taken = true;
                    foreach (var image in _visualFlowRepository.GetAllByTaskID(task.taskorderid).Result)
                    {
                        newTask.images.Add(ImageConverter.ByteToImage(image.visualflow, image.imageextension));
                    }
                    taskViewModelList.Add(newTask);
                }
                return View("TaskList.cshtml", taskViewModelList);
            }
		}
	}
}
