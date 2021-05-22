using ExamenVanguardia.AppServices.Interfaces;
using ExamenVanguardia.Context;
using ExamenVanguardia.Helpers;
using ExamenVanguardia.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.AppServices
{
    public class MobiliarioAppService: IMobiliarioAppService
    {
        private readonly MyContext _context;

        public MobiliarioAppService(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<MobiliarioDTO> GetAll()
        {
            var estadoCliente = _context.Mobiliario.Where(x => x.Estado == Constantes.Activo);
            var estadoClienteDTO = MobiliarioDTO.DeModeloADTO(estadoCliente);
            return estadoClienteDTO;
        }

        public async Task<Response> GetById(long id)
        {
            var mobiliario = await _context.Mobiliario.FirstOrDefaultAsync(r => r.Id == id);
            if (mobiliario == null)
            {
                return new Response { Mensaje = "Este mobiliario no existe" };
            }
            var data = MobiliarioDTO.DeModeloADTO(mobiliario);
            return new Response { Datos = data };
        }

        public async Task<Response> Post(MobiliarioDTO mobiliarioDTO)
        {

            var SavedUser = await _context.Mobiliario.FirstOrDefaultAsync(r => r.Descripcion == mobiliarioDTO.Descripcion);
            if (SavedUser != null)
            {
                return new Response { Mensaje = $"Este mobiliario: {mobiliarioDTO.Descripcion} ya existe en el sistema" };
            }
            var mobiliario = MobiliarioDTO.DeDTOAModelo(mobiliarioDTO);
            _context.Mobiliario.Add(mobiliario);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Mobiliario {mobiliarioDTO.Descripcion} agregada exitosamente" };
        }

        public async Task<Response> Put(MobiliarioDTO mobiliarioDTO)
        {
            var mobiliario = MobiliarioDTO.DeDTOAModelo(mobiliarioDTO);
            _context.Entry(mobiliario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"El mobiliario {mobiliarioDTO.Descripcion} se modifico correctamente" };
        }

        public async Task<Response> Delete(int id)
        {
            var mobiliario = await _context.Mobiliario.FindAsync(id);
            if (mobiliario == null)
            {
                return new Response { Mensaje = $"No tenemos un mobiliario con esta id" }; ;
            }
            mobiliario.Estado = Constantes.Inactivo;
            _context.Entry(mobiliario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"El mobiliario {mobiliario.Descripcion} fue eliminada correctamente" };
        }
    }
}
