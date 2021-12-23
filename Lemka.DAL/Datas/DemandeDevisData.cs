namespace Lemka.DAL.Datas;

public class DemandeDevisData
{
    public int Id { get; set; }
    public int UtilisateurId { get; set; }
    public string? Reference { get; set; }
    public string? Titre { get; set; }
    public string? Remarque { get; set; }
    public int ServiceId { get; set; }
    public int? MensurationId { get; set; }
    public bool EstUrgent { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? SubmittedAt { get; set; }
    public bool? DevisStatut { get; set; }
    public bool? DevisDecision { get; set; }
    public bool EstArchive { get; set; }
}
