using Examen.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IElectionService: IService<Election>
    {
        int GetElecteursCount(DateTime dateElection);
        float GetElecteursJeunesPercentage(DateTime dateElection);
    }
}
