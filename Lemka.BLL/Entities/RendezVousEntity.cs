namespace Lemka.BLL.Entities;

public class RendezVousEntity
{
    public int Id { get; set; }
    public int UtilisateurId { get; set; }
    public DateTime Jour { get; set; }
    public TimeSpan HeureDebut { get; set; }
    public TimeSpan HeureFin { get; set; }
    public int ServiceId { get; set; }
    public ServiceEntity? Service { get; set; }
    public int? DevisId { get; set; }
    public DevisEntity? Devis { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CanceledAt { get; set; }
}

