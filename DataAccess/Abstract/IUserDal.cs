using Core.DataAccess.Common;
using Core.Entities.Concreate;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        public List<OperationClaim> GetOperationClaims(int userId);
        public IDataResult<User> GetUserInformation(User user);
        User GetByMail(string email);
    }
}
