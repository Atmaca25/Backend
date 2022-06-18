using Core.DataAccess.Postgres;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate
{
    public class ProductDalPostgres : PostgresEntityRepositoryBase<Product>, IProductDal
    {
        public int CategoryCount(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetProductPrice(int id)
        {
            throw new NotImplementedException();
        }
    }
}
