using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class PartiePolitique
    {
        public DateTime DateFondation { get; set; }
        public string Details { get; set; }
        public string Nom { get; set; }
        public int PartiePolitiqueId { get; set; }
        public virtual IList<Vote> Votes { get; set; }
    }
}
