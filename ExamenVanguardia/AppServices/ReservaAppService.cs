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
    public class ReservaAppService:IReservaAppService
    {
        private readonly MyContext _context;

        public ReservaAppService(MyContext context)
        {
            _context = context;           
        }

        public IEnumerable<ReservaDTO> GetAll()
        {
            var reservas = _context.Reserva.Where(x => x.Estado == Constantes.Activo);
            var reservasDTO = ReservaDTO.DeModeloADTO(reservas);
            return reservasDTO;
        }

        public async Task<Response> GetById(long id)
        {
            var reserva= await _context.Reserva.FirstOrDefaultAsync(r => r.Id == id);
            if (reserva == null)
            {
                return new Response { Mensaje = "No hay reservacion con este id" };
            }
            var data = ReservaDTO.DeModeloADTO(reserva);
            return new Response { Datos = data };
        }

        public async Task<Response> Post(ReservaDTO reservaDTO)
        {

            var SavedUser = await _context.Reserva.FirstOrDefaultAsync(r => r.Descripcion == reservaDTO.Descripcion);
            if (SavedUser != null)
            {
                return new Response { Mensaje = $"Esta reservacion: {reservaDTO.Descripcion} ya esta en sistema" };
            }
          
            var reserva = ReservaDTO.DeDTOAModelo(reservaDTO);
            _context.Reserva.Add(reserva);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Reservacion {reservaDTO.Descripcion} agregada exitosamente" };
        }

        public async Task<Response> Put(ReservaDTO reservaDTO)
        {
            var reserva = ReservaDTO.DeDTOAModelo(reservaDTO);
            _context.Entry(reserva).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Reservacion {reservaDTO.Descripcion} se modifico correctamente" };
        }

        public async Task<Response> Delete(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return new Response { Mensaje = $"No tenemos una reservacion con esta id" }; ;
            }
            reserva.Estado = Constantes.Inactivo;
            _context.Entry(reserva).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"La reservacion {reserva.Descripcion} fue eliminado correctamente" };
        }
    }
}
