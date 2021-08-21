using Core.Entities.Concreate;
using Core.Utilities.Results;
using Core.Utilities.Secure.JwtModel;
using Entities.Dto;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult UserExists(string email);
    }
}
