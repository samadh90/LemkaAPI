namespace Lemka.BLL.Entities;

public class CategorieEntity
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public string? Nom { get; set; }
    public int NbEnfants { get; set; }
}
