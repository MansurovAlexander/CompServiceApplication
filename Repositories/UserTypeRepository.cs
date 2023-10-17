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
    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly AppDatabaseContext _db;
        public UserTypeRepository(AppDatabaseContext db)
        {
            _db = db;
        }
        public async Task<int> GetIDByName(string name)
        {
            try
            {
                return _db.usertypes.FirstOrDefaultAsync(u=>u.usertypename.ToLower() == name.ToLower()).Result.usertypeid;
            }
            catch 
            {
                throw;
            }
        }
        public async Task<bool> Create(UserType entity)
        {
            try
            {
                _db.usertypes.Add(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Delete(UserType entity)
        {
            try
            {
                _db.usertypes.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<UserType>> GetAll()
        {
            try
            {
                return _db.usertypes.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public Task<UserType> GetByID(int id)
        {
            return _db.usertypes.FirstOrDefaultAsync(u => u.usertypeid == id);
        }

        public async Task<bool> Update(UserType entity)
        {
            try
            {
                _db.usertypes.Update(entity);
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
