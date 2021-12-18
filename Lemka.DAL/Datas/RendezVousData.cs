namespace Lemka.DAL.Datas;

public class RendezVousData
{
    public int Id { get; set; }
    public int UtilisateurId { get; set; }
    public DateTime Jour { get; set; }
    public TimeSpan HeureDebut { get; set; }
    public TimeSpan HeureFin { get; set; }
    public int ServiceId { get; set; }
    public int? DevisId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CanceledAt { get; set; }
}
