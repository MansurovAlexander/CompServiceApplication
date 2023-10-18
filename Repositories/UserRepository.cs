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
    public class UserRepository : IUserRepository
    {
        private readonly AppDatabaseContext _db;
        public UserRepository(AppDatabaseContext db)
        {
            _db = db;
        }
        public string GetUserDataByID(int? id)
        {
            string userData = "";
            try
            {
                var user = _db.users.FirstOrDefaultAsync(u => u.userid == id).Result;
                var userRole = _db.usertypes.FirstOrDefaultAsync(ut=>ut.usertypeid==user.usertypeid).Result.usertypename;
                userData = user.lastname + " | " + user.firstname + " | " +user.phonenumber+" | "+ user.passnum+" "+user.passseries;
                return userData;
            }
            catch
            {
                throw;
            }
        }
        public Task<List<User>> GetAllByTypeID(int typeid)
        {
            try
            {
                return _db.users.Where(u => u.usertypeid == typeid).OrderBy(u => u.userid).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Create(User entity)
        {
            try
            {
                _db.users.Add(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Delete(User entity)
        {
            try
            {
                _db.users.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<User>> GetAll()
        {
            try
            {
                return _db.users.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public Task<User> GetByID(int id)
        {
            return _db.users.FirstOrDefaultAsync(u => u.userid == id);
        }

        public async Task<bool> Update(User entity)
        {
            try
            {
                _db.users.Update(entity);
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
