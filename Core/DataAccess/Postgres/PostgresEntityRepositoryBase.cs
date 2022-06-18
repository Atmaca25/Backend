using Core.DataAccess.Common;
using Core.Entities.Abstract;
using Dapper.Contrib.Extensions;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Postgres
{
    public class PostgresEntityRepositoryBase<T> : IEntityRepository<T> where T : class, IEntity, new()
    {
        public Task<bool> Delete(T obj)
        {
            throw new NotImplementedException();
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
            using (var connection = new NpgsqlConnection("Server=localhost;Database=postgres;User Id=postgres;Password=qwert187;"))
            {
                connection.Open();
                return connection.GetAll<T>();
            }
        }

        public long Insert(T obj)
        {
            using (var connection = new NpgsqlConnection("Server=localhost;Database=postgres;User Id=postgres;Password=qwert187;"))
            {
                connection.Open();
                return connection.Insert(obj);
            }
        }

        public Task<int> InsertAsync(T obj)
        {
            using (var connection = new NpgsqlConnection("Server=localhost;Database=postgres;User Id=postgres;Password=qwert187;"))
            {
                connection.Open();
                return connection.InsertAsync(obj);
            }
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
