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
    public class RepairTypeRepository : IRepairTypeRepository
    {
        private readonly AppDatabaseContext _db;
        public RepairTypeRepository(AppDatabaseContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(RepairType entity)
        {
            try
            {
                _db.repairtypes.Add(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Delete(RepairType entity)
        {
            try
            {
                _db.repairtypes.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<RepairType>> GetAll()
        {
            try
            {
                return _db.repairtypes.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public Task<RepairType> GetByID(int id)
        {
            return _db.repairtypes.FirstOrDefaultAsync(u => u.repairid == id);
        }

        public async Task<bool> Update(RepairType entity)
        {
            try
            {
                _db.repairtypes.Update(entity);
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
