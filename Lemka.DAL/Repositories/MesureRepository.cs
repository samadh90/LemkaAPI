using Lemka.DAL.Datas;
using Lemka.DAL.Interfaces;
using Lemka.DAL.Mappers;
using DevHopTools.Connection;

namespace Lemka.DAL.Repositories;

public  class MesureRepository : IMesureRepository
{
    private readonly Connection _connection;

    public MesureRepository(Connection connection)
    {
        _connection = connection;
    }

    public int Create(MesureData data)
    {
        Command command = new("spMesuresInsert", true);
        command.AddParameter("Nom", data.Nom);
        command.AddParameter("Description", data.Description);
        command.AddParameter("Image", data.Image);
        return int.Parse(_connection.ExecuteScalar(command).ToString());
    }

    public bool Delete(int key)
    {
        string query = "DELETE FROM dbo.Mesures WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", key);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public IEnumerable<MesureData> GetAll()
    {
        string query = "SELECT * FROM dbo.Mesures";
        Command command = new(query);
        return _connection.ExecuteReader(command, r => r.ToMesure());
    }

    public MesureData? GetById(int key)
    {
        string query = "SELECT * FROM dbo.Mesures WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", key);
        return _connection.ExecuteReader(command, r => r.ToMesure()).SingleOrDefault();
    }

    public bool Update(int key, MesureData data)
    {
        string query = "UPDATE dbo.Mesures SET [Nom] = @Nom, [Description] = @Description, [Image] = @Image WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", key);
        command.AddParameter("Nom", data.Nom);
        command.AddParameter("Description", data.Description);
        command.AddParameter("Image", data.Image);
        return _connection.ExecuteNonQuery(command) > 0;
    }
}
