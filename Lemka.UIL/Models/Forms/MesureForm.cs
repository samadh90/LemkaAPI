using System.ComponentModel.DataAnnotations;

namespace Lemka.UIL.Models.Forms;

public class MesureForm
{
    [Required(AllowEmptyStrings = false)]
    public string? Nom { get; set; }

    public string? Description { get; set; }
    
    [DataType(DataType.ImageUrl)]
    public string? Image { get; set; }
}
