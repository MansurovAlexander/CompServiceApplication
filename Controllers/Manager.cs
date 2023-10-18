using CompServiceApplication.Classes;
using CompServiceApplication.Interfaces;
using CompServiceApplication.Models;
using CompServiceApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Controllers
{
    public class Manager : Controller
    {
        private readonly ITaskOrderRepository _taskOrderRepository;
        private readonly IVisualFlowRepository _visualFlowRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        public Manager(IPurchaseOrderRepository purchaseOrderRepository, ITaskOrderRepository taskOrderRepository, IVisualFlowRepository visualFlowRepository, IUserRepository userRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
            _taskOrderRepository = taskOrderRepository;
            _visualFlowRepository = visualFlowRepository;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> ConfirmPurchaseOrder(int purchaseOrderID)
        {
            var purchaseOrder=_purchaseOrderRepository.GetByID(purchaseOrderID).Result;
            purchaseOrder.confirmeduserid = int.Parse(User.Identity.Name);
            purchaseOrder.status = "Подтвержден";
            purchaseOrder.statuschangedate = DateTime.Now;
            await _purchaseOrderRepository.Update(purchaseOrder);
            return View("\\CreatePanel");
        }
        public async Task<IActionResult> DenyPurchaseOrder(int purchaseOrderID)
        {
            var purchaseOrder = _purchaseOrderRepository.GetByID(purchaseOrderID).Result;
            purchaseOrder.confirmeduserid = int.Parse(User.Identity.Name);
            purchaseOrder.status = "Отказано";
            purchaseOrder.statuschangedate = DateTime.Now;
            await _purchaseOrderRepository.Update(purchaseOrder);
            return View("\\CreatePanel");
        }
        public async Task<IActionResult> CloseTask(int taskid)
        {
            var task=_taskOrderRepository.GetByID(taskid).Result;
            task.enddate= DateTime.Now;
            task.status = "Закрыт";
            await _taskOrderRepository.Update(task);
            return View("\\ClosedTasks");
        }
        public async Task<IActionResult> CancelClose(int taskid)
        {
            var task = _taskOrderRepository.GetByID(taskid).Result;
            task.status = "Открыт";
            await _taskOrderRepository.Update(task);
            return View("\\ClosedTasks");
        }
        public IActionResult ClosedTasks()
        {
            var closedTaskOrders = _taskOrderRepository.GetAllClosedByWorker().Result;
            List<TaskViewModel> tasksViewModel = new();
            foreach (var closedTaskOrder in closedTaskOrders)
            {
                TaskViewModel taskViewModel = new();
                taskViewModel.taskorderid = closedTaskOrder.taskorderid;
                taskViewModel.createdate = closedTaskOrder.createdate;
                taskViewModel.problemdescription = closedTaskOrder.problemdescription;
                taskViewModel.clientdata = _userRepository.GetUserDataByID(closedTaskOrder.userid);
                taskViewModel.lastworker = _taskOrderRepository.GetLastWorkerByTaskID(closedTaskOrder.taskorderid);
                taskViewModel.images = new();
                var visualFlows = _visualFlowRepository.GetAllByTaskID(closedTaskOrder.taskorderid).Result;
                foreach (var visualFlow in visualFlows)
                {
                    taskViewModel.images.Add(ImageConverter.ByteToImage(visualFlow.visualflow, visualFlow.imageextension));
                }
                tasksViewModel.Add(taskViewModel);
            }
            return View(tasksViewModel);
        }
        public IActionResult CreatePanel()
        {
            return View();
        }
        public IActionResult AlterPanel()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
