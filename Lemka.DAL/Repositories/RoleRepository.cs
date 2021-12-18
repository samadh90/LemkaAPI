using Lemka.DAL.Datas;
using Lemka.DAL.Interfaces;
using Lemka.DAL.Mappers;
using DevHopTools.Connection;

namespace Lemka.DAL.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly Connection _connection;

    public RoleRepository(Connection connection)
    {
        _connection = connection;
    }

    public IEnumerable<RoleData> GetAll()
    {
        Command command = new("SELECT * FROM dbo.Roles");
        return _connection.ExecuteReader(command, m => m.ToRole());
    }

    public int Create(RoleData data)
    {
        string query = "INSERT INTO dbo.Roles (Nom) VALUES (@Nom); SELECT SCOPE_IDENTITY()";
        Command command = new(query);
        command.AddParameter("Nom", data.Nom);
        return (int)_connection.ExecuteScalar(command);
    }

    public RoleData? GetById(int key)
    {
        Command command = new("SELECT * FROM dbo.Roles WHERE [Id] = @Id");
        command.AddParameter("Id", key);
        return _connection.ExecuteReader(command, m => m.ToRole()).SingleOrDefault();
    }

    public bool Update(int key, RoleData data)
    {
        string query = "UPDATE dbo.Roles SET [Nom] = @Nom WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", key);
        command.AddParameter("Nom", data.Nom);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public bool Delete(int id)
    {
        string query = "DELETE FROM dbo.Roles WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", id);
        return _connection.ExecuteNonQuery(command) > 0;
    }
}
