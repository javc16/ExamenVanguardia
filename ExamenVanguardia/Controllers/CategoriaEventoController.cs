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
    public class CategoriaEventoController : ControllerBase
    {
        private readonly ICategoriaEventoAppService _categoriaEventoAppService;

        public CategoriaEventoController(ICategoriaEventoAppService categoriaEventoAppService)
        {
            _categoriaEventoAppService = categoriaEventoAppService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<CategoriaEventoDTO>> GetAll()
        {
            var result = _categoriaEventoAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _categoriaEventoAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(CategoriaEventoDTO item)
        {
            return Ok(await _categoriaEventoAppService.PostCategoriaEvento(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> Put(CategoriaEventoDTO item)
        {
            return Ok(await _categoriaEventoAppService.PutCategoriaEvento(item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteById(int id)
        {
            return Ok(await _categoriaEventoAppService.DeleteCategoriaEvento(id));
        }
    }
}
