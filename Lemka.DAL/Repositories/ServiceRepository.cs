using Lemka.DAL.Datas;
using Lemka.DAL.Interfaces;
using Lemka.DAL.Mappers;
using DevHopTools.Connection;

namespace Lemka.DAL.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly Connection _connection;

    public ServiceRepository(Connection connection)
    {
        _connection = connection;
    }

    public int Create(ServiceData data)
    {
        string query = "INSERT INTO dbo.Services ([Nom], [DureeMinute]) VALUES (@Nom, @DureeMinute); SELECT SCOPE_IDENTITY()";
        Command command = new(query);
        command.AddParameter("Nom", data.Nom);
        command.AddParameter("DureeMinute", data.DureeMinute);
        return int.Parse(_connection.ExecuteScalar(command).ToString());
    }

    public bool Delete(int key)
    {
        string query = "DELETE FROM dbo.Services WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", key);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public IEnumerable<ServiceData> GetAll()
    {
        string query = "SELECT * FROM dbo.Services";
        Command command = new(query);
        return _connection.ExecuteReader(command, r => r.ToService());
    }

    public ServiceData? GetById(int key)
    {
        string query = "SELECT * FROM dbo.Services WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", key);
        return _connection.ExecuteReader(command, r => r.ToService()).SingleOrDefault();
    }

    public bool Update(int key, ServiceData data)
    {
        string query = "UPDATE dbo.Services SET [Nom] = @Nom, [DureeMinute] = @DureeMinute WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", key);
        command.AddParameter("Nom", data.Nom);
        command.AddParameter("DureeMinute", data.DureeMinute);
        return _connection.ExecuteNonQuery(command) > 0;
    }
}
