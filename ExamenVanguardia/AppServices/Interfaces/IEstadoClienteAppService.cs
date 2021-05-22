using ExamenVanguardia.Helpers;
using ExamenVanguardia.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.AppServices.Interfaces
{
    public interface IEstadoClienteAppService
    {
        IEnumerable<EstadoClienteDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostEstadoCliente(EstadoClienteDTO estadoClienteDTO);
        Task<Response> PutEstadoCliente(EstadoClienteDTO estadoClienteDTO);
        Task<Response> DeleteEstadoCliente(int id);
    }
}
