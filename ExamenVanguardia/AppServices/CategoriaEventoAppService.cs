using ExamenVanguardia.AppServices.Interfaces;
using ExamenVanguardia.Context;
using ExamenVanguardia.Helpers;
using ExamenVanguardia.Models;
using ExamenVanguardia.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.AppServices
{
    public class CategoriaEventoAppService : ICategoriaEventoAppService
    {
        private readonly MyContext _context;

        public CategoriaEventoAppService(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoriaEventoDTO> GetAll()
        {
            var categoriaEvento = _context.CategoriaEvento.Where(x => x.Estado == Constantes.Activo);
            var categoriaEventoDTO = CategoriaEventoDTO.DeModeloADTO(categoriaEvento);
            return categoriaEventoDTO;
        }

        public async Task<Response> GetById(long id)
        {
            var categoriaEvento = await _context.CategoriaEvento.FirstOrDefaultAsync(r => r.Id == id);
            if (categoriaEvento == null)
            {
                return new Response { Mensaje = "Esta categoria no existe" };
            }
            var data = CategoriaEventoDTO.DeModeloADTO(categoriaEvento);
            return new Response { Datos = data };
        }

        public async Task<Response> PostCategoriaEvento(CategoriaEventoDTO categoriaEventoDTO)
        {
         
            var SavedUser = await _context.CategoriaEvento.FirstOrDefaultAsync(r => r.Descripcion == categoriaEventoDTO.Descripcion);
            if (SavedUser != null)
            {
                return new Response { Mensaje = $"Esta categoria: {categoriaEventoDTO.Descripcion} ya existe en el sistema" };
            }
            var categoriaEvento = CategoriaEventoDTO.DeDTOAModelo(categoriaEventoDTO);
            _context.CategoriaEvento.Add(categoriaEvento);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Categoria {categoriaEventoDTO.Descripcion} agregada exitosamente" };
        }

        public async Task<Response> PutCategoriaEvento(CategoriaEventoDTO categoriaEventoDTO)
        {
            var categoriaEvento = CategoriaEventoDTO.DeDTOAModelo(categoriaEventoDTO);
            _context.Entry(categoriaEvento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"La categoria {categoriaEventoDTO.Descripcion} se modifico correctamente" };
        }

        public async Task<Response> DeleteCategoriaEvento(int id)
        {
            var categoriaEvento = await _context.CategoriaEvento.FindAsync(id);
            if (categoriaEvento == null)
            {
                return new Response { Mensaje = $"No tenemos una catogria con esta id" }; ;
            }
            categoriaEvento.Estado = Constantes.Inactivo;
            _context.Entry(categoriaEvento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"La categoria {categoriaEvento.Descripcion} fue eliminada correctamente" };
        }
    }
}
