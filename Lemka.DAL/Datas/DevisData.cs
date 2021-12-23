namespace Lemka.DAL.Datas;

public class DevisData
{
    public int Id { get; set; }
    public string Reference { get; set; }
    public string? Remarque { get; set; }
    public int ExpiresInDays { get; set; }
    public bool? EstAccepte { get; set; }
    public decimal? TotalTva { get; set; }
    public decimal? TotalHT { get; set; }
    public decimal? TotalTTC { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? SubmittedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }
}
