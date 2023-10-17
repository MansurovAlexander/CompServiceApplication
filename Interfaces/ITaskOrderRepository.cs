using CompServiceApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompServiceApplication.Interfaces
{
    public interface ITaskOrderRepository:IBaseRepository<TaskOrder>
    {
        Task<List<TaskOrder>> GetOpenedTaskOrders();
        List<TaskOrder> GetTaskOrdersByWorker(int workerID);
        Task<TaskOrder> GetLast();
    }
}
