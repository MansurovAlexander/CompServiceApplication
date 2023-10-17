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
    public class UserInWorkRepository : IUserInWorkRepository
    {
        private readonly AppDatabaseContext _db;
        public UserInWorkRepository(AppDatabaseContext db)
        {
            _db = db;
        }
        public Task<UserInWork> FindLastByUserAndTaskID(int userId, int taskId)
        {
            try
            {
                var workId=_db.inwork.FirstOrDefaultAsync(iw=>iw.taskorderid==taskId).Result.workid;
                return _db.userinwork.Where(u=>u.userid==userId && u.workid==workId && u.enddate==null).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Create(UserInWork entity)
        {
            try
            {
                _db.userinwork.Add(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Delete(UserInWork entity)
        {
            try
            {
                _db.userinwork.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<UserInWork>> GetAll()
        {
            try
            {
                return _db.userinwork.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public Task<UserInWork> GetByID(int id)
        {
            return _db.userinwork.FirstOrDefaultAsync(u => u.userinworkid == id);
        }

        public async Task<bool> Update(UserInWork entity)
        {
            try
            {
                _db.userinwork.Update(entity);
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
