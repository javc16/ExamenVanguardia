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
    public class ClienteAppService:IClienteAppService
    {
        private readonly MyContext _context;
        private readonly ClienteDomainService _clienteAppService;

        public ClienteAppService(MyContext context, ClienteDomainService clienteAppService)
        {
            _context = context;
            _clienteAppService = clienteAppService;
        }

        public IEnumerable<ClienteDTO> GetAll()
        {
            var cliente = _context.Cliente.Where(x => x.Estado == Constantes.Activo);
            var clienteDTO = ClienteDTO.DeModeloADTO(cliente);
            return clienteDTO;
        }

        public async Task<Response> GetById(long id)
        {
            var cliente = await _context.Cliente.FirstOrDefaultAsync(r => r.Id == id);
            if (cliente == null)
            {
                return new Response { Mensaje = "Este cliente no existe" };
            }
            var data = ClienteDTO.DeModeloADTO(cliente);
            return new Response { Datos = data };
        }

        public async Task<Response> Post(ClienteDTO clienteDTO)
        {

            var SavedUser = await _context.Cliente.FirstOrDefaultAsync(r => r.Identidad == clienteDTO.Identidad);
            if (SavedUser != null)
            {
                return new Response { Mensaje = $"Este cliente: {clienteDTO.Identidad} ya existe en el sistema" };
            }
            var estadoCliente = await _context.EstadoCliente.FirstOrDefaultAsync(r => r.Id == clienteDTO.IdEstadoCliente);

            var message = _clienteAppService.ValidarSiElEstadoExiste(estadoCliente);
            if (message != string.Empty)
            {
                return new Response { Mensaje = message };
            }
            message = _clienteAppService.ValidarSiTieneIdentidad(clienteDTO.Identidad);
            if (message != string.Empty) 
            {
                return new Response { Mensaje = message };
            }
            var cliente = ClienteDTO.DeDTOAModelo(clienteDTO, estadoCliente);
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Cliente {clienteDTO.Identidad} agregada exitosamente" };
        }

        public async Task<Response> Put(ClienteDTO clienteDTO)
        {
            var estadoCliente = await _context.EstadoCliente.FirstOrDefaultAsync(r => r.Id == clienteDTO.IdEstadoCliente);
            var cliente = ClienteDTO.DeDTOAModelo(clienteDTO, estadoCliente);
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"El cliente {clienteDTO.Identidad} se modifico correctamente" };
        }

        public async Task<Response> Delete(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return new Response { Mensaje = $"No tenemos un mobiliario con esta id" }; ;
            }
            cliente.Estado = Constantes.Inactivo;
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"El cliente {cliente.Identidad} fue eliminado correctamente" };
        }
    }
}
