global using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EFC04.Lib.Models.Json
{
    [Table("Kunde", Schema = "json")]
    public partial class Kunde
    {
        public virtual int KundeId { get; set; }
        [Required]
        [StringLength(20)]
        public virtual string Nachname { get; set; }
        [StringLength(20)]
        public virtual string Vorname { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public virtual string Geschlecht { get; set; }
        [Precision(0)]
        public virtual DateOnly? Geburtsdatum { get; set; }
        [Precision(0)]
        public virtual DateOnly? Kundeseit { get; set; }
        public virtual KundeDetails Kundedetails { get; set; } = null;
    }

}
