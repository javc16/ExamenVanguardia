using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.Models
{
    public class ReservaDetalle
    {
        public int Id { get; set; }
        public int IdReserva { get; set; }
        public Reserva Reserva { get; set; }
        public int IdMobiliario { get; set; }
        public Mobiliario Mobiliario { get; set; }
        public int CantidadReserva { get; set; }
    }
}

