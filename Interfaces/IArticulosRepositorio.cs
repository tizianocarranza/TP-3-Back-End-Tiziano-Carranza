using System.Collections.Generic;
using System.Threading.Tasks;
using ArticulosAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ArticulosAPI.Interfaces
{
    public interface IArticulosRepositorio
    {
        Task<ActionResult<IEnumerable<ArticulosDto>>> GetAllArticulos();
        Task<ActionResult<ArticulosDto>> GetByIdArticulo(int id);
        Task<ActionResult> PostArticulo(ArticulosDto articuloDto);
        Task<ActionResult> PutArticulo(int id, ArticulosDto articuloDto);
        Task<ActionResult> DeleteArticulo(int id);
        Task<bool> ExisteArticulo(int id);
    }
}
