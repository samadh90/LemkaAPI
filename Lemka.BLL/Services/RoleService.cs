using Lemka.BLL.Entities;
using Lemka.BLL.Interfaces;
using Lemka.DAL.Interfaces;

namespace Lemka.BLL.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public RoleEntity? Create(RoleEntity entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int key)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<RoleEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public RoleEntity? GetById(int key)
    {
        throw new NotImplementedException();
    }

    public RoleEntity? Update(int key, RoleEntity entity)
    {
        throw new NotImplementedException();
    }
}
