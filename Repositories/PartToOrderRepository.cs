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
    public class PartToOrderRepository : IPartToOrderRepository
    {
        private readonly AppDatabaseContext _db;
        public PartToOrderRepository(AppDatabaseContext db)
        {
            _db = db;
        }
        public List<string> GetDataByPurchaseOrderID(int purchaseOrderID)
        {
            List<string> partsToOrderData = new();
            try
            {
                var partsToOrder = _db.partstoorder.Where(po => po.purchaseorderid == purchaseOrderID).OrderBy(po => po.totalcost).ToListAsync().Result;
                var partsData = partsToOrder.Join(_db.warehouse, po => po.partid, wh => wh.partid, (po, wh) => new
                {
                    PartID=po.partid,
                    Name = wh.partname,
                    Count = po.partstoordercount,
                    TotalCost = po.totalcost
                });
                foreach (var part in partsData)
                {
                    string tempData = part.Name + " " + part.Count.ToString()+" "+part.TotalCost.ToString();
                    partsToOrderData.Add(tempData);
                }
                return partsToOrderData;
            }
            catch
            {
                throw;
            }
        }

		public async Task<bool> Create(PartToOrder entity)
        {
            try
            {
                _db.partstoorder.Add(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Delete(PartToOrder entity)
        {
            try
            {
                _db.partstoorder.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<PartToOrder>> GetAll()
        {
            try
            {
                return _db.partstoorder.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public Task<PartToOrder> GetByID(int id)
        {
            return _db.partstoorder.FirstOrDefaultAsync(u => u.parttoorderid == id);
        }

        public async Task<bool> Update(PartToOrder entity)
        {
            try
            {
                _db.partstoorder.Update(entity);
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
