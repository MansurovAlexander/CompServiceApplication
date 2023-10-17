using CompServiceApplication.Interfaces;
using CompServiceApplication;
using CompServiceApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CompServiceApplication.Repositories
{
    public class InWorkRepository : IInWorkRepository
    {
        private readonly AppDatabaseContext _db;
        public InWorkRepository(AppDatabaseContext db)
        {
            _db = db;
        }
        public async Task<InWork> FindByTaskID(int taskID)
        {
            try
            {
                return _db.inwork.FirstAsync(iw => iw.taskorderid == taskID).Result;
            }
            catch 
            {
                return null;
            }
        }
        public async Task<bool> Create(InWork entity)
        {
            try
            {
                _db.inwork.Add(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Delete(InWork entity)
        {
            try
            {
                _db.inwork.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<InWork>> GetAll()
        {
            try
            {
                return _db.inwork.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public Task<InWork> GetByID(int id)
        {
            return _db.inwork.FirstOrDefaultAsync(u => u.workid == id);
        }

        public async Task<bool> Update(InWork entity)
        {
            try
            {
                _db.inwork.Update(entity);
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
