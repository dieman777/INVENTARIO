using INVENTARIO.Server.Models;
using INVENTARIO.Server.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace INVENTARIO.Server.Controllers
{
    [ApiController]
    [Route("productos")]
    public class ProductosController : ControllerBase
    {
        public readonly IRepository<Productos> _productosRepository;

        public ProductosController(IRepository<Productos> productosRepository)
        {
            _productosRepository = productosRepository;
        }

        [Authorize]
        [HttpPost(template: "movimiento")]
        public async Task<IActionResult> Insertar([FromBody] Productos profesor)
        {

            if (profesor == null)
            {
                return BadRequest("No hay datos");
            }

            try
            {
                await _productosRepository.Insert(profesor);
                await _productosRepository.SaveChangesAsync();
                return Ok("Inserción correcta");
            }
            catch (Exception exc)
            {
                return StatusCode(500, $"Se ha presentado un error {exc}");
            }
        }

        [Authorize]
        [HttpGet(template: "inventario")]
        public async Task<ActionResult<IEnumerable<Productos>>> Lista()
        {
            IEnumerable<Productos> lista = await _productosRepository.GetAllAsync();

            var lista_filtro = lista
                .Select(p => new Productos
                {
                    empid = p.empid,
                    NOMBRE = p.NOMBRE,
                    CANTIDAD = p.CANTIDAD
                })
                .ToList();

            return Ok(lista_filtro);
        }
    }
}
