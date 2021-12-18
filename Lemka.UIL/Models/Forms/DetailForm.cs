using System.ComponentModel.DataAnnotations;

namespace Lemka.UIL.Models.Forms;

public class DetailForm
{
    [Required(AllowEmptyStrings = false)]
    public string? Designation { get; set; }

    [Required]
    [Range(0, 10000)]
    public decimal PrixUHt { get; set; }

    [Required]
    [Range(0, 1000)]
    public float Quantite { get; set; }
}
