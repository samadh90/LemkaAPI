namespace Lemka.DAL.Datas;

public class ProduitData
{
    public int Id { get; set; }
    public string Slug { get; set; }
    public string Titre { get; set; }
    public decimal Prix { get; set; }
    public string Statut { get; set; }
    public string? Image { get; set; }
    public bool EnAffiche { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
