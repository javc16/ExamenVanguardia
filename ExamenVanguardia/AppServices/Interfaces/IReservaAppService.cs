using ExamenVanguardia.Helpers;
using ExamenVanguardia.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.AppServices.Interfaces
{
    public interface IReservaAppService
    {
        IEnumerable<ReservaDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> Post(ReservaDTO reservaDTO);
        Task<Response> Put(ReservaDTO reservaDTO);
        Task<Response> Delete(int id);
    }
}
