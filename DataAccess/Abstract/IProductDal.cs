using Core.DataAccess.Common;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        Task<decimal> GetProductPrice(int id);
        public int CategoryCount(int CategoryId);
    }
}
