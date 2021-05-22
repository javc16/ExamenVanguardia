using ExamenVanguardia.Helpers;
using ExamenVanguardia.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.AppServices.Interfaces
{
    public interface IReservaDetalleAppService
    {
        IEnumerable<ReservaDetalleDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> Post(ReservaDetalleDTO reservaDetalleDTO);
        Task<Response> Put(ReservaDetalleDTO reservaDetalleDTO);
        Task<Response> Delete(int id);
    }
}
