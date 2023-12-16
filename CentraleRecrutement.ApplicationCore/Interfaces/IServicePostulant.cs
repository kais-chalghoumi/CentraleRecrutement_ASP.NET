using CentraleRecrutement.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentraleRecrutement.ApplicationCore.Interfaces
{
 public   interface IServicePostulant:IService<Postulant>
    {
        int NbrOffres(int id);
    }
}
