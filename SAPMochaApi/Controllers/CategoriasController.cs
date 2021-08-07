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
    public class CategoriasController : ControllerBase
    {
        private readonly sapContext _context;

        public CategoriasController(sapContext context)
        {
            _context = context;
        }

        // GET: api/Categorias
        [HttpGet]
        public IEnumerable<Categorias> GetCategorias()
        {
            return _context.Categorias;
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategorias([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categorias = await _context.Categorias.FindAsync(id);

            if (categorias == null)
            {
                return NotFound();
            }

            return Ok(categorias);
        }

        // PUT: api/Categorias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorias([FromRoute] int id, [FromBody] Categorias categorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categorias.IdCategorias)
            {
                return BadRequest();
            }

            _context.Entry(categorias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriasExists(id))
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

        // POST: api/Categorias
        [HttpPost]
        public async Task<IActionResult> PostCategorias([FromBody] Categorias categorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Categorias.Add(categorias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorias", new { id = categorias.IdCategorias }, categorias);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorias([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categorias = await _context.Categorias.FindAsync(id);
            if (categorias == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categorias);
            await _context.SaveChangesAsync();

            return Ok(categorias);
        }

        private bool CategoriasExists(int id)
        {
            return _context.Categorias.Any(e => e.IdCategorias == id);
        }
    }
}