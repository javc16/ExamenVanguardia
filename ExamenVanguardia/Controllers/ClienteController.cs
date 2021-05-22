using ExamenVanguardia.AppServices.Interfaces;
using ExamenVanguardia.Helpers;
using ExamenVanguardia.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ClienteDTO>> GetAll()
        {
            var result = _clienteAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _clienteAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(ClienteDTO item)
        {
            return Ok(await _clienteAppService.Post(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> Put(ClienteDTO item)
        {
            return Ok(await _clienteAppService.Put(item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteById(int id)
        {
            return Ok(await _clienteAppService.Delete(id));
        }
    }
}
