using CompServiceApplication.Classes;
using CompServiceApplication.Interfaces;
using CompServiceApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Controllers
{
    public class CreatePanel : Controller
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITaskOrderRepository _taskOrderRepository;
        private readonly IWareHouseRepository _warehouseRepository;
        private readonly IRepairTypeRepository _repairTypeRepository;
        private readonly IVisualFlowRepository _visualFlowRepository;
        private readonly IPartToDeviceRepository _partToDeviceRepository;
        private readonly IUserTypeRepository _userTypeRepository;
        public CreatePanel(IUserRepository userRepository, ITaskOrderRepository taskOrderRepository, IWareHouseRepository warehouseRepository, IRepairTypeRepository repairTypeRepository, IVisualFlowRepository visualFlowRepository
            , IPartToDeviceRepository partToDeviceRepository, IDeviceRepository deviceRepository, IUserTypeRepository userTypeRepository)
        {
            _userRepository = userRepository;
            _taskOrderRepository = taskOrderRepository;
            _warehouseRepository = warehouseRepository;
            _repairTypeRepository = repairTypeRepository;
            _visualFlowRepository = visualFlowRepository;
            _partToDeviceRepository = partToDeviceRepository;
            _deviceRepository = deviceRepository;
            _userTypeRepository = userTypeRepository;
        }
        public async Task<IActionResult> CreateUserType(UserType newType)
        {
            await _userTypeRepository.Create(newType);
            return View("\\CreatePanel");
        }
        public async Task<IActionResult> CreateDevice(Device newDevice)
        {
            await _deviceRepository.Create(newDevice);
            return View("\\CreatePanel");
        }
        public async Task<IActionResult> CreateUser(User user)
        {
            if (user.userpassword! != null)
                user.userpassword = HashPasswordHelper.HashPassword(user.userpassword);
            await _userRepository.Create(user);
            return View("\\CreatePanel");
        }
        public async Task<IActionResult> CreateTask(CreateTaskViewModel taskViewModel) 
        {
            TaskOrder newTaskOrder = new();
            newTaskOrder.createdate = taskViewModel.createdate;
            newTaskOrder.problemdescription = taskViewModel.problemdescription;
            newTaskOrder.userid = taskViewModel.userid;
            newTaskOrder.deviceid= taskViewModel.deviceid;
            newTaskOrder.status = "открыт";
            newTaskOrder.finallycost = 0;
            await _taskOrderRepository.Create(newTaskOrder);
            var lastTaskID = _taskOrderRepository.GetLast().Result.taskorderid;
            foreach (var image in taskViewModel.visualflow)
            {
                var byteImage = Classes.ImageConverter.ImagesToByte(image);
				Visualflow newVisualFlow = new();
				newVisualFlow.visualflow = byteImage;
				newVisualFlow.taskorderid = lastTaskID;
                newVisualFlow.imageextension = image.ContentType;
				await _visualFlowRepository.Create(newVisualFlow);
            }
            return View("\\CreatePanel");
        }
        public async Task<IActionResult> CreatePart(CreatePartViewModel partViewModel)
        {
            Warehouse newPart = new();
            newPart.manufacturer = partViewModel.manufacturer;
            newPart.partname = partViewModel.partname;
            newPart.partscount= int.Parse(partViewModel.partscount);
            newPart.partcost = decimal.Parse(partViewModel.partcost);
            await _warehouseRepository.Create(newPart);
            int partid=_warehouseRepository.GetLast().Result.partid;
            foreach (var device in partViewModel.compatibleDevices)
            {
                PartToDevice partToDevice = new();
                partToDevice.partid = partid;
                partToDevice.deviceid = device;
                await _partToDeviceRepository.Create(partToDevice);
            }
            return View("\\CreatePanel");
        }
        public async Task<IActionResult> CreateRepairType(RepairType repairType)
        {
            await _repairTypeRepository.Create(repairType);
            return View("\\CreatePanel");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
