using Lemka.DAL.Datas;
using Lemka.DAL.Interfaces;
using Lemka.DAL.Mappers;
using DevHopTools.Connection;

namespace Lemka.DAL.Repositories;

public class AdresseRepository : IAdresseRepository
{
    private readonly Connection _connection;

    public AdresseRepository(Connection connection)
    {
        _connection = connection;
    }

    public bool CreateUserAdresse(int userId, AdresseData data)
    {
        Command command = new("spAdressesCreate", true);
        command.AddParameter("UtilisateurId", userId);
        command.AddParameter("Pays", data.Pays);
        command.AddParameter("VIlle", data.Ville);
        command.AddParameter("CodePostal", data.CodePostal);
        command.AddParameter("Rue", data.Rue);
        command.AddParameter("Numero", data.Numero);
        command.AddParameter("Boite", data.Boite);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public bool DeleteUserAdresse(int userId)
    {
        string query = "DELETE FROM dbo.Adresses WHERE [UtilisateurId] = @UtilisateurId";
        Command command = new(query);
        command.AddParameter("UtilisateurId", userId);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public AdresseData? GetUserAdresse(int userId)
    {
        Command command = new("spAdressesGetByUtilisateurId", true);
        command.AddParameter("UtilisateurId", userId);
        return _connection.ExecuteReader(command, r => r.ToAdresse()).SingleOrDefault();
    }

    public bool UpdateUserAdresse(int userId, AdresseData data)
    {
        Command command = new("spAdressesUpdate", true);
        command.AddParameter("UtilisateurId", userId);
        command.AddParameter("Pays", data.Pays);
        command.AddParameter("VIlle", data.Ville);
        command.AddParameter("CodePostal", data.CodePostal);
        command.AddParameter("Rue", data.Rue);
        command.AddParameter("Numero", data.Numero);
        command.AddParameter("Boite", data.Boite);
        return _connection.ExecuteNonQuery(command) > 0;
    }
}
