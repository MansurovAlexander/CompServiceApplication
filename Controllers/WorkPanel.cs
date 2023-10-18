using CompServiceApplication.Interfaces;
using CompServiceApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Threading.Tasks;

namespace CompServiceApplication.Controllers
{
    public class WorkPanel : Controller
    {
        private readonly ITaskOrderRepository _taskOrderRepository;
        private readonly IInWorkRepository _inWorkRepository;
        private readonly IUserInWorkRepository _userInWorkRepository;
        private readonly IWareHouseRepository _warehouseRepository;
        private readonly IUsedPartRepository _usedPartRepository;
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IPartToOrderRepository _partToOrderRepository;
        public WorkPanel(ITaskOrderRepository taskOrderRepository, IInWorkRepository inWorkRepository, IUserInWorkRepository userInWorkRepository, IWareHouseRepository wareHouseRepository, IUsedPartRepository usedPartRepository,
            IPurchaseOrderRepository purchaseOrderRepository, IPartToOrderRepository partToOrderRepository)
        {
            _taskOrderRepository = taskOrderRepository;
            _inWorkRepository = inWorkRepository;
            _userInWorkRepository = userInWorkRepository;
            _warehouseRepository = wareHouseRepository;
            _usedPartRepository = usedPartRepository;
            _purchaseOrderRepository = purchaseOrderRepository;
            _partToOrderRepository = partToOrderRepository;
        }
        public async Task<IActionResult> WorkerTaskList()//сделать триггер на проверку количества деталей
        {
            return View("WorkPanel\\WorkerTaskList");
        }
        public async Task<IActionResult> TakeTask(int taskid)//метод принятия заказа в работу
        {
            var task=_taskOrderRepository.GetByID(taskid);
            task.Result.status = "В работе";
            if (_taskOrderRepository.Update(task.Result).Result)
            {
                var inWorkResponse = _inWorkRepository.FindByTaskID(taskid).Result;
                if (inWorkResponse!=null)
                {
                    var userInWork = new UserInWork();
                    userInWork.startdate = DateTime.Now;
                    userInWork.userid = Int32.Parse(User.Identity.Name);
                    userInWork.workid = inWorkResponse.workid;
                    await _userInWorkRepository.Create(userInWork);
                }
                else
                {
                    var newInWork=new InWork();
                    newInWork.taskorderid = taskid;
                    newInWork.workstagedescription = "Taken";
                    if (_inWorkRepository.Create(newInWork).Result)
                    {
                        var userInWork = new UserInWork();
                        userInWork.startdate = DateTime.Now;
                        userInWork.userid = Int32.Parse(User.Identity.Name);
                        userInWork.workid = _inWorkRepository.FindByTaskID(taskid).Result.workid;
                        await _userInWorkRepository.Create(userInWork);
                    }
                }
            }
            return View("WorkPanel\\WorkerTaskList");
        }

        public async Task<IActionResult> CancelTask(int taskid)//метод отказа от заказа
        {
            var userinwork = _userInWorkRepository.FindLastByUserAndTaskID(int.Parse(User.Identity.Name), taskid).Result;
            if (userinwork != null)
            {
                userinwork.enddate = DateTime.Now;
                await _userInWorkRepository.Update(userinwork);
                var taskOrder=_taskOrderRepository.GetByID(taskid).Result;
                taskOrder.status = "открыт";
                await _taskOrderRepository.Update(taskOrder);
            }
            return View("WorkPanel\\AcceptedTasks");
        }
        public async Task<IActionResult> TakeParts(WareHouseViewModel parts)//сделать триггер на проверку количества деталей
        {
            foreach (var part in parts.partid)
            {
                int partId = part, partsCount = parts.partscount;
                var partData=_warehouseRepository.GetByID(partId).Result;
                if (partData.partscount > partsCount)
                    partData.partscount -= partsCount;
                else if (partData.partscount == partsCount)
                {

                }
                await _warehouseRepository.Update(partData);
                var work = _inWorkRepository.FindByTaskID(parts.taskorderid).Result;
                UsedPart partsInWork = new UsedPart();
                partsInWork.partid = partId;
                partsInWork.usedpartscount = partsCount;
                partsInWork.workid = work.workid;
                partsInWork.totalcost = partsCount * partData.partcost;
                await _usedPartRepository.Create(partsInWork);
            }
            return View("WorkPanel\\AcceptedTasks");
        }
        public async Task<IActionResult> OrderParts(WareHouseViewModel orderedParts)//попробовать сделать заказ на разные виды деталей
        {
            PurchaseOrder purchaseOrder = new();
            purchaseOrder.ordereduserid = int.Parse(User.Identity.Name);
            purchaseOrder.confirmeduserid = null;
            purchaseOrder.dateoforder = DateTime.Now;
            purchaseOrder.status = "Создан";
            purchaseOrder.statuschangedate = DateTime.Now;
            await _purchaseOrderRepository.Create(purchaseOrder);
            var purchaseOrderLastID = _purchaseOrderRepository.GetLast().Result.purchaseorderid;
            foreach (var part in orderedParts.partid)
            {
                PartToOrder partsInOrder = new();
                partsInOrder.purchaseorderid = purchaseOrderLastID;
                partsInOrder.partid = part;
                partsInOrder.partstoordercount = orderedParts.partscount;
                partsInOrder.totalcost = orderedParts.partscount * _warehouseRepository.GetPartCostByID(part);
                await _partToOrderRepository.Create(partsInOrder);
            }
            return View("WorkPanel\\AcceptedTasks");
        }
        public IActionResult WareHouse()
        {
            SelectList parts = new SelectList(from p in _warehouseRepository.GetAll().Result
                                              select new
                                              {
                                                  PartID = p.partid,
                                                  PartData = "Производитель: " + p.manufacturer
                                                  + "\tОписание: " + p.partname + "\tКоличество на складе: " + p.partscount.ToString()
                                                  + "\tСтоимость детали: " + p.partcost.ToString()
                                              },
                                              "PartID",
                                              "PartData",
                                              null
                                              );
            ViewBag.Parts = parts;
            return View("WorkPanel\\OrderParts");
        }
        public async Task<IActionResult> CloseTask(int taskid)
        {
            var userID = int.Parse(User.Identity.Name);
            var taskOrder = _taskOrderRepository.GetByID(taskid).Result;
            var userinwork = _userInWorkRepository.FindLastByUserAndTaskID(userID, taskid).Result;
            userinwork.enddate = DateTime.Now;
            await _userInWorkRepository.Update(userinwork);
            taskOrder.status = "Закрыт рабочим";
            await _taskOrderRepository.Update(taskOrder);
            return View("WorkPanel\\AcceptedTasks");
        }
        /*
        public Task<IActionResult> PlaceOrder(WareHouseViewModel orderedPart)//попробовать сделать заказ на разные виды деталей
        {

        }
        public async Task<IActionResult> CancelTask(int taskid)
        {
            var inworkid = _db.inwork.First(w => w.taskorderid == taskid).workid;
            var userinwork = _db.userinwork.OrderBy(uw => uw.userinworkid).Last(uw => uw.workid == inworkid);
            userinwork.enddate = DateTime.Now;
            _db.userinwork.Update(userinwork);
            await _db.SaveChangesAsync();
            return View();
        }
        public async Task<IActionResult> AddRepairType(int taskorderid, int repairid)
        {
            var inworkid = _db.inwork.First(w => w.taskorderid == taskorderid).workid;
            var repairinwork=new RepairInWork();
            repairinwork.workid = inworkid;
            repairinwork.repairid=repairid;
            _db.repairinwork.Add(repairinwork);
            await _db.SaveChangesAsync();
            return View("WorkPanel\\AcceptedTasks");
        }*/
        public IActionResult AcceptedTasks()
        {
            return View("WorkPanel\\AcceptedTasks");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
