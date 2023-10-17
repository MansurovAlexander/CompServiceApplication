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
    public class WareHouseRepository : IWareHouseRepository
    {
        private readonly AppDatabaseContext _db;
        public WareHouseRepository(AppDatabaseContext db)
        {
            _db = db;
        }
        public decimal GetPartCostByID(int partID)
        {
            try
            {
                return _db.warehouse.FirstOrDefaultAsync(wh => wh.partid == partID).Result.partcost;
            }
            catch
            {
                throw;
            }
        }
        public Task<Warehouse> GetLast()
        {
            try
            {
                return _db.warehouse.OrderBy(w=>w.partid).LastOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Create(Warehouse entity)
        {
            try
            {
                _db.warehouse.Add(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Delete(Warehouse entity)
        {
            try
            {
                _db.warehouse.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<Warehouse>> GetAll()
        {
            try
            {
                return _db.warehouse.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public Task<Warehouse> GetByID(int id)
        {
            return _db.warehouse.FirstOrDefaultAsync(u => u.partid == id);
        }

        public async Task<bool> Update(Warehouse entity)
        {
            try
            {
                _db.warehouse.Update(entity);
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
