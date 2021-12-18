using System.ComponentModel.DataAnnotations;

namespace Lemka.UIL.Models.Forms;

public class AdresseForm
{
    [Required(AllowEmptyStrings = false)]
    public string? Pays { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string? Ville { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string? CodePostal { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string? Rue { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string? Numero { get; set; }

    public string? Boite { get; set; }
}
