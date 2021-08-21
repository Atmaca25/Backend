using Core.DataAccess.Dapper;
using Dapper;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate
{
    public class ProductDalDapper : DapperEntityRepositoryBase<Product>, IProductDal
    {
        public int CategoryCount(int CategoryId)
        {
            using (var connection = new SqlConnection("Data Source=UATMACA\\UATMACA;Initial Catalog=Northwind;Integrated Security=True"))
            {
                var result = connection.QueryFirst<int>($"SELECT SUM(1) FROM dbo.Products AS P WHERE p.CategoryID = {CategoryId}");
                return result;
            }
        }

        public Task<decimal> GetProductPrice(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
