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
    public class VisualFlowRepository : IVisualFlowRepository
    {
        private readonly AppDatabaseContext _db;
        public VisualFlowRepository(AppDatabaseContext db)
        {
            _db = db;
        }
        public Task<List<Visualflow>> GetAllByTaskID(int taskID)
        {
            try
            {
                return _db.visualflows.Where(vf => vf.taskorderid == taskID).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Create(Visualflow entity)
        {
            try
            {
                _db.visualflows.Add(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Delete(Visualflow entity)
        {
            try
            {
                _db.visualflows.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<Visualflow>> GetAll()
        {
            try
            {
                return _db.visualflows.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public Task<Visualflow> GetByID(int id)
        {
            return _db.visualflows.FirstOrDefaultAsync(u => u.visualflowid == id);
        }

        public async Task<bool> Update(Visualflow entity)
        {
            try
            {
                _db.visualflows.Update(entity);
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
