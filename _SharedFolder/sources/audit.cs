public abstract class Audit
{
    public DateTime angelegtAm { get; set; } = DateTime.Now;
    public DateTime geaendertAm { get; set; }        
    [StringLength(50)]
    public String angelegtVon { get; set; } = Environment.UserName;

    [StringLength(50)]
    [DefaultValue("")]
    public String geaendertVon { get; set; }
    //[DefaultValue(true)] – Funktioniert nicht!!!
    public bool istAktiv { get; set; } = true;
    //[DefaultValue(false)]
    public bool istGeloescht { get; set; } = false;
}
