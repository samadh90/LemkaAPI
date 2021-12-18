
using Lemka.DAL.Datas;

namespace Lemka.DAL.Interfaces;

public interface IAuthRepository
{
    LoggedInUserData? Login(string email, string password);
    void Register(string email, string username, string password);
}
