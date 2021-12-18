using System.ComponentModel.DataAnnotations;

namespace Lemka.UIL.Models.Forms;

public class ServiceForm : CommonForm
{
    [Range(1, 180)]
    public int DureeMinute { get; set; }
}
