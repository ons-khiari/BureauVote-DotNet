using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Election
    {
        [Key]
        public DateTime DateElection { get; set; }
        public TypeElection MonTypeElection { get; set; }
        public virtual IList<Electeur> Electeurs { get; set; }
        public virtual IList<Vote> Votes { get; set; }

    }
}
