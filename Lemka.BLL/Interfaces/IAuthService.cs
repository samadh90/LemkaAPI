using Lemka.BLL.Entities;

namespace Lemka.BLL.Interfaces;

public interface IAuthService
{
    LoggedInUserEntity? Login(string email, string password);
    void Register(string email, string nom, string prenom, string password);
}
