using System.ComponentModel.DataAnnotations;

namespace Lemka.UIL.Models.Forms;

public class DemandeDevisForm
{
    [Required(AllowEmptyStrings = false)]
    public string? Titre { get; set; }

    public string? Remarque { get; set; }

    public int? MensurationId { get; set; }

    [Required]
    public int ServiceId { get; set; }

    public bool EstUrgent { get; set; }
}
