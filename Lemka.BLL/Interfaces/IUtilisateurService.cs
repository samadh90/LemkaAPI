using Lemka.BLL.Entities;

namespace Lemka.BLL.Interfaces;

public interface IUtilisateurService
{
    IEnumerable<UtilisateurEntity> GetAll();
    UtilisateurEntity? GetById(int id);
    UtilisateurEntity? Update(int id, UtilisateurEntity entity);
    bool UpdatePassword(int id, string oldPassword, string newPassword);
    bool UpdateUserRole(int userId, int roleId);
}