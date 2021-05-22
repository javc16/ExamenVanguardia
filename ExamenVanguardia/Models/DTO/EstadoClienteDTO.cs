using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.Models.DTO
{
    public class EstadoClienteDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }

        public static EstadoClienteDTO DeModeloADTO(EstadoCliente estadoCliente)
        {
            return estadoCliente != null ? new EstadoClienteDTO
            {
                Id = estadoCliente.Id,
                Descripcion = estadoCliente.Descripcion,
                Estado = estadoCliente.Estado
            } : null;
        }

        public static IEnumerable<EstadoClienteDTO> DeModeloADTO(IEnumerable<EstadoCliente> estadoCliente)
        {
            if (estadoCliente == null)
            {
                return new List<EstadoClienteDTO>();
            }
            List<EstadoClienteDTO> estadoClienteData = new List<EstadoClienteDTO>();

            foreach (var item in estadoCliente)
            {
                estadoClienteData.Add(DeModeloADTO(item));
            }

            return estadoClienteData;
        }


        public static EstadoCliente DeDTOAModelo(EstadoClienteDTO estadoClienteDTO)
        {
            return estadoClienteDTO != null ? new EstadoCliente.Builder(estadoClienteDTO.Descripcion, estadoClienteDTO.Estado).Constuir() : null;
        }
    }
}
