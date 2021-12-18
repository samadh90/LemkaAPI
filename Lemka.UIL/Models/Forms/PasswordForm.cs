using System.ComponentModel.DataAnnotations;

namespace Lemka.UIL.Models.Forms;

public class PasswordForm
{
    [Required(AllowEmptyStrings = false)]
    public string? OldPassword { get; set; }

    [Required(AllowEmptyStrings = false)]
    [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Le mot de passe n'est pas assez compliqué.")]
    public string? NewPassword { get; set; }
}
