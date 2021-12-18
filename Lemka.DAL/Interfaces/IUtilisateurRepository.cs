using Lemka.DAL.Datas;

namespace Lemka.DAL.Interfaces;

public interface IUtilisateurRepository
{
    IEnumerable<UtilisateurData> GetAll();
    UtilisateurData? GetById(int id);
    bool Update(int id, UtilisateurData data);
    bool UpdatePassword(int id, string oldPassword, string newPassword);
    bool UpdateUserRole(int userId, int roleId);
}