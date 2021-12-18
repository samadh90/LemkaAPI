using System.ComponentModel.DataAnnotations;

namespace Lemka.UIL.Models.Forms;

public class RendezVousForm
{
    [Required(AllowEmptyStrings = false)]
    public DateTime Jour { get; set; }

    [Required(AllowEmptyStrings = false)]
    public TimeSpan HeureDebut { get; set; }

    [Required]
    public int ServiceId { get; set; }

    public int? DevisId { get; set; }
}
