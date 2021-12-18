using Lemka.BLL.Entities;
using Lemka.BLL.Interfaces;
using Lemka.BLL.Mappers;
using Lemka.DAL.Interfaces;

namespace Lemka.BLL.Services;

public class AdresseService : IAdresseService
{
    private readonly IAdresseRepository _adresseRepository;

    public AdresseService(IAdresseRepository adresseRepository)
    {
        _adresseRepository = adresseRepository;
    }

    public AdresseEntity? CreateUserAdresse(int userId, AdresseEntity data)
    {
        bool success = _adresseRepository.CreateUserAdresse(userId, data.ToDal());
        if (!success) return null;
        return GetUserAdresse(userId);
    }

    public bool DeleteUserAdresse(int userId)
    {
        return _adresseRepository.DeleteUserAdresse(userId);
    }

    public AdresseEntity? GetUserAdresse(int userId)
    {
        return _adresseRepository.GetUserAdresse(userId)?.ToBll();
    }

    public AdresseEntity? UpdateUserAdresse(int userId, AdresseEntity data)
    {
        bool success = _adresseRepository.UpdateUserAdresse(userId, data.ToDal());
        if (!success) return null;
        return GetUserAdresse(userId);
    }
}
