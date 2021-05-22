using ExamenVanguardia.Helpers;
using ExamenVanguardia.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.AppServices.Interfaces
{
    public interface IClienteAppService
    {
        IEnumerable<ClienteDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> Post(ClienteDTO clienteDTO);
        Task<Response> Put(ClienteDTO clienteDTO);
        Task<Response> Delete(int id);
    }
}
