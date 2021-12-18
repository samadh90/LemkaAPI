namespace Lemka.BLL.Entities;

public class DemandeDevisEntity
{
    public int Id { get; set; }
    public int UtilisateurId { get; set; }
    public string? Numero { get; set; }
    public string? Titre { get; set; }
    public string? Remarque { get; set; }
    public int ServiceId { get; set; }
    public ServiceEntity? Service { get; set; }
    public int? MensurationId { get; set; }
    public MensurationEntity? Mensuration { get; set; }
    public bool EstUrgent { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? SubmittedAt { get; set; }
    public bool? DevisStatut { get; set; }
    public bool? DevisDecision { get; set; }
}
