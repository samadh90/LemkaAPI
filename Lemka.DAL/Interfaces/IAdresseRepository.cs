using Lemka.DAL.Datas;

namespace Lemka.DAL.Interfaces;

public interface IAdresseRepository
{
    AdresseData? GetUserAdresse(int userId);
    bool CreateUserAdresse(int userId, AdresseData data);
    bool UpdateUserAdresse(int userId, AdresseData data);
    bool DeleteUserAdresse(int userId);
}
