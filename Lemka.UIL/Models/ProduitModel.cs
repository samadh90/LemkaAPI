namespace Lemka.UIL.Models;

public class ProduitModel
{
    public int Id { get; set; }
    public string Slug { get; set; }
    public string Titre { get; set; }
    public string? Description { get; set; }
    public decimal Tva { get; set; }
    public decimal Prix { get; set; }
    public string? Image { get; set; }
    public string Statut { get; set; }
    public bool EnAffiche { get; set; }
    public bool IsPromotion { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
