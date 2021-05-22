using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.Models.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public int IdEstadoCliente { get; set; }
        public int Estado { get; set; }
        public string Identidad { get; set; }

        public static ClienteDTO DeModeloADTO(Cliente cliente)
        {
            return cliente != null ? new ClienteDTO
            {
                Id = cliente.Id,
                Nombre =cliente.Nombre,
                Apellido =cliente.Apellido,
                Edad = cliente.Edad,
                IdEstadoCliente = cliente.IdEstadoCliente,
                Estado = cliente.Estado,
                Identidad = cliente.Identidad
               
            } : null;
        }

        public static IEnumerable<ClienteDTO> DeModeloADTO(IEnumerable<Cliente> cliente)
        {
            if (cliente == null)
            {
                return new List<ClienteDTO>();
            }
            List<ClienteDTO> clienteData = new List<ClienteDTO>();

            foreach (var item in cliente)
            {
                clienteData.Add(DeModeloADTO(item));
            }

            return clienteData;
        }


        public static Cliente DeDTOAModelo(ClienteDTO clienteDTO,EstadoCliente estadoCliente)
        {

            return clienteDTO != null ? new Cliente.Builder(clienteDTO.Nombre,clienteDTO.Apellido,clienteDTO.Edad,clienteDTO.IdEstadoCliente,estadoCliente.Estado,clienteDTO.Identidad).conEstadoCliente(estadoCliente).Constuir() : null;
        }
    }
}
