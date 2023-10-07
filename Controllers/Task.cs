﻿using CompServiceApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Controllers
{
    public class Task : Controller
    {
        AppDatabaseContext _db;
        public Task(AppDatabaseContext db)
        {
            _db = db;
        }
        [HttpPost]
        public async Task<IActionResult> TakeTask(int taskid)
        {
            if (User.IsInRole("worker") || User.IsInRole("admin"))
            {
                var newWorkAccept = new InWork();
                newWorkAccept.taskorderid = taskid;
                newWorkAccept.workstagedescription = "Taken";
                _db.inwork.Add(newWorkAccept);
                await _db.SaveChangesAsync();
                var userInWork = new UserInWork();
                userInWork.startdate= DateTime.Now;
                userInWork.userid = Int32.Parse(User.Identity.Name);
                userInWork.workid = _db.inwork.ToList().Last().workid;
                _db.userinwork.Add(userInWork);
                await _db.SaveChangesAsync();
                return View();
            }
            return View("\\TaskList.cshtml");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
