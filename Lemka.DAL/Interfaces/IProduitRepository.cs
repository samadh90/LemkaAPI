using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lemka.DAL.Datas;

namespace Lemka.DAL.Interfaces;

public interface IProduitRepository : IRepositoryBase<int, ProduitData>
{
    IEnumerable<ProduitData> GetAll(string? search);
}
