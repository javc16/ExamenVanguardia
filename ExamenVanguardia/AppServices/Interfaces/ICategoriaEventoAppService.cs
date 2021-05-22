using ExamenVanguardia.Helpers;
using ExamenVanguardia.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.AppServices.Interfaces
{
    public interface ICategoriaEventoAppService
    {
        IEnumerable<CategoriaEventoDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostCategoriaEvento(CategoriaEventoDTO categoriaEventoDTO);
        Task<Response> PutCategoriaEvento(CategoriaEventoDTO categoriaEventoDTO);
        Task<Response> DeleteCategoriaEvento(int id);
    }
}
