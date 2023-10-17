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
    public class PartToDeviceRepository : IPartToDeviceRepository
    {
        private readonly AppDatabaseContext _db;
        public PartToDeviceRepository(AppDatabaseContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(PartToDevice entity)
        {
            try
            {
                _db.parttodevice.Add(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Delete(PartToDevice entity)
        {
            try
            {
                _db.parttodevice.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<PartToDevice>> GetAll()
        {
            try
            {
                return _db.parttodevice.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public Task<PartToDevice> GetByID(int id)
        {
            return _db.parttodevice.FirstOrDefaultAsync(u => u.parttodeviceid == id);
        }

        public async Task<bool> Update(PartToDevice entity)
        {
            try
            {
                _db.parttodevice.Update(entity);
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
