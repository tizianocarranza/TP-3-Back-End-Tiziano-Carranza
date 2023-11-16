using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArticulosAPI.Data;
using ArticulosAPI.Modelos;
using ArticulosAPI.Interfaces;
using ArticulosAPI.DTOs;

namespace ArticulosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly IArticulosRepositorio _repositorio;

        public ArticulosController(IArticulosRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: api/Articulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticulosDto>>> GetAllArticulos()
        {
            return await _repositorio.GetAllArticulos();
        }

        // GET: api/Articulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticulosDto>> GetByIdArticulo(int id)
        {
            var articulo = await _repositorio.GetByIdArticulo(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return articulo;
        }

        // PUT: api/Articulos/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutArticulo(int id, ArticulosDto articuloDto)
        {
            var result = await _repositorio.PutArticulo(id, articuloDto);

            if (result is OkObjectResult)
            {
                return NoContent();
            }
            else if (result is NotFoundObjectResult)
            {
                return NotFound();
            }

            return result;
        }

        // POST: api/Articulos
        [HttpPost]
        public async Task<ActionResult<ArticulosDto>> PostArticulo(ArticulosDto articuloDto)
        {
            return await _repositorio.PostArticulo(articuloDto);
        }

        // DELETE: api/Articulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            var articulo = await _repositorio.GetByIdArticulo(id);
            if (articulo == null)
            {
                return NotFound();
            }

            await _repositorio.DeleteArticulo(id);

            return NoContent();
        }

        [HttpGet("ExisteArticulo/{id}")]
        public Task<bool> ExisteArticulo(int id)
        {
            return _repositorio.ExisteArticulo(id);
        }
    }
}
