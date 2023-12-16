using CentraleRecrutement.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentraleRecrutement.ApplicationCore.Interfaces
{
 public interface IOffreService:IService<Offre>
    {
        IEnumerable<Entreprise> Top2Entreprise(String type);
        IEnumerable<Offre> OffresMoisEnCours();
    }
}
