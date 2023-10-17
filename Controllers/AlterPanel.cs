using CompServiceApplication.Classes;
using CompServiceApplication.Interfaces;
using CompServiceApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Controllers
{
    public class AlterPanel:Controller
    {
		private readonly IDeviceRepository _deviceRepository;
		private readonly IUserRepository _userRepository;
		private readonly ITaskOrderRepository _taskOrderRepository;
		private readonly IWareHouseRepository _warehouseRepository;
		private readonly IRepairTypeRepository _repairTypeRepository;
		private readonly IVisualFlowRepository _visualFlowRepository;
		private readonly IPartToDeviceRepository _partToDeviceRepository;
		private readonly IUserTypeRepository _userTypeRepository;
		public AlterPanel(IUserRepository userRepository, ITaskOrderRepository taskOrderRepository, IWareHouseRepository warehouseRepository, IRepairTypeRepository repairTypeRepository, IVisualFlowRepository visualFlowRepository
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
		public async Task<IActionResult> AlterTask(CreateTaskViewModel taskViewModel)
        {
            TaskOrder newTaskOrder = _taskOrderRepository.GetByID(taskViewModel.taskorderid).Result;
            newTaskOrder.createdate = taskViewModel?.createdate ?? newTaskOrder.createdate;
            newTaskOrder.problemdescription = taskViewModel?.problemdescription ?? newTaskOrder.problemdescription;
            newTaskOrder.userid = taskViewModel?.userid ?? newTaskOrder.userid;
            newTaskOrder.deviceid = taskViewModel?.deviceid ?? newTaskOrder.deviceid;
            newTaskOrder.finallycost = 0;
            await _taskOrderRepository.Update(newTaskOrder);
            var lastTaskID = _taskOrderRepository.GetLast().Result.taskorderid;
            foreach (var image in taskViewModel.visualflow)
            {
                var byteImage = ImageConverter.ImagesToByte(image);
                Visualflow newVisualFlow = new();
                newVisualFlow.visualflow = byteImage;
                newVisualFlow.taskorderid = lastTaskID;
                newVisualFlow.imageextension = image.ContentType;
                await _visualFlowRepository.Create(newVisualFlow);
            }
            return View("\\AlterPanel");
        }
        public async Task<IActionResult> AlterUser(User updatedUser)
        {
            await _userRepository.Update(updatedUser);
            return View("\\AlterPanel");
        }
        public async Task<IActionResult> AlterRepairType(RepairType updatedRepairType)
        {
            await _repairTypeRepository.Update(updatedRepairType);
            return View("\\AlterPanel");
        }
        public async Task<IActionResult> AlterDevice(Device updatedDevice)
        {
            await _deviceRepository.Update(updatedDevice);
            return View("\\AlterPanel");
        }
        public async Task<IActionResult> AlterUserType(UserType updatedUserType)
        {
            await _userTypeRepository.Update(updatedUserType);
			return View("\\AlterPanel");
		}
        public async Task<IActionResult> AlterPart(CreatePartViewModel updatePart)
        {
            Warehouse partForUpdate = _warehouseRepository.GetByID(updatePart.partid).Result;
            partForUpdate.partscount = int.Parse(updatePart?.partscount ?? partForUpdate.partscount.ToString());
            partForUpdate.manufacturer = updatePart?.manufacturer ?? partForUpdate.manufacturer;
            partForUpdate.partcost = int.Parse(updatePart?.partcost ?? partForUpdate.partcost.ToString());
            partForUpdate.partname=updatePart?.partname ?? partForUpdate.partname;
            await _warehouseRepository.Update(partForUpdate);
            return View("\\AlterPanel");
        }
    }
}
