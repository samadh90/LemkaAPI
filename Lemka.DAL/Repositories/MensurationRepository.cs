using Lemka.DAL.Datas;
using Lemka.DAL.Interfaces;
using Lemka.DAL.Mappers;
using DevHopTools.Connection;

namespace Lemka.DAL.Repositories;

public class MensurationRepository : IMensurationRepository
{
    private readonly Connection _connection;

    public MensurationRepository(Connection connection)
    {
        _connection = connection;
    }

    public int CreateUserMensuration(int userId, MensurationData data)
    {
        Command command = new("spMensurationsInsert", true);
        command.AddParameter("UtilisateurId", userId);
        command.AddParameter("Titre", data.Titre);
        command.AddParameter("Description", data.Description);
        command.AddParameter("IsMain", data.IsMain);
        return int.Parse(_connection.ExecuteScalar(command).ToString());
    }

    public bool DeleteMensuration(int id)
    {
        string query = "DELETE FROM dbo.Mensurations WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", id);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public MensurationData? GetMensuration(int id)
    {
        string query = "SELECT * FROM dbo.Mensurations WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", id);
        return _connection.ExecuteReader(command, r => r.ToMensuration()).SingleOrDefault();
    }

    public IEnumerable<MensurationMesureData> GetMensurationMesures(int id)
    {
        Command command = new("spMensurationMesuresGetAll", true);
        command.AddParameter("MensurationId", id);
        return _connection.ExecuteReader(command, r => r.ToMensurationMesure());
    }

    public IEnumerable<MensurationData> GetUserMensurations(int userId)
    {
        string query = "SELECT * FROM dbo.Mensurations WHERE [UtilisateurId] = @UtilisateurId";
        Command command = new(query);
        command.AddParameter("UtilisateurId", userId);
        return _connection.ExecuteReader(command, r => r.ToMensuration());
    }

    public bool UpdateMensuration(int id, MensurationData data)
    {
        string query = "UPDATE dbo.Mensurations SET [Titre] = @Titre, [Description] = @Description, [IsMain] = @IsMain WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", id);
        command.AddParameter("Titre", data.Titre);
        command.AddParameter("Description", data.Description);
        command.AddParameter("IsMain", data.IsMain);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public bool UpdateMesure(int mensurationId, int mesureId, decimal valeur)
    {
        Command command = new("spMensurationMesuresUpdate", true);
        command.AddParameter("MensurationId", mensurationId);
        command.AddParameter("MesureId", mesureId);
        command.AddParameter("Valeur", valeur);
        return _connection.ExecuteNonQuery(command) > 0;
    }
}
