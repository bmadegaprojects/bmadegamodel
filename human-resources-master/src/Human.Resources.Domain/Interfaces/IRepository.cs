using System.Collections.Generic;
using System.Threading.Tasks;

namespace Human.Resources.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Insert(T obj);
        Task<bool> Update(T obj);
        void Remove(int id);
    }
}
