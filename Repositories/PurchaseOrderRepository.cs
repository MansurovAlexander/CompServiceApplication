using CompServiceApplication.Interfaces;
using CompServiceApplication;
using CompServiceApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;

namespace CompServiceApplication.Repositories
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly AppDatabaseContext _db;
        public PurchaseOrderRepository(AppDatabaseContext db)
        {
            _db = db;
        }
        public Task<List<PurchaseOrder>> GetAllUnconfirmed() 
        {
            try
            {
                return _db.purchaseorder.Where(po => po.status.ToLower() != "Отказано" && po.status.ToLower() != "Подтвержден").ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public Task<PurchaseOrder> GetLast()
        {
            try
            {
                return _db.purchaseorder.OrderBy(po => po.purchaseorderid).LastOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Create(PurchaseOrder entity)
        {
            try
            {
                _db.purchaseorder.Add(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Delete(PurchaseOrder entity)
        {
            try
            {
                _db.purchaseorder.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<PurchaseOrder>> GetAll()
        {
            try
            {
                return _db.purchaseorder.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public Task<PurchaseOrder> GetByID(int id)
        {
            return _db.purchaseorder.FirstOrDefaultAsync(u => u.purchaseorderid == id);
        }

        public async Task<bool> Update(PurchaseOrder entity)
        {
            try
            {
                _db.purchaseorder.Update(entity);
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
