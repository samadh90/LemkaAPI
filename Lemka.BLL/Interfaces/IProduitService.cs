﻿using Lemka.BLL.Entities;

namespace Lemka.BLL.Interfaces;

public interface IProduitService : IServiceBase<int, ProduitEntity>
{
    IEnumerable<ProduitEntity> GetAll(string? search);
}
