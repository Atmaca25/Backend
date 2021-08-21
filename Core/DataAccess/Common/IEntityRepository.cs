using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Common
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        long Insert(T obj);
        Task<int> InsertAsync(T obj);
        Task<int> InsertAsync(IEnumerable<T> list);
        bool Update(T obj);
        bool Update(IEnumerable<T> list);
        Task<bool> Delete(T obj);
        bool Delete(IEnumerable<T> list);
        bool DeleteAll();
    }
}
