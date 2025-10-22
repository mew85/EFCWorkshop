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
    public partial class KundeDetails
    {
        [Key]
        public int KundeDetailsId { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string Telefon { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string Email { get; set; }

        public Kunde Kunde { get; set; }
        public Adresse Anschrift { get; set; } = new Adresse();


    }

}
