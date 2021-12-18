using Lemka.DAL.Datas;
using Lemka.DAL.Interfaces;
using Lemka.DAL.Mappers;
using DevHopTools.Connection;

namespace Lemka.DAL.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly Connection _connection;

    public GenreRepository(Connection connection)
    {
        _connection = connection;
    }

    public IEnumerable<GenreData> GetAll()
    {
        string query = "SELECT * FROM dbo.Genres";
        Command command = new(query);
        return _connection.ExecuteReader(command, r => r.ToGenre());
    }

    public int Create(GenreData data)
    {
        string query = "INSERT INTO dbo.Genres (Nom) VALUES (@Nom); SELECT SCOPE_IDENTITY() as 'Id'";
        Command command = new(query);
        command.AddParameter("Nom", data.Nom);
        return int.Parse(_connection.ExecuteScalar(command).ToString());
    }

    public GenreData? GetById(int key)
    {
        string query = "SELECT * FROM dbo.Genres WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", key);
        return _connection.ExecuteReader(command, r => r.ToGenre()).SingleOrDefault();
    }

    public bool Update(int key, GenreData data)
    {
        string query = "UPDATE dbo.Genres SET [Nom] = @Nom WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", key);
        command.AddParameter("Nom", data.Nom);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public bool Delete(int key)
    {
        string query = "DELETE FROM dbo.Genres WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", key);
        return _connection.ExecuteNonQuery(command) > 0;
    }
}
