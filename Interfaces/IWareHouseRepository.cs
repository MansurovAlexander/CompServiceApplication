using CompServiceApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompServiceApplication.Interfaces
{
    public interface IWareHouseRepository:IBaseRepository<Warehouse>
    {
        Task<Warehouse> GetLast();
        decimal GetPartCostByID(int partID);
    }
}
