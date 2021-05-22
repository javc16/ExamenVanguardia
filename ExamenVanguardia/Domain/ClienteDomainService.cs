using ExamenVanguardia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.Domain
{
    public class ClienteDomainService
    {
        public string ValidarSiElEstadoExiste(EstadoCliente estadoCliente) 
        {
            if (estadoCliente == null) 
            {
                return "El estado seleccionado no existe";
            }

            return string.Empty;
        }

        public string ValidarSiTieneIdentidad(string identidad)
        {
            if (identidad == string.Empty)
            {
                return "La identidad no puede estar vacia";
            }

            return string.Empty;
        }
    }
}
