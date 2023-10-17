using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompServiceApplication.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Update(T entity);
        Task<T> GetByID(int id);
        Task<List<T>> GetAll();

    }
}
