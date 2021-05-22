using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.Models.DTO
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int IdCategoriaEvento { get; set; }
        public int IdCliente { get; set; }
        public int Estado { get; set; }

        public static ReservaDTO DeModeloADTO(Reserva reserva)
        {
            return reserva != null ? new ReservaDTO
            {
                Id = reserva.Id,
                Descripcion = reserva.Descripcion,
                FechaInicial = reserva.FechaInicial,
                FechaFinal = reserva.FechaFinal,
                IdCategoriaEvento = reserva.IdCategoriaEvento,
                IdCliente = reserva.IdCliente,
                Estado = reserva.Estado
            } : null;
        }

        public static IEnumerable<ReservaDTO> DeModeloADTO(IEnumerable<Reserva> reserva)
        {
            if (reserva == null)
            {
                return new List<ReservaDTO>();
            }
            List<ReservaDTO> reservaData = new List<ReservaDTO>();

            foreach (var item in reserva)
            {
                reservaData.Add(DeModeloADTO(item));
            }

            return reservaData;
        }


        public static Reserva DeDTOAModelo(ReservaDTO reservaDTO)
        {
            return reservaDTO != null ? new Reserva.Builder(reservaDTO.Descripcion,reservaDTO.FechaInicial,reservaDTO.FechaFinal,reservaDTO.IdCategoriaEvento,reservaDTO.IdCliente,reservaDTO.Estado).Constuir() : null;
        }
    }
}
