using Lemka.DAL.Datas;
using Lemka.DAL.Interfaces;
using Lemka.DAL.Mappers;
using DevHopTools.Connection;

namespace Lemka.DAL.Repositories;

public class TagRepository : ITagRepository
{
    private readonly Connection _connection;

    public TagRepository(Connection connection)
    {
        _connection = connection;
    }

    public int Create(TagData data)
    {
        string query = "INSERT INTO dbo.Tags ([Nom]) VALUES (@Nom); SELECT SCOPE_IDENTITY()";
        Command command = new(query);
        command.AddParameter("Nom", data.Nom);
        return int.Parse(_connection.ExecuteScalar(command).ToString());
    }

    public bool Delete(int key)
    {
        string query = "DELETE FROM dbo.Tags WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", key);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public IEnumerable<TagData> GetAll()
    {
        string query = "SELECT * FROM dbo.Tags";
        Command command = new(query);
        return _connection.ExecuteReader(command, r => r.ToTag());
    }

    public TagData? GetById(int key)
    {
        string query = "SELECT * FROM dbo.Tags WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", key);
        return _connection.ExecuteReader(command, r => r.ToTag()).SingleOrDefault();
    }

    public bool Update(int key, TagData data)
    {
        string query = "UPDATE dbo.Tags SET [Nom] = @Nom WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", key);
        command.AddParameter("Nom", data.Nom);
        return _connection.ExecuteNonQuery(command) > 0;
    }
}
