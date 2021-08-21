using Core.DataAccess.Common;
using Core.Entities.Abstract;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Dapper
{
    public class DapperEntityRepositoryBase<T> : IEntityRepository<T> where T : class, IEntity, new()
    {
        public Task<bool> Delete(T obj)
        {
            using (var connection = new SqlConnection("Data Source=UATMACA\\UATMACA;Initial Catalog=Northwind;Integrated Security=True"))
            {
                return connection.DeleteAsync<T>(obj);
            }
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
            using (var connection = new SqlConnection("Data Source=UATMACA\\UATMACA;Initial Catalog=Northwind;Integrated Security=True"))
            {
                return connection.GetAll<T>();
            }
        }

        public long Insert(T obj)
        {
            using (var connection = new SqlConnection("Data Source=UATMACA\\UATMACA;Initial Catalog=Northwind;Integrated Security=True"))
            {
                return connection.Insert(obj);
            }
        }

        public async Task<int> InsertAsync(T obj)
        {
            using (var connection = new SqlConnection("Data Source=UATMACA\\UATMACA;Initial Catalog=Northwind;Integrated Security=True"))
            {
                return await connection.InsertAsync(obj);
            }
        }

        public Task<int> InsertAsync(IEnumerable<T> list)
        {
            using (var connection = new SqlConnection("Data Source=UATMACA\\UATMACA;Initial Catalog=Northwind;Integrated Security=True"))
            {
                return connection.InsertAsync<List<T>>(list.ToList());
            }
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
