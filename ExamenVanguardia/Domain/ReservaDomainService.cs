using ExamenVanguardia.Helpers;
using ExamenVanguardia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.Domain
{
    public class ReservaDomainService
    {
        public string ValidarSiElClienteExiste(Cliente cliente)
        {
            if (cliente == null)
            {
                return "El cliente no existe";
            }

            return string.Empty;
        }


        public string ValidarSiLaCategoriaDelEventoExiste(CategoriaEvento categoriaEvento)
        {
            if (categoriaEvento == null)
            {
                return "No existe esta categoria de evento";
            }

            return string.Empty;
        }


        public string ValidarQueElClienteTengaMasDe21(Cliente cliente)
        {
            if (cliente.Edad <=21)
            {
                return "No tiene edad para reservar";
            }

            return string.Empty;
        }


        public string ValidarEstadoCliente(Cliente cliente)
        {
            if (cliente.Estado.Equals(Constantes.Mora))
            {
                return "Cliente no puede reservar porque tiene mora";
            }
            else if (cliente.Estado.Equals(Constantes.Cancelado))
            {
                return "Cliente no puede reservar porque esta cancelado";
            }

            return string.Empty;
        }
    }
}
