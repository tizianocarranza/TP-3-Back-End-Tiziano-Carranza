using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArticulosAPI.Data;
using ArticulosAPI.Interfaces;
using ArticulosAPI.Modelos;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ArticulosAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ArticulosAPI.Interfaces
{
    public class ArticulosRepositorio : IArticulosRepositorio
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ArticulosRepositorio(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<ArticulosDto>>> GetAllArticulos()
        {
            var articulos = await _context.Articulos.ToListAsync();
            return _mapper.Map<List<Articulos>, List<ArticulosDto>>(articulos);
        }

        public async Task<ActionResult<ArticulosDto>> GetByIdArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);

            if (articulo == null)
            {
                return new NotFoundResult();
            }

            return _mapper.Map<Articulos, ArticulosDto>(articulo);
        }

        public async Task<ActionResult> PostArticulo(ArticulosDto articuloDto)
        {
            var nuevoArticulo = _mapper.Map<ArticulosDto, Articulos>(articuloDto);

            _context.Articulos.Add(nuevoArticulo);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<ActionResult> PutArticulo(int id, ArticulosDto articuloDto)
        {
            var articuloActualizar = await _context.Articulos.FindAsync(id);

            if (articuloActualizar != null)
            {
                _mapper.Map(articuloDto, articuloActualizar);

                _context.Entry(articuloActualizar).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                 
                return new OkResult();
            }

            return new NotFoundResult();
        }

        public async Task<ActionResult> DeleteArticulo(int id)
        {
            var articuloEliminar = await _context.Articulos.FindAsync(id);

            try
            {
                if (articuloEliminar != null)
                {
                    _context.Articulos.Remove(articuloEliminar);
                    await _context.SaveChangesAsync();

                    return new OkResult();
                }

                return new NotFoundResult();
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        public async Task<bool> ExisteArticulo(int id) 
        {
            return await _context.Articulos.AnyAsync(articulo => articulo.Id == id);
        }
    }
}
