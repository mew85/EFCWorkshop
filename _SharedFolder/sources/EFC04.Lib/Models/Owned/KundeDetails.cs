using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC04.Lib.Models.Owned
{
    [Owned]
    [Table("Kunde", Schema = "owned")]
    public partial class KundeDetails
    {
        [StringLength(20)]
        [Unicode(false)]
        public string Telefon { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string Email { get; set; }
        public Adresse Anschrift { get; set; }
    }

}
