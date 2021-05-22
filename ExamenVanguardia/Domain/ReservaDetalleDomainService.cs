using ExamenVanguardia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.Domain
{
    public class ReservaDetalleDomainService
    {
        public string ValidarEstadoMobiliario(Mobiliario mobiliario)
        {
            if (!mobiliario.Equals("disponible"))
            {
                return "No esta disponible el mobiliario";
            }

            return string.Empty;
        }
    }
}
