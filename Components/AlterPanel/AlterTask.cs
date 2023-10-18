using CompServiceApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompServiceApplication.Components.AlterPanel
{
    public class AlterTask : ViewComponent
    {
		private readonly IUserTypeRepository _userTypeRepository;
		private readonly IUserRepository _userRepository;
		private readonly IDeviceRepository _deviceRepository;
        private readonly ITaskOrderRepository _taskOrderRepository;
		public AlterTask(IUserRepository userRepository, IUserTypeRepository userTypeRepository, IDeviceRepository deviceRepository, ITaskOrderRepository taskOrderRepository)
		{
			_userTypeRepository = userTypeRepository;
			_userRepository = userRepository;
			_deviceRepository = deviceRepository;
            _taskOrderRepository = taskOrderRepository;
		}
		public async Task<IViewComponentResult> InvokeAsync()
        {
            SelectList tasks = new SelectList(from t in _taskOrderRepository.GetAll().Result
                                              select new
                                              {
                                                  TaskID = t.taskorderid,
                                                  TaskData = "Дата создания: " + t.createdate.ToString() + "\tОписание проблемы: " + t.problemdescription
                                              },
                "TaskID",
                "TaskData",
                null);
            ViewBag.Tasks = tasks;
			int roleid = _userTypeRepository.GetIDByName("client");
			var usersData = _userRepository.GetAllByTypeID(roleid).Result;
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
            return View("AlterPanel\\AlterTask.cshtml");
        }
    }
}
