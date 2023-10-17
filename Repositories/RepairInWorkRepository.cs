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
    public class RepairInWorkRepository : IRepairInWorkRepository
    {
        private readonly AppDatabaseContext _db;
        public RepairInWorkRepository(AppDatabaseContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(RepairInWork entity)
        {
            try
            {
                _db.repairinwork.Add(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Delete(RepairInWork entity)
        {
            try
            {
                _db.repairinwork.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<RepairInWork>> GetAll()
        {
            try
            {
                return _db.repairinwork.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public Task<RepairInWork> GetByID(int id)
        {
            return _db.repairinwork.FirstOrDefaultAsync(u => u.repairinworkid == id);
        }

        public async Task<bool> Update(RepairInWork entity)
        {
            try
            {
                _db.repairinwork.Update(entity);
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
