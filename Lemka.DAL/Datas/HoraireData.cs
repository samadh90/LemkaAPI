namespace Lemka.DAL.Datas;

public class HoraireData
{
    public string? Jour { get; set; }
    public int JourSemaine { get; set; }
    public TimeSpan? HeureOuverture { get; set; }
    public TimeSpan? HeureFermeture { get; set; }
    public bool SurRdv { get; set; }
    public bool EstFerme { get; set; }
}
