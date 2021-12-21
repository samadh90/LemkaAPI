using Lemka.DAL.Datas;
using Lemka.DAL.Interfaces;
using Lemka.DAL.Mappers;
using DevHopTools.Connection;

namespace Lemka.DAL.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly Connection _connection;

    public AuthRepository(Connection connection)
    {
        _connection = connection;
    }

    public LoggedInUserData? Login(string email, string password)
    {
        Command command = new("spUtilisateursLogin", true);
        command.AddParameter("Email", email);
        command.AddParameter("Password", password);
        return _connection.ExecuteReader(command, x => x.ToLoggedInUser()).SingleOrDefault();
    }

    public void Register(string email, string nom, string prenom, string password)
    {
        Command command = new("spUtilisateursRegister", true);
        command.AddParameter("Email", email);
        command.AddParameter("Password", password);
        command.AddParameter("Nom", nom);
        command.AddParameter("Prenom", prenom);
        _connection.ExecuteNonQuery(command);
    }
}