namespace Lemka.DAL.Datas;

public class CategorieData
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public string? Nom { get; set; }
    public int NbEnfants { get; set; }
}
