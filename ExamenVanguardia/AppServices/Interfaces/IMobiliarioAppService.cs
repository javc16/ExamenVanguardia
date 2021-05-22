using ExamenVanguardia.Helpers;
using ExamenVanguardia.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.AppServices.Interfaces
{
    public interface IMobiliarioAppService
    {
        IEnumerable<MobiliarioDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> Post(MobiliarioDTO mobiliarioDTO);
        Task<Response> Put(MobiliarioDTO mobiliarioDTO);
        Task<Response> Delete(int id);
    }
}
