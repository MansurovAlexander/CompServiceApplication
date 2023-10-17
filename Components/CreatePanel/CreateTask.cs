using CompServiceApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompServiceApplication.Components.CreatePanel
{
    public class CreateTask : ViewComponent
    {
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDeviceRepository _deviceRepository;
        public CreateTask(IUserRepository userRepository, IUserTypeRepository userTypeRepository, IDeviceRepository deviceRepository)
        {
            _userTypeRepository = userTypeRepository;
            _userRepository = userRepository;
            _deviceRepository = deviceRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int roleid = _userTypeRepository.GetIDByName("client").Result;
            var usersData=_userRepository.GetAllByTypeID(roleid).Result;
            SelectList users = new SelectList(from u in usersData
                                               select new
                                               {
                                                   UserID = u.userid,
                                                   UserData = u.lastname + " " + u.firstname + " " + u.middlename + " " + u.passseries.ToString() + " " + u.passnum.ToString()
                                               },
                "UserID",
                "UserData",
                null);
            ViewBag.Users = users;
            var devicesData = _deviceRepository.GetAll().Result;
            SelectList devices = new SelectList(from d in devicesData
                                                select new
                                                {
                                                    DeviceID = d.deviceid,
                                                    DeviceData = d.manufacturer + " " + d.model + " " + d.devicedescription
                                                },
                "DeviceID",
                "DeviceData",
                null);
            ViewBag.Devices = devices;
            return View("CreatePanel\\CreateTask.cshtml");
        }
    }
}
