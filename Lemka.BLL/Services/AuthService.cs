using Lemka.BLL.Entities;
using Lemka.BLL.Interfaces;
using Lemka.BLL.Mappers;
using Lemka.DAL.Interfaces;

namespace Lemka.BLL.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;

    public AuthService(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public LoggedInUserEntity? Login(string email, string password)
    {
        return _authRepository.Login(email, password)?.ToBll();
    }

    public void Register(string email, string nom, string prenom, string password)
    {
        _authRepository.Register(email, nom, prenom, password);
    }
}
