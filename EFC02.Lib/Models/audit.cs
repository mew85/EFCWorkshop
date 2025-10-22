using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public abstract class Audit
{
    public DateTime AngelegtAm { get; set; } = DateTime.Now;
    public DateTime? GeaendertAm { get; set; }        
    [StringLength(50)]
    public String AngelegtVon { get; set; } = Environment.UserName;

    [StringLength(50)]
    public String? GeaendertVon { get; set; }
    //[DefaultValue(true)] – Funktioniert nicht!!!
    public bool IstAktiv { get; set; } = true;
    //[DefaultValue(false)]
    public bool IstGeloescht { get; set; } = false;
}
