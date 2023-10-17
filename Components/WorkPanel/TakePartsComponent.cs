using CompServiceApplication.Interfaces;
using CompServiceApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompServiceApplication.Components.WorkPanel
{
    public class TakePartsComponent:ViewComponent
    {
        private readonly IWareHouseRepository _wareHouseRepository;
        private readonly ITaskOrderRepository _taskOrderRepository;
        public TakePartsComponent(IWareHouseRepository wareHouseRepository, ITaskOrderRepository taskOrderRepository)
        {
            _wareHouseRepository = wareHouseRepository;
            _taskOrderRepository = taskOrderRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            SelectList parts = new SelectList(from p in _wareHouseRepository.GetAll().Result
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
            var tasOrdersByUser=_taskOrderRepository.GetTaskOrdersByWorker(int.Parse(User.Identity.Name));
            SelectList tasks = new SelectList(from t in tasOrdersByUser
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
            return View("\\TakeParts.cshtml");
        }
    }
}
