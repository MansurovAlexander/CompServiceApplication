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
        string GetLastWorkerByTaskID(int taskid);
        Task<List<TaskOrder>> GetAllClosedByWorker();
        Task<List<TaskOrder>> GetOpenedTaskOrders();
        List<TaskOrder> GetTaskOrdersByWorker(int workerID);
        Task<TaskOrder> GetLast();
    }
}
