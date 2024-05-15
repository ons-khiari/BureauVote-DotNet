using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class ElectionService : Service<Election>, IElectionService
    {
        public ElectionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public int GetElecteursCount(DateTime dateElection)
        {
            //bch t7seb l electeurs hasb l date election
            //return GetMany(e => e.DateElection == dateElection).Single().Electeurs.Count;
            //return Get(e => e.DateElection == dateElection).Electeurs.Count;
            return GetById(dateElection).Electeurs.Count;
        }

        public float GetElecteursJeunesPercentage(DateTime dateElection)
        {
            var electeursJeunesCount = GetById(dateElection).Electeurs.Where(e =>
            {
                var age = (DateTime.Now - e.DateNaissance).TotalDays / 365;
                return age >= 18 && age <= 35;
            }).Count();
            return electeursJeunesCount / GetElecteursCount(dateElection) * 100;
        }
    }
}
