using CompServiceApplication.Classes;
using CompServiceApplication.Interfaces;
using CompServiceApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Components
{
    public class ClosedTasks : ViewComponent
    {
        private readonly ITaskOrderRepository _taskOrderRepository;
        private readonly IVisualFlowRepository _visualFlowRepository;
        private readonly IUserRepository _userRepository;
        public ClosedTasks(ITaskOrderRepository taskOrderRepository, IVisualFlowRepository visualFlowRepository, IUserRepository userRepository)
        {
            _taskOrderRepository = taskOrderRepository;
            _visualFlowRepository = visualFlowRepository;
            _userRepository = userRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()//choiced true-вывод задач конкретного пользователя false-вывод свободных задач
        {
            var closedTaskOrders = _taskOrderRepository.GetAllClosedByWorker().Result;
            List<TaskViewModel> tasksViewModel = new();
            foreach (var closedTaskOrder in closedTaskOrders)
            {
                TaskViewModel taskViewModel = new();
                taskViewModel.taskorderid=closedTaskOrder.taskorderid;
                taskViewModel.createdate = closedTaskOrder.createdate;
                taskViewModel.problemdescription=closedTaskOrder.problemdescription;
                taskViewModel.clientdata = _userRepository.GetUserDataByID(closedTaskOrder.userid);
                taskViewModel.lastworker= _taskOrderRepository.GetLastWorkerByTaskID(closedTaskOrder.taskorderid);
                taskViewModel.images = new();
                var visualFlows=_visualFlowRepository.GetAllByTaskID(closedTaskOrder.taskorderid).Result;
                foreach (var visualFlow in visualFlows)
                {
                    taskViewModel.images.Add(ImageConverter.ByteToImage(visualFlow.visualflow, visualFlow.imageextension));
                }
                tasksViewModel.Add(taskViewModel);
            }
            return View("ClosedTasks",tasksViewModel);
        }
    }
}
