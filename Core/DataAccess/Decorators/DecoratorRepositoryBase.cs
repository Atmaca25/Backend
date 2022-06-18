using Core.DataAccess.Common;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Decorators
{

    public class DecoratorRepositoryBase<T> : IEntityRepository<T> where T : class, IEntity, new()
    {
        readonly IEntityRepository<T> _repository;
        public DecoratorRepositoryBase(IEntityRepository<T> repository)
        {
            _repository = repository;
        }

        public Task<bool> Delete(T obj)
        {
            return _repository.Delete(obj);
        }

        public bool Delete(IEnumerable<T> list)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAll()
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public long Insert(T obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(IEnumerable<T> list)
        {
            throw new NotImplementedException();
        }

        public bool Update(T obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(IEnumerable<T> list)
        {
            throw new NotImplementedException();
        }
    }
}
