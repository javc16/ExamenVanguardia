using ExamenVanguardia.AppServices.Interfaces;
using ExamenVanguardia.Context;
using ExamenVanguardia.Domain;
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
        private readonly ReservaDomainService _reservaDomainService;
        private readonly IReservaDetalleAppService _reservaDetalleAppService;

        public ReservaAppService(MyContext context, ReservaDomainService reservaDomainService, IReservaDetalleAppService reservaDetalleAppService)
        {
            _context = context;
            _reservaDomainService = reservaDomainService;
            _reservaDetalleAppService = reservaDetalleAppService;
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
            int days = 0;
            var SavedUser = await _context.Reserva.FirstOrDefaultAsync(r => r.Descripcion == reservaDTO.Descripcion);
            if (SavedUser != null)
            {
                return new Response { Mensaje = $"Esta reservacion: {reservaDTO.Descripcion} ya esta en sistema" };
            }
            var alreadyReserved = await _context.Reserva.FirstOrDefaultAsync(r => r.FechaFinal>= reservaDTO.FechaInicial  && r.FechaInicial <= reservaDTO.FechaInicial);
            if (alreadyReserved != null)
            {
                return new Response { Mensaje = $"Este horario ya fue reservado" };
            }

            if (reservaDTO.FechaInicial.DayOfWeek.Equals("Friday") || reservaDTO.FechaInicial.DayOfWeek.Equals("Saturday"))
            {
                days = 2;
            } else if (reservaDTO.FechaInicial.DayOfWeek.Equals("Sunday"))
            {
                days = 3;
            }
            else 
            {
                days = 1;
            }

            if (days==1 &&(reservaDTO.FechaFinal.Hour > 21 || (reservaDTO.FechaInicial.Hour < 8 && reservaDTO.FechaInicial.Minute <=29)) )
            {
                return new Response { Mensaje = $"No se puede reservar en este horario de lunes a jueves" };
            }
            if (days == 2 && (reservaDTO.FechaFinal.Hour > 23 || reservaDTO.FechaInicial.Hour < 15))
            {
                return new Response { Mensaje = $"No se puede reservar en este horario los viernes y los sabados" };
            }
            else if(days==3)
            {
                return new Response { Mensaje = $"No se puede reservar en domingo" };
            }
            var cliente = await _context.Cliente.FirstOrDefaultAsync(r => r.Id == reservaDTO.IdCliente);
            var message = _reservaDomainService.ValidarSiElClienteExiste(cliente);
            if (message != string.Empty)
            {
                return new Response { Mensaje = message };
            }


            var categoriaEvento = await _context.CategoriaEvento.FirstOrDefaultAsync(r => r.Id == reservaDTO.IdCategoriaEvento);
            message = _reservaDomainService.ValidarSiLaCategoriaDelEventoExiste(categoriaEvento);
            if (message != string.Empty)
            {
                return new Response { Mensaje = message };
            }

            message = _reservaDomainService.ValidarQueElClienteTengaMasDe21(cliente);
            if (message != string.Empty)
            {
                return new Response { Mensaje = message };
            }

            message = _reservaDomainService.ValidarEstadoCliente(cliente);
            if (message != string.Empty)
            {
                return new Response { Mensaje = message };
            }
            var reserva = ReservaDTO.DeDTOAModelo(reservaDTO);
            _context.Reserva.Add(reserva);

            if (reservaDTO.detalle != null) 
            {
                foreach (var item in reservaDTO.detalle) 
                {
                    await _reservaDetalleAppService.Post(item);
                }
            }
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
