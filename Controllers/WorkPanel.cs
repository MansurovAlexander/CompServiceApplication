using CompServiceApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace CompServiceApplication.Controllers
{
    public class WorkPanel : Controller
    {
        AppDatabaseContext _db;
        public WorkPanel(AppDatabaseContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> WorkerTaskList()//сделать триггер на проверку количества деталей
        {
            return View("WorkPanel\\WorkerTaskList");
        }
        public async Task<IActionResult> TakeParts(WareHouseViewModel parts)//сделать триггер на проверку количества деталей
        {
            foreach (var part in parts.partid)
            {
                int partId = part, partsCount = parts.partscount;
                Models.Warehouse updateStr = _db.warehouse.First(p => p.partid == partId);
                updateStr.partscount -= partsCount;
                _db.warehouse.Update(updateStr);
                await _db.SaveChangesAsync();
                int workID = _db.inwork.First(w => w.taskorderid == parts.taskorderid).workid;
                Models.UsedPart partsInWork = new UsedPart();
                partsInWork.partid = partId;
                partsInWork.usedpartscount=partsCount;
                _db.usedparts.Add(partsInWork);
                await _db.SaveChangesAsync();
                Models.UsedPartsInWork usedPartsInWork = new UsedPartsInWork();
                usedPartsInWork.workid = workID;
                usedPartsInWork.usedpartid = _db.usedparts.OrderBy(u=>u.usedpartid).Last().usedpartid;
                _db.usedpartsinwork.Add(usedPartsInWork);
                await _db.SaveChangesAsync();
            }
            return View("WorkPanel\\AcceptedTasks");
        }
        /*public Task<IActionResult> PlaceOrder(Warehouse orderedPart)//попробовать сделать заказ на разные виды деталей
        {

        }*/
        public IActionResult WareHouse()
        {
            SelectList parts = new SelectList(from p in _db.warehouse.ToList()
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
            return View("WorkPanel\\WareHouse");
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
        public async Task<IActionResult> TakeTask(int taskid)
        {
            if (User.IsInRole("worker") || User.IsInRole("admin"))
            {
                var newWorkAccept = new InWork();
                newWorkAccept.taskorderid = taskid;
                newWorkAccept.workstagedescription = "Taken";
                _db.inwork.Add(newWorkAccept);
                await _db.SaveChangesAsync();
                var userInWork = new UserInWork();
                userInWork.startdate = DateTime.Now;
                userInWork.userid = Int32.Parse(User.Identity.Name);
                userInWork.workid = _db.inwork.ToList().Last().workid;
                _db.userinwork.Add(userInWork);
                await _db.SaveChangesAsync(); 
            }
            return View("WorkPanel\\WorkerTaskList");
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
        }
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
