using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class VoteService : Service<Vote>, IVoteService
    {
        public VoteService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public PartiePolitique GetPartiePolitique(DateTime dateElection)
        {
            throw new NotImplementedException();
            /*
             * var partiePolitiqueEluId = GetMany(e => e.DateElection == dateElection).
                GroupBy(e => e.PartiePolitiqueId).OrderByDescending(e => e.Count()).First().Key;
            
            return UnitOfwork.Repository<PartiePolitique>().GetById(partiePolitiqueEluId);
             * */
        }
    }
}
