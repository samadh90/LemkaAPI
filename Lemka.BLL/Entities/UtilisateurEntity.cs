
namespace Lemka.BLL.Entities;

public class UtilisateurEntity
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Tel { get; set; }
    public string? Image { get; set; }
    public string? Prenom { get; set; }
    public string? Nom { get; set; }
    public int? GenreId { get; set; }
    public GenreEntity? Genre { get; set; }
    public AdresseEntity? Adresse { get; set; }
    public string? Role { get; set; }
    public string? Statut { get; set; }
    public DateTime? LastLogin { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
