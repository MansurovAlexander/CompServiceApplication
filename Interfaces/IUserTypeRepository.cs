using CompServiceApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompServiceApplication.Interfaces
{
    public interface IUserTypeRepository:IBaseRepository<UserType>
    {
        Task<int> GetIDByName(string name);
    }
}
