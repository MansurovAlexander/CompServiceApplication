using CompServiceApplication.Interfaces;
using CompServiceApplication;
using CompServiceApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompServiceApplication.Repositories
{
    public class TaskOrderRepository : ITaskOrderRepository
    {
        private readonly AppDatabaseContext _db;
        public TaskOrderRepository(AppDatabaseContext db)
        {
            _db = db;
        }
        public string GetLastWorkerByTaskID(int taskid)
        {
            try
            {
                var inworkID=_db.inwork.FirstOrDefaultAsync(iw=>iw.taskorderid==taskid).Result.workid;
                var userInWorkID = _db.userinwork.FirstOrDefaultAsync(uiw => uiw.workid == inworkID && uiw.enddate != null).Result.userid;
                var user = _db.users.FirstOrDefaultAsync(u => u.userid == userInWorkID).Result;
                return user.lastname + " | " + user.firstname + " | " + user.phonenumber.ToString();
            }
            catch
            {
                throw;
            }
        }
        public Task<TaskOrder> GetLast()
        {
            try
            {
                return _db.taskorders.OrderBy(t=>t.taskorderid).LastOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Create(TaskOrder entity)
        {
            try
            {
                _db.taskorders.Add(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Delete(TaskOrder entity)
        {
            try
            {
                _db.taskorders.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<TaskOrder>> GetAll()
        {
            try
            {
                return _db.taskorders.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public Task<List<TaskOrder>> GetAllClosedByWorker()
        {
            try
            {
                return _db.taskorders.Where(t => t.status.ToLower() == "закрыт рабочим").ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public Task<List<TaskOrder>> GetOpenedTaskOrders()
        {
            try
            {
                return _db.taskorders.Where(t=>t.status.ToLower()=="открыт").ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public List<TaskOrder> GetTaskOrdersByWorker(int workerID)
        {
            try
            {
                var taskOrders = new List<TaskOrder>();
                var userInWork = _db.userinwork.Where(u => u.userid == workerID && u.enddate==null).ToList();
                var works = userInWork.Join(_db.inwork, uw => uw.workid, iw => iw.workid, (uw, iw) => new
                {
                    task = iw.taskorderid
                });
                foreach (var work in works)
                {
                    var taskOrder = _db.taskorders.FirstOrDefault(t => t.taskorderid == work.task && t.status.ToLower() == "в работе");
                    if (taskOrder != null)
                        taskOrders.Add(taskOrder);
                }
                return taskOrders;
            }
            catch
            {
                throw;
            }
        }

        public Task<TaskOrder> GetByID(int id)
        {
            return _db.taskorders.FirstOrDefaultAsync(u => u.taskorderid == id);
        }

        public async Task<bool> Update(TaskOrder entity)
        {
            try
            {
                _db.taskorders.Update(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
