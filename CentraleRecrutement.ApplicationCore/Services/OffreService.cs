using CentraleRecrutement.ApplicationCore.Domain;
using CentraleRecrutement.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentraleRecrutement.ApplicationCore.Services
{
    public class OffreService : Service<Offre>, IOffreService

    {
        public OffreService(IUnitOfWork utwk) : base(utwk)
        {

        }
        //Service1
        public IEnumerable<Offre> OffresMoisEnCours()
        {
            return GetMany(o => (o.DatePublication.Month == DateTime.Now.Month)
                        && (o.DatePublication.Year == DateTime.Now.Year));

        }


        //Service3
        public IEnumerable<Entreprise> Top2Entreprise(String type)
        {
            var linq = (from offre in GetMany(o => o.TypeContrat == type)
                        orderby offre.Postulants.Count()
                        group offre by offre.EntrepriseFK into newGroup
                        select newGroup).Take(2);
            return (IEnumerable<Entreprise>)linq;
        }
    }
}
