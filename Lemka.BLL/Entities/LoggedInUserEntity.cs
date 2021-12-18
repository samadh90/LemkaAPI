namespace Lemka.BLL.Entities;

public class LoggedInUserEntity
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Username { get; set; }
    public string? Role { get; set; }
    public string? Statut { get; set; }
}