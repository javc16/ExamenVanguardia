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
    public class ReservaDetalleAppService:IReservaDetalleAppService
    {
        private readonly MyContext _context;

        public ReservaDetalleAppService(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<ReservaDetalleDTO> GetAll()
        {
            var reservaDetalle = _context.ReservaDetalle.Where(x => x.Estado == Constantes.Activo);
            var reservaDetalleDTO = ReservaDetalleDTO.DeModeloADTO(reservaDetalle);
            return reservaDetalleDTO;
        }

        public async Task<Response> GetById(long id)
        {
            var reservaDetalle = await _context.ReservaDetalle.FirstOrDefaultAsync(r => r.Id == id);
            if (reservaDetalle == null)
            {
                return new Response { Mensaje = "No hay reservacion con este id" };
            }
            var data = ReservaDetalleDTO.DeModeloADTO(reservaDetalle);
            return new Response { Datos = data };
        }

        public async Task<Response> Post(ReservaDetalleDTO reservaDetalleDTO)
        {

            var SavedUser = await _context.ReservaDetalle.FirstOrDefaultAsync(r => r.IdMobiliario == reservaDetalleDTO.IdMobiliario);
            if (SavedUser != null)
            {
                return new Response { Mensaje = $"Esta mobiliario ya fue reservado: {reservaDetalleDTO.IdMobiliario} en esta reservacion" };
            }

            var reservaDetalle = ReservaDetalleDTO.DeDTOAModelo(reservaDetalleDTO);
            _context.ReservaDetalle.Add(reservaDetalle);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Mobiliarion {reservaDetalleDTO.IdMobiliario} agregada exitosamente a la reservacion" };
        }

        public async Task<Response> Put(ReservaDetalleDTO reservaDetalleDTO)
        {
            var reservaDetalle = ReservaDetalleDTO.DeDTOAModelo(reservaDetalleDTO);
            _context.Entry(reservaDetalle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Mobiliario {reservaDetalleDTO.IdMobiliario} se modifico correctamente" };
        }

        public async Task<Response> Delete(int id)
        {
            var reservaDetalle = await _context.Reserva.FindAsync(id);
            if (reservaDetalle == null)
            {
                return new Response { Mensaje = $"No tenemos ese mobiliario asociado a la reservacion" }; ;
            }
            reservaDetalle.Estado = Constantes.Inactivo;
            _context.Entry(reservaDetalle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Mobiliario  {reservaDetalle.Descripcion} fue eliminado correctamente de la reservacion" };
        }
    }
}
