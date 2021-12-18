using System.ComponentModel.DataAnnotations;

namespace Lemka.UIL.Models.Forms;

public class UserRoleForm
{
    [Required]
    [RegularExpression("([1-9][0-9]*)", ErrorMessage = "La valeur doit être un entier supérieur à 0 !")]
    public int RoleId { get; set; }
}
