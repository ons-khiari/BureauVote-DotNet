using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Electeur
    {
        [Required]
        [RegularExpression("[0-9]{8}", ErrorMessage = "invalid CIN number, must be 8 digits")]
        /*[MinLength(8)]
        [MaxLength(8)]*/
        public string CIN { get; set; }
        public DateTime DateNaissance { get; set; }
        public int ElecteurId { get; set; }
        public BureauVote MonBureauVote { get; set; }
        public Genre MonGenre { get; set; }
        public virtual IList<Election> Elections { get; set; }

        public Electeur()
        {
            Elections = new List<Election>();
        }

    }
}
