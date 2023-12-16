using CentraleRecrutement.ApplicationCore.Domain;
using CentraleRecrutement.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentraleRecrutement.ApplicationCore.Services
{
    public class ServiceEntreprise : Service<Entreprise>, IServiceEntreprise
    {
        public ServiceEntreprise(IUnitOfWork utwk) : base(utwk)
        {}

        //Service4
        public int NbrPME()
        {

            return GetMany(p => (p.Effectif > 10) && (p.Effectif < 250) && (p.ChiffreAffaire < 50000000)).Count();

        }
        //Service5
        public IEnumerable<IGrouping<Secteur,Entreprise>> ParSecteur(string ville)
        {
            var query = from entreprise in GetMany(p => (p.AdresseEntreprise.Ville.Equals(ville)))
                        group entreprise by entreprise.Secteur into newGroup
                        orderby newGroup.Key
                        select newGroup;
            return query;
        }
    }
}