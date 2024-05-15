using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Vote
    {
        public DateTime DateElection { get; set; }
        public DateTime DateVote { get; set; }
        public BureauVote MonBureauVote { get; set; }
        public int PartiePolitiqueId { get; set; }
        public int VoteId { get; set; }
        [ForeignKey(nameof(DateElection))]
        public virtual Election Elections { get; set; }
        [ForeignKey(nameof(PartiePolitiqueId))]
        public virtual PartiePolitique PartiePolitiques { get; set; }
    }
}
