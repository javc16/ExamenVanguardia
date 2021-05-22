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
    public class ReservaDetalleController : ControllerBase
    {
        private readonly IReservaDetalleAppService _reservaDetalleAppService;

        public ReservaDetalleController(IReservaDetalleAppService reservaDetalleAppService)
        {
            _reservaDetalleAppService = reservaDetalleAppService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ReservaDetalleDTO>> GetAll()
        {
            var result = _reservaDetalleAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _reservaDetalleAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(ReservaDetalleDTO item)
        {
            return Ok(await _reservaDetalleAppService.Post(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> Put(ReservaDetalleDTO item)
        {
            return Ok(await _reservaDetalleAppService.Put(item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteById(int id)
        {
            return Ok(await _reservaDetalleAppService.Delete(id));
        }
    }
}
