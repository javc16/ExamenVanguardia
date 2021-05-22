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
    public class EstadoClienteController : ControllerBase
    {
        private readonly IEstadoClienteAppService _estadoClienteAppService;

        public EstadoClienteController(IEstadoClienteAppService estadoClienteAppService)
        {
            _estadoClienteAppService = estadoClienteAppService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<EstadoClienteDTO>> GetAll()
        {
            var result = _estadoClienteAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _estadoClienteAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(EstadoClienteDTO item)
        {
            return Ok(await _estadoClienteAppService.PostEstadoCliente(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> Put(EstadoClienteDTO item)
        {
            return Ok(await _estadoClienteAppService.PutEstadoCliente(item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteById(int id)
        {
            return Ok(await _estadoClienteAppService.DeleteEstadoCliente(id));
        }
    }
}
