namespace Lemka.BLL.Entities;

public class DetailEntity
{
    public int Id { get; set; }
    public string Designation { get; set; }
    public decimal PrixUHt { get; set; }
    public double Quantite { get; set; }
    public double Tva { get; set; }
    public decimal TotalTva { get => PrixUHt * (decimal)Quantite * (decimal)Tva; }
    public decimal TotalHT { get => PrixUHt * (decimal)Quantite; }
}
