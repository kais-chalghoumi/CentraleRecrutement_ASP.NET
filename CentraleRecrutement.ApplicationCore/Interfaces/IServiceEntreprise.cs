using CentraleRecrutement.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentraleRecrutement.ApplicationCore.Interfaces
{
  public interface IServiceEntreprise: IService<Entreprise> 
    {
        int NbrPME();
        IEnumerable<IGrouping<Secteur, Entreprise>> ParSecteur(string ville);
    }
}
