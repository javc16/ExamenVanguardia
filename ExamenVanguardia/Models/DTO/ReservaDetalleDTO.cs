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
        public int Estado { get; set; }

        public static ReservaDetalleDTO DeModeloADTO(ReservaDetalle reservaDetalle)
        {
            return reservaDetalle != null ? new ReservaDetalleDTO
            {
                Id = reservaDetalle.Id,
                IdReserva = reservaDetalle.IdReserva,
                IdMobiliario = reservaDetalle.IdMobiliario,
                CantidadReserva = reservaDetalle.CantidadReserva,                
                Estado = reservaDetalle.Estado
            } : null;
        }

        public static IEnumerable<ReservaDetalleDTO> DeModeloADTO(IEnumerable<ReservaDetalle> reserva)
        {
            if (reserva == null)
            {
                return new List<ReservaDetalleDTO>();
            }
            List<ReservaDetalleDTO> reservaData = new List<ReservaDetalleDTO>();

            foreach (var item in reserva)
            {
                reservaData.Add(DeModeloADTO(item));
            }

            return reservaData;
        }


        public static ReservaDetalle DeDTOAModelo(ReservaDetalleDTO reservaDetalleDTO)
        {
            return reservaDetalleDTO != null ? new ReservaDetalle.Builder(reservaDetalleDTO.IdReserva,reservaDetalleDTO.IdMobiliario,reservaDetalleDTO.CantidadReserva, reservaDetalleDTO.Estado).Constuir() : null;
        }
    }
}
