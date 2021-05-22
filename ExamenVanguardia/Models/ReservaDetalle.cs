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
        public int Estado {get; set; }


        public sealed class Builder
        {
            private readonly ReservaDetalle _reservaDetalle;

            public Builder(int idReserva, int idMobiliario, int CantidadReserva, int estado)
            {
                _reservaDetalle = new ReservaDetalle
                {
                    IdReserva = idReserva,
                    IdMobiliario = idMobiliario,
                    CantidadReserva = CantidadReserva,                
                    Estado = estado
                };
            }          



            public ReservaDetalle Constuir()
            {
                return _reservaDetalle;
            }
        }
    }
}

