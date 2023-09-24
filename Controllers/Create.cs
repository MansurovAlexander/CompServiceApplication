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
        public IActionResult CreateDevice(Device newDevice)
        {
            _db.devices.Add(newDevice);
            _db.SaveChangesAsync();
            return Redirect("~/Admin");
        }
        public IActionResult CreateUser(CreateUserViewModel userViewModel)
        {
            User newUser = new User();
            newUser = ConvertViewModelToUser(userViewModel);
            if (newUser != null && ClassicChecks.ValidatePhoneNumber(newUser.phonenumber) && ClassicChecks.IsValidDate(newUser.dateofbirth))
            {
                _db.users.Add(newUser);
                _db.SaveChangesAsync();
                return Redirect("~/Admin");
            }
            else
                return Redirect("~/AdminError");
        }
        public IActionResult CreateTask(CreateTaskViewModel taskViewModel) 
        {
            TaskOrder newTaskOrder = new TaskOrder();
            Visualflow newVisualFlow= new Visualflow();
            List<byte[]> imagesToDB=new List<byte[]>();
            if (taskViewModel.visualflow != null)
            foreach (var image in taskViewModel.visualflow)
            {
                imagesToDB.Add(new BinaryReader(image.OpenReadStream()).ReadBytes((int)image.Length));
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
