using System.ComponentModel.DataAnnotations;

namespace Lemka.UIL.Models.Forms;

public class ProduitForm
{
    [Required(AllowEmptyStrings = false)]
    public string? Titre { get; set; }

    public string? Description { get; set; }

    public bool EnAffiche { get; set; }

    [Required]
    [Range(0.00, 10000.00)]
    public decimal Prix { get; set; }

    [Required]
    public int CategorieId { get; set; }

    [Required]
    public int TvaId { get; set; }
}

