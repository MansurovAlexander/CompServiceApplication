using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Components.AlterPanel
{
    public class AlterPart : ViewComponent
    {
        AppDatabaseContext _db;
        public AlterPart(AppDatabaseContext db)
        { _db = db; }
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
            SelectList devices = new SelectList(from d in _db.devices.ToList()
                                                select new
                                                {
                                                    DeviceID = d.deviceid,
                                                    DeviceData = d.manufacturer + " " + d.model + " " + d.devicedescription
                                                },
                "DeviceID",
                "DeviceData",
                null);
            ViewBag.Devices = devices;
            return View("AlterPanel\\AlterPart.cshtml");
        }
    }
}
