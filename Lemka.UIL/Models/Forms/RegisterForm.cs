using System.ComponentModel.DataAnnotations;

namespace Lemka.UIL.Models.Forms;

public class RegisterForm
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(5)]
    [MaxLength(32)]
    public string Username { get; set; }

    [Required]
    [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Le mot de passe n'est pas assez compliqué.")]
    public string Password { get; set; }
}
