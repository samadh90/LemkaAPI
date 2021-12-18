namespace Lemka.BLL.Entities;

public class AdresseEntity
{
    public int Id { get; set; }
    public string? Pays { get; set; }
    public string? Ville { get; set; }
    public string? CodePostal { get; set; }
    public string? Rue { get; set; }
    public string? Numero { get; set; }
    public string? Boite { get; set; }
}
