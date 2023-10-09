using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompServiceApplication.Components.AlterPanel
{
    public class AlterRepairType : ViewComponent
    {
        AppDatabaseContext _db;
        public AlterRepairType(AppDatabaseContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
		{
			SelectList repairTypes = new SelectList(from rt in _db.repairtypes.ToList()
											  select new
											  {
												  RepairTypeID = rt.repairid,
												  RepairTypeData = "Описание: " + rt.repairdescription
												  + "\tСтоимость: " + rt.repaircost.ToString()
											  },
											  "RepairTypeID",
											  "RepairTypeData",
											  null
											  );
			ViewBag.RepairTypes = repairTypes;
			return View("AlterPanel\\AlterRepairType.cshtml");
        }
    }
}
