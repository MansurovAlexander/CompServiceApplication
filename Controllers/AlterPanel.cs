using CompServiceApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Controllers
{
    public class AlterPanel:Controller
    {
        AppDatabaseContext _db;
        public AlterPanel(AppDatabaseContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> AlterTask(CreateTaskViewModel taskViewModel)
        {
            TaskOrder newTaskOrder = _db.taskorders.First(t=>t.taskorderid==taskViewModel.taskorderid);
            newTaskOrder.createdate = taskViewModel.createdate;
            newTaskOrder.problemdescription = taskViewModel.problemdescription;
            newTaskOrder.userid = taskViewModel.userid;
            newTaskOrder.deviceid = taskViewModel.deviceid;
            newTaskOrder.finallycost = 0;
            _db.taskorders.Add(newTaskOrder);
            await _db.SaveChangesAsync();
            var lastTaskID = _db.taskorders.ToList().Last().taskorderid;
            /*foreach (var image in taskViewModel.visualflow)
            {
                //var byteImage = ImageConverter.ImagesToByte(image);
                Visualflow newVisualFlow = new();
                newVisualFlow.visualflow = byteImage;
                newVisualFlow.taskorderid = lastTaskID;
                newVisualFlow.imageextension = image.ContentType;
                _db.visualflows.Add(newVisualFlow);
                await _db.SaveChangesAsync();
            }*/
            return View("\\AlterPanel");
        }
        public async Task<IActionResult> AlterUser(User updatedUser)
        {
            _db.users.Update(updatedUser);
            await _db.SaveChangesAsync();
            return View("\\AlterPanel");
        }
        public async Task<IActionResult> AlterRepairType(RepairType updatedRepairType)
        {
            _db.repairtypes.Update(updatedRepairType);
            await _db.SaveChangesAsync();
            return View("\\AlterPanel");
        }
        public async Task<IActionResult> AlterDevice(Device updatedDevice)
        {
            _db.devices.Update(updatedDevice);
            await _db.SaveChangesAsync();
            return View("\\AlterPanel");
        }
    }
}
