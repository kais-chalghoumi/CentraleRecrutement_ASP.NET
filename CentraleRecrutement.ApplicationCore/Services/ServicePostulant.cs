using CentraleRecrutement.ApplicationCore.Domain;
using CentraleRecrutement.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentraleRecrutement.ApplicationCore.Services
{
  public  class ServicePostulant : Service<Postulant>, IServicePostulant
    {
        public ServicePostulant(IUnitOfWork utwk) : base(utwk)
        {

        }
        //Service2
        public int NbrOffres(int id)
        {
            return GetMany(p => p.IdPstulant == id).Select(p => p.Offres).Count();
        }
    }
}
