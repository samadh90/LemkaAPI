using Lemka.BLL.Entities;
using Lemka.BLL.Interfaces;
using Lemka.BLL.Mappers;
using Lemka.DAL.Interfaces;

namespace Lemka.BLL.Services;

public class TagService : ITagService
{
    private readonly ITagRepository _tagRepository;

    public TagService(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public TagEntity? Create(TagEntity entity)
    {
        int id = _tagRepository.Create(entity.ToDal());
        if (id == 0) return null;
        return GetById(id);
    }

    public bool Delete(int key)
    {
        return _tagRepository.Delete(key);
    }

    public IEnumerable<TagEntity> GetAll()
    {
        return _tagRepository.GetAll().Select(x => x.ToBll());
    }

    public TagEntity? GetById(int key)
    {
        return _tagRepository.GetById(key)?.ToBll();
    }

    public TagEntity? Update(int key, TagEntity entity)
    {
        bool success = _tagRepository.Update(key, entity.ToDal());
        if (!success) return null;
        return GetById(key);
    }
}
