using CompServiceApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompServiceApplication.Interfaces
{
    public interface IVisualFlowRepository:IBaseRepository<Visualflow>
    {
        Task<List<Visualflow>> GetAllByTaskID(int taskID);
    }
}
