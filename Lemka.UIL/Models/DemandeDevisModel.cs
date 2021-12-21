namespace Lemka.UIL.Models;

public class DemandeDevisModel
{
    public int Id { get; set; }
    public int UtilisateurId { get; set; }
    public string? Reference { get; set; }
    public string? Titre { get; set; }
    public string? Remarque { get; set; }
    public ServiceModel? Service { get; set; }
    public MensurationModel? Mensuration { get; set; }
    public bool EstUrgent { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? SubmittedAt { get; set; }
    public bool? DevisStatut { get; set; }
    public bool? DevisDecision { get; set; }
}
