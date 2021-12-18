using Lemka.DAL.Datas;
using Lemka.DAL.Interfaces;
using Lemka.DAL.Mappers;
using DevHopTools.Connection;

namespace Lemka.DAL.Repositories;

public class CategorieRepository : ICategorieRepository
{
    private readonly Connection _connection;

    public CategorieRepository(Connection connection)
    {
        _connection = connection;
    }

    public int Create(CategorieData data)
    {
        string query = "INSERT INTO dbo.Categories ([ParentId], [Nom]) VALUES (@ParentId, @Nom); SELECT SCOPE_IDENTITY() as 'Id'";
        Command command = new(query);
        command.AddParameter("ParentId", data.ParentId);
        command.AddParameter("Nom", data.Nom);
        return int.Parse(_connection.ExecuteScalar(command).ToString());
    }

    public bool Delete(int key)
    {
        string query = "DELETE FROM dbo.Categories WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", key);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public IEnumerable<CategorieData> GetAll()
    {
        Command command = new("spCategoriesGetOneOrAllOrChildren", true);
        command.AddParameter("Id", null);
        command.AddParameter("ParentId", null);
        return _connection.ExecuteReader(command, r => r.ToCategorie());
    }

    public CategorieData? GetById(int key)
    {
        Command command = new("spCategoriesGetOneOrAllOrChildren", true);
        command.AddParameter("ParentId", null);
        command.AddParameter("Id", key);
        return _connection.ExecuteReader(command, r => r.ToCategorie()).SingleOrDefault();
    }

    public IEnumerable<CategorieData> GetEnfants(int id)
    {
        Command command = new("spCategoriesGetOneOrAllOrChildren", true);
        command.AddParameter("Id", null);
        command.AddParameter("ParentId", id);
        return _connection.ExecuteReader(command, r => r.ToCategorie());
    }

    public bool Update(int key, CategorieData data)
    {
        string query = "UPDATE dbo.Categories SET [ParentId] = @ParentId, [Nom] = @Nom WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", key);
        command.AddParameter("ParentId", data.ParentId);
        command.AddParameter("Nom", data.Nom);
        return _connection.ExecuteNonQuery(command) > 0;
    }
}
