using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC04.Lib.Models.Single
{
    [Table("Adresse", Schema = "single")]
    public partial class Adresse
    {
        [Key]
        public int AdresseId { get; set; }
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

        public int? KundeDetailsId { get; set; }
        public KundeDetails KundeDetails { get; set; }    
    }

}
