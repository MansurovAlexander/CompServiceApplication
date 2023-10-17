using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using CompServiceApplication.Interfaces;

namespace CompServiceApplication.Components.CreatePanel
{
    public class CreatePart : ViewComponent
    {
        private readonly IDeviceRepository _deviceRepository;
        public CreatePart(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var devicesRep=_deviceRepository.GetAll().Result;
            SelectList devices = new SelectList(from d in devicesRep
												select new
                                                {
                                                    DeviceID = d.deviceid,
                                                    DeviceData = d.manufacturer + " " + d.model + " " + d.devicedescription
                                                },
                "DeviceID",
                "DeviceData",
                null);
            ViewBag.Devices = devices;
            return View("CreatePanel\\CreatePart.cshtml");
        }
    }
}
