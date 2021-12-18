namespace Lemka.UIL.Models;

public class RendezVousModel
{
    public int Id { get; set; }
    public int UtilisateurId { get; set; }
    public DateTime Jour { get; set; }
    public TimeSpan HeureDebut { get; set; }
    public TimeSpan HeureFin { get; set; }
    public ServiceModel? Service { get; set; }
    public DevisModel? Devis { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CanceledAt { get; set; }
}
