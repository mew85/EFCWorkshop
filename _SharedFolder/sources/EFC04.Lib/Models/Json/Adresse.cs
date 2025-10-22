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
    public partial class Adresse
    {
        [StringLength(50)]
        public virtual string Land { get; set; }
        [StringLength(50)]
        public virtual string Ort { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public virtual string Plz { get; set; }
        [StringLength(50)]
        public virtual string Strasse { get; set; }
        [StringLength(10)]
        public virtual string Hausnummer { get; set; }
    }

}
