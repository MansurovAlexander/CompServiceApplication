using CompServiceApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompServiceApplication.Components.WorkPanel
{
    public class WareHouseComponent:ViewComponent
    {
        AppDatabaseContext _db;
        public WareHouseComponent(AppDatabaseContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
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
            List<TaskOrder> taskOrders = new();
            var userWorks=_db.userinwork.Where(uw=>uw.userid==int.Parse(User.Identity.Name)).ToList();
            foreach (var work in userWorks)
            {
                int taskId=_db.inwork.First(iw=>iw.workid==work.workid).taskorderid;
                taskOrders.Add(_db.taskorders.First(to=>to.taskorderid==taskId));
            }
            SelectList tasks = new SelectList(from t in taskOrders
                                              select new
                                              {
                                                  TaskID = t.taskorderid,
                                                  TaskData = "ID: " + t.taskorderid.ToString() + "\tОписание: "
                                                  + t.problemdescription + "\tДата добавления: " + t.createdate.ToString()
                                              },
                                             "TaskID",
                                             "TaskData",
                                             null
                                             );
            ViewBag.Tasks = tasks;
            return View("WorkPanel\\WareHouse.cshtml");
        }
    }
}
