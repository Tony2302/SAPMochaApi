using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAPMochaApi.Models;
using SapMochaApi.Models;

namespace SapMochaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleCategoriasController : ControllerBase
    {
        private readonly sapContext _context;

        public DetalleCategoriasController(sapContext context)
        {
            _context = context;
        }

        // GET: api/DetalleCategorias
        [HttpGet]
        public IEnumerable<DetalleCategorias> GetDetalleCategorias()
        {
            return _context.DetalleCategorias.Include(x=>x.Productos).Include(x=>x.Productores).Include(x=>x.Productos.categorias).Include(x=>x.Productos.categorias.tipoproductores);
        }

        // GET: api/DetalleCategorias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetalleCategorias([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detalleCategorias = await _context.DetalleCategorias.Include(x=>x.Productos).Include(x=>x.Productores).FirstAsync(x=>x.IdDetalleCategorias==id);

            if (detalleCategorias == null)
            {
                return NotFound();
            }

            return Ok(detalleCategorias);
        }

        // PUT: api/DetalleCategorias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleCategorias([FromRoute] int id, [FromBody] DetalleCategorias detalleCategorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detalleCategorias.IdDetalleCategorias)
            {
                return BadRequest();
            }

            _context.Entry(detalleCategorias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleCategoriasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DetalleCategorias
        [HttpPost]
        public async Task<IActionResult> PostDetalleCategorias([FromBody] DetalleCategorias detalleCategorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DetalleCategorias.Add(detalleCategorias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleCategorias", new { id = detalleCategorias.IdDetalleCategorias }, detalleCategorias);
        }

        // DELETE: api/DetalleCategorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleCategorias([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detalleCategorias = await _context.DetalleCategorias.FindAsync(id);
            if (detalleCategorias == null)
            {
                return NotFound();
            }

            _context.DetalleCategorias.Remove(detalleCategorias);
            await _context.SaveChangesAsync();

            return Ok(detalleCategorias);
        }

        private bool DetalleCategoriasExists(int id)
        {
            return _context.DetalleCategorias.Any(e => e.IdDetalleCategorias == id);
        }
    }
}