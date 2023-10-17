using CompServiceApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompServiceApplication.Components.AlterPanel
{
    public class AlterDevice : ViewComponent
    {
		private readonly IDeviceRepository _deviceRepository;
		public AlterDevice(IDeviceRepository deviceRepository)
		{
			_deviceRepository = deviceRepository;
		}
        public async Task<IViewComponentResult> InvokeAsync()
        {
			SelectList devices = new SelectList(from d in _deviceRepository.GetAll().Result
												select new
												{
													DeviceID = d.deviceid,
													DeviceData = d.manufacturer + " " + d.model + " " + d.devicedescription
												},
				"DeviceID",
				"DeviceData",
				null);
			ViewBag.Devices = devices;
			return View("AlterPanel\\AlterDevice.cshtml");
        }
    }
}
