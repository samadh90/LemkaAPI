using Lemka.DAL.Datas;
using Lemka.DAL.Interfaces;
using Lemka.DAL.Mappers;
using DevHopTools.Connection;

namespace Lemka.DAL.Repositories;

public class TvaRepository:ITvaRepository
{
    private readonly Connection _connection;

    public TvaRepository(Connection connection)
    {
        _connection = connection;
    }

    public int Create(TvaData data)
    {
        string query = "INSERT INTO dbo.Tvas ([Taux], [Applicable]) VALUES (@Taux, @Applicable)";
        Command command = new(query);
        command.AddParameter("Taux", data.Taux);
        command.AddParameter("Applicable", data.Applicable);
        return int.Parse(_connection.ExecuteScalar(command).ToString());
    }

    public bool Delete(int key)
    {
        string query = "DELETE FROM dbo.Tvas WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", key);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public IEnumerable<TvaData> GetAll()
    {
        string query = "SELECT * FROM dbo.Tvas";
        Command command = new(query);
        return _connection.ExecuteReader(command, r => r.ToTva());
    }

    public TvaData? GetById(int key)
    {
        string query = "SELECT * FROM dbo.Tvas WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", key);
        return _connection.ExecuteReader(command, r => r.ToTva()).SingleOrDefault();
    }

    public bool Update(int key, TvaData data)
    {
        string query = "UPDATE dbo.Tvas SET [Taux] = @Taux, [Applicable] = @Applicable WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Taux", data.Taux);
        command.AddParameter("Applicable", data.Applicable);
        command.AddParameter("Id", key);
        return _connection.ExecuteNonQuery(command) > 0;
    }
}
