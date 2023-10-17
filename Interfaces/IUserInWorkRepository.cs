using CompServiceApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompServiceApplication.Interfaces
{
    public interface IUserInWorkRepository:IBaseRepository<UserInWork>
    {
        Task<UserInWork> FindLastByUserAndTaskID(int userID, int taskId);
    }
}
