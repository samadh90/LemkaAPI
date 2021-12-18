using Lemka.BLL.Entities;

namespace Lemka.BLL.Interfaces;

public interface IAdresseService
{
    AdresseEntity? GetUserAdresse(int userId);
    AdresseEntity? CreateUserAdresse(int userId, AdresseEntity data);
    AdresseEntity? UpdateUserAdresse(int userId, AdresseEntity data);
    bool DeleteUserAdresse(int userId);
}
