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
    public class EstadoClienteAppService: IEstadoClienteAppService
    {
        private readonly MyContext _context;

        public EstadoClienteAppService(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<EstadoClienteDTO> GetAll()
        {
            var estadoCliente = _context.EstadoCliente.Where(x => x.Estado == Constantes.Activo);
            var estadoClienteDTO = EstadoClienteDTO.DeModeloADTO(estadoCliente);
            return estadoClienteDTO;
        }

        public async Task<Response> GetById(long id)
        {
            var estadoCliente = await _context.EstadoCliente.FirstOrDefaultAsync(r => r.Id == id);
            if (estadoCliente == null)
            {
                return new Response { Mensaje = "Este estado no existe" };
            }
            var data = EstadoClienteDTO.DeModeloADTO(estadoCliente);
            return new Response { Datos = data };
        }

        public async Task<Response> PostEstadoCliente(EstadoClienteDTO estadoClienteDTO)
        {

            var SavedUser = await _context.EstadoCliente.FirstOrDefaultAsync(r => r.Descripcion == estadoClienteDTO.Descripcion);
            if (SavedUser != null)
            {
                return new Response { Mensaje = $"Esta estado: {estadoClienteDTO.Descripcion} ya existe en el sistema" };
            }
            var estadoCliente = EstadoClienteDTO.DeDTOAModelo(estadoClienteDTO);
            _context.EstadoCliente.Add(estadoCliente);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Estado {estadoClienteDTO.Descripcion} agregada exitosamente" };
        }

        public async Task<Response> PutEstadoCliente(EstadoClienteDTO estadoClienteDTO)
        {
            var estadoCliente = EstadoClienteDTO.DeDTOAModelo(estadoClienteDTO);
            _context.Entry(estadoCliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"La categoria {estadoClienteDTO.Descripcion} se modifico correctamente" };
        }

        public async Task<Response> DeleteEstadoCliente(int id)
        {
            var estadoCliente = await _context.EstadoCliente.FindAsync(id);
            if (estadoCliente == null)
            {
                return new Response { Mensaje = $"No tenemos un estado con esta id" }; ;
            }
            estadoCliente.Estado = Constantes.Inactivo;
            _context.Entry(estadoCliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"El estado {estadoCliente.Descripcion} fue eliminada correctamente" };
        }
    }
}
