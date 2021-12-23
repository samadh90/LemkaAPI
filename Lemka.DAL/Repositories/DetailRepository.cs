using DevHopTools.Connection;
using Lemka.DAL.Datas;
using Lemka.DAL.Interfaces;
using Lemka.DAL.Mappers;

namespace Lemka.DAL.Repositories;

public class DetailRepository : IDetailRepository
{
    private readonly Connection _connection;

    public DetailRepository(Connection connection)
    {
        _connection = connection;
    }

    public IEnumerable<DetailData> GetAll(int devisId)
    {
        string query = "SELECT * FROM dbo.Details WHERE [DevisId] = @DevisId";
        Command command = new(query);
        command.AddParameter("DevisId", devisId);
        return _connection.ExecuteReader(command, r => r.ToDetail());
    }

    public DetailData? GetById(int id)
    {
        string query = "SELECT * FROM dbo.Details WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", id);
        return _connection.ExecuteReader(command, r => r.ToDetail()).SingleOrDefault();
    }

    public int Create(int devisId, DetailData data)
    {
        Command command = new("spDetailsInsert", true);
        command.AddParameter("DevisId", devisId);
        command.AddParameter("Designation", data.Designation);
        command.AddParameter("PrixUHt", data.PrixUHt);
        command.AddParameter("Quantite", data.Quantite);
        command.AddParameter("Tva", data.Tva);
        return int.Parse(_connection.ExecuteScalar(command).ToString());
    }

    public bool Update(int id, DetailData data)
    {
        string query = "UPDATE dbo.[Details] SET [Designation] = @Designation, [PrixUHt] = @PrixUHt, [Tva] = @Tva, [Quantite] = @Quantite WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", id);
        command.AddParameter("Designation", data.Designation);
        command.AddParameter("PrixUHt", data.PrixUHt);
        command.AddParameter("Quantite", data.Quantite);
        command.AddParameter("Tva", data.Tva);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public bool Delete(int id)
    {
        string query = "DELETE FROM dbo.[Details] WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", id);
        return _connection.ExecuteNonQuery(command) > 0;
    }
}
