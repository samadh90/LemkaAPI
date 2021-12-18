using System.ComponentModel.DataAnnotations;

namespace Lemka.UIL.Models.Forms;

public class HoraireForm
{
    [RegularExpression(@"^((?:[01]\d|2[0-3]):[0-5]\d:[0-5]\d$)")]
    public TimeSpan? HeureOuverture { get; set; }

    [RegularExpression(@"^((?:[01]\d|2[0-3]):[0-5]\d:[0-5]\d$)")]
    public TimeSpan? HeureFermeture { get; set; }
    public bool SurRdv { get; set; }
    public bool EstFerme { get; set; }
}

/*
{
  "heureOuverture": "10:00:00",
  "heureFermeture": "17:00:00",
  "surRdv": false,
  "estFerme": false
}
 */