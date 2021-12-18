using System.ComponentModel.DataAnnotations;

namespace Lemka.UIL.Models.Forms;

public class MensurationForm
{
    [Required(AllowEmptyStrings = false)]
    public string? Titre { get; set; }

    public string? Description { get; set; }

    public bool IsMain { get; set; }
}
