using CompServiceApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompServiceApplication.Interfaces
{
    public interface IUserRepository:IBaseRepository<User>
    {
        Task<List<User>> GetAllByTypeID(int id);
        string GetUserDataByID(int? id);
    }
}
