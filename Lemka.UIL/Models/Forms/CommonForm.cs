using System.ComponentModel.DataAnnotations;

namespace Lemka.UIL.Models.Forms;

public class CommonForm
{
    [Required(AllowEmptyStrings = false)]
    [StringLength(50)]
    public string? Nom { get; set; }
}
