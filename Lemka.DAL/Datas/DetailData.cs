﻿namespace Lemka.DAL.Datas;

public class DetailData
{
    public int Id { get; set; }
    public int DevisId { get; set; }
    public string Designation { get; set; }
    public decimal PrixUHt { get; set; }
    public double Quantite { get; set; }
    public double Tva { get; set; }
}
