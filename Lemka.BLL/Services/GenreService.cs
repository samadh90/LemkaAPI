using Lemka.BLL.Entities;
using Lemka.BLL.Interfaces;
using Lemka.BLL.Mappers;
using Lemka.DAL.Interfaces;

namespace Lemka.BLL.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;

    public GenreService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public IEnumerable<GenreEntity> GetAll()
    {
        return _genreRepository.GetAll().Select(x => x.ToBll());
    }

    public GenreEntity? Create(GenreEntity entity)
    {
        int id = _genreRepository.Create(entity.ToDal());
        if (id == 0) return null;
        return GetById(id); 
    }

    public GenreEntity? GetById(int key)
    {
        return _genreRepository.GetById(key)?.ToBll();
    }

    public GenreEntity? Update(int key, GenreEntity entity)
    {
        bool success = _genreRepository.Update(key, entity.ToDal());
        if (!success) return null;
        return GetById(key);
    }

    public bool Delete(int key)
    {
        return _genreRepository.Delete(key);
    }
}
