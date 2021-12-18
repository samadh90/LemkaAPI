using Lemka.DAL.Datas;
using Lemka.DAL.Interfaces;
using Lemka.DAL.Mappers;
using DevHopTools.Connection;

namespace Lemka.DAL.Repositories;

public class UtilisateurRepository : IUtilisateurRepository
{
    private readonly Connection _connection;

    public UtilisateurRepository(Connection connection)
    {
        _connection = connection;
    }

    public IEnumerable<UtilisateurData> GetAll()
    {
        string query = "SELECT * FROM dbo.vUtilisateurs";
        Command command = new(query);
        return _connection.ExecuteReader(command, m => m.ToUtilisateur());
    }

    public UtilisateurData? GetById(int id)
    {
        string query = "SELECT * FROM dbo.vUtilisateurs WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", id);
        return _connection.ExecuteReader(command, m => m.ToUtilisateur()).SingleOrDefault();
    }

    public bool Update(int id, UtilisateurData data)
    {
        Command command = new("spUtilisateursUpdate", true);
        command.AddParameter("Id", id);
        command.AddParameter("Username", data.Username);
        command.AddParameter("Tel", data.Tel);
        command.AddParameter("Prenom", data.Prenom);
        command.AddParameter("Nom", data.Nom);
        command.AddParameter("GenreId", data.GenreId);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public bool UpdatePassword(int id, string oldPassword, string newPassword)
    {
        Command command = new("spUtilisateursUpdatePassword", true);
        command.AddParameter("UtilisateurId", id);
        command.AddParameter("OldPassword", oldPassword);
        command.AddParameter("NewPassword", newPassword);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public bool UpdateUserRole(int userId, int roleId)
    {
        string query = "UPDATE dbo.UtilisateurRoles SET [RoleId] = @RoleId WHERE [UtilisateurId] = @UtilisateurId";
        Command command = new(query);
        command.AddParameter("UtilisateurId", userId);
        command.AddParameter("RoleId", roleId);
        return _connection.ExecuteNonQuery(command) > 0;
    }
}
