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
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AppDatabaseContext _db;
        public DeviceRepository(AppDatabaseContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Device entity)
        {
            try
            {
                _db.devices.Add(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Delete(Device entity)
        {
            try
            {
                _db.devices.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<Device>> GetAll()
        {
            try
            {
                return _db.devices.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public Task<Device> GetByID(int id)
        {
            return _db.devices.FirstOrDefaultAsync(u => u.deviceid == id);
        }

        public async Task<bool> Update(Device entity)
        {
            try
            {
                _db.devices.Update(entity);
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
