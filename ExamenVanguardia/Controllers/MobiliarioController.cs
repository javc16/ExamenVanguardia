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
    public class MobiliarioController : ControllerBase
    {
        private readonly IMobiliarioAppService _mobiliarioAppService;

        public MobiliarioController(IMobiliarioAppService mobiliarioAppService)
        {
            _mobiliarioAppService = mobiliarioAppService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<MobiliarioDTO>> GetAll()
        {
            var result = _mobiliarioAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _mobiliarioAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(MobiliarioDTO item)
        {
            return Ok(await _mobiliarioAppService.Post(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> Put(MobiliarioDTO item)
        {
            return Ok(await _mobiliarioAppService.Put(item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteById(int id)
        {
            return Ok(await _mobiliarioAppService.Delete(id));
        }
    }
}
