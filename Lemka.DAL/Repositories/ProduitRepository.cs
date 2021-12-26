using DevHopTools.Connection;
using Lemka.DAL.Datas;
using Lemka.DAL.Interfaces;
using Lemka.DAL.Mappers;

namespace Lemka.DAL.Repositories;

public class ProduitRepository : IProduitRepository
{
    private readonly Connection _connection;

    public ProduitRepository(Connection connection)
    {
        _connection = connection;
    }

    public int Create(ProduitData data)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int key)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ProduitData> GetAll()
    {
        string query = "SELECT * from dbo.[vProduits]";
        Command command = new(query);
        return _connection.ExecuteReader(command, r => r.ToProduit());
    }

    public IEnumerable<ProduitData> GetAll(string? search)
    {
        throw new NotImplementedException();
    }

    public ProduitData? GetById(int key)
    {
        string query = "SELECT * from dbo.[vProduits] WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", key);
        return _connection.ExecuteReader(command, r => r.ToProduit()).SingleOrDefault();
    }

    public bool Update(int key, ProduitData data)
    {
        throw new NotImplementedException();
    }
}
