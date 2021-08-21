using Core.DataAccess.Dapper;
using Core.Entities.Concreate;
using Core.Utilities.Results;
using Dapper;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccess.Concreate
{
    public class UserDalDapper : DapperEntityRepositoryBase<User>, IUserDal
    {
        public User GetByMail(string email)
        {
            using (var connection = new SqlConnection("Data Source=UATMACA\\UATMACA;Initial Catalog=Northwind;Integrated Security=True"))
            {
                return connection.Query<User>($"SELECT * FROM dbo.Users AS u WHERE u.Email = '{email}'").FirstOrDefault();
            }
        }

        public List<OperationClaim> GetOperationClaims(int userId)
        {
            using (var connection = new SqlConnection("Data Source=UATMACA\\UATMACA;Initial Catalog=Northwind;Integrated Security=True"))
            {
                return connection.Query<OperationClaim>($"SELECT * FROM dbo.vwGetUserClaims AS uoc WHERE uoc.UserId = {userId}").ToList();
            }
        }

        public IDataResult<User> GetUserInformation(User user)
        {
            var result = Get(user.Id);
            if (result != null)
            {
                return new SuccessDataResult<User>(result);
            }
            else
            {
                return new ErrorDataResult<User>(null, "Kullanıcı Bulunamadı !");
            }
        }
    }
}
