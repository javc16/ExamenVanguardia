using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.Models.DTO
{
    public class ReservaDetalleDTO
    {
        public int Id { get; set; }
        public int IdReserva { get; set; }
        public int IdMobiliario { get; set; }
        public int CantidadReserva { get; set; }
    }
}
