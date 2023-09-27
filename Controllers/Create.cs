using CompServiceApplication.Classes;
using CompServiceApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace CompServiceApplication.Controllers
{
    public class Create : Controller
    {
        AppDatabaseContext _db;
        public Create(AppDatabaseContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> CreateDevice(Device newDevice)
        {
            _db.devices.Add(newDevice);
            await _db.SaveChangesAsync();
            return Redirect("~/Admin");
        }
        public async Task<IActionResult> CreateUser(CreateUserViewModel userViewModel)
        {
            User newUser = new User();
            newUser = ConvertViewModelToUser(userViewModel);
            if (newUser != null && ClassicChecks.ValidatePhoneNumber(newUser.phonenumber) && ClassicChecks.IsValidDate(newUser.dateofbirth))
            {
                _db.users.Add(newUser);
                await _db.SaveChangesAsync();
                return Redirect("~/Admin");
            }
            else
                return Redirect("~/AdminError");
        }
        public async Task<IActionResult> CreateTask(CreateTaskViewModel taskViewModel) 
        {
            TaskOrder newTaskOrder = new();
            newTaskOrder.createdate = taskViewModel.createdate;
            newTaskOrder.problemdescription = taskViewModel.problemdescription;
            newTaskOrder.userid = taskViewModel.userid;
            newTaskOrder.deviceid= taskViewModel.deviceid;
            newTaskOrder.finallycost = 0;
            _db.taskorders.Add(newTaskOrder);
            await _db.SaveChangesAsync();
            var lastTaskID = _db.taskorders.ToList().Last().taskorderid;
            var byteImages = ImageConverter.ImagesToByte(taskViewModel.visualflow);
            foreach (byte[]  image in byteImages)
            {
                Visualflow newVisualFlow = new();
                newVisualFlow.visualflow= image;
                newVisualFlow.taskorderid = lastTaskID;
                _db.visualflows.Add(newVisualFlow);
                await _db.SaveChangesAsync();
            }
            return Redirect("~/Admin");
        }
        public User ConvertViewModelToUser(CreateUserViewModel userViewModel)
        {
            User result = new User();
            result.firstname = userViewModel.firstname;
            result.lastname=userViewModel.lastname;
            result.middlename = userViewModel.middlename;
            result.phonenumber = userViewModel.phonenumber;
            result.dateofbirth = userViewModel.dateofbirth;
            result.passseries = userViewModel.passseries;
            result.passnum = userViewModel.passnum;
            result.userlogin=userViewModel.userlogin;
            result.userpassword=HashPasswordHelper.HashPassword(userViewModel.userpassword);
            result.usertypeid = userViewModel.usertypeid;
            return result;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
