using Business.Abstract;
using Core.Entities.Concreate;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concreate
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetOperationClaims(user.Id);
        }

        public void Add(User user)
        {
            _userDal.Insert(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.GetByMail(email);
        }
    }
}
