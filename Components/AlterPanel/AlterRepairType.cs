using CompServiceApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompServiceApplication.Components.AlterPanel
{
    public class AlterRepairType : ViewComponent
    {
        private readonly IRepairTypeRepository _repairTypeRepository;
        public AlterRepairType(IRepairTypeRepository repairTypeRepository)
        {
			_repairTypeRepository = repairTypeRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
		{
			SelectList repairTypes = new SelectList(from rt in _repairTypeRepository.GetAll().Result
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
