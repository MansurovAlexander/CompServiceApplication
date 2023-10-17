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
    public class UsedPartRepository : IUsedPartRepository
    {
        private readonly AppDatabaseContext _db;
        public UsedPartRepository(AppDatabaseContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(UsedPart entity)
        {
            try
            {
                _db.usedparts.Add(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Delete(UsedPart entity)
        {
            try
            {
                _db.usedparts.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<UsedPart>> GetAll()
        {
            try
            {
                return _db.usedparts.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public Task<UsedPart> GetByID(int id)
        {
            return _db.usedparts.FirstOrDefaultAsync(u => u.usedpartid == id);
        }

        public async Task<bool> Update(UsedPart entity)
        {
            try
            {
                _db.usedparts.Update(entity);
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
