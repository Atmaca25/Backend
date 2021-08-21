using Core.Entities.Concreate;
using Core.Utilities.Secure.JwtModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Secure.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operetainClaims);
    }
}
