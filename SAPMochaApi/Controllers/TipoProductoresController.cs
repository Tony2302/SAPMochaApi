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
    public class TipoProductoresController : ControllerBase
    {
        private readonly sapContext _context;

        public TipoProductoresController(sapContext context)
        {
            _context = context;
        }

        // GET: api/TipoProductores
        [HttpGet]
        public IEnumerable<TipoProductores> GetTipoProductores()
        {
            return _context.TipoProductores;
        }

        // GET: api/TipoProductores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoProductores([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoProductores = await _context.TipoProductores.FindAsync(id);

            if (tipoProductores == null)
            {
                return NotFound();
            }

            return Ok(tipoProductores);
        }

        // PUT: api/TipoProductores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoProductores([FromRoute] int id, [FromBody] TipoProductores tipoProductores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoProductores.IdTipoProductores)
            {
                return BadRequest();
            }

            _context.Entry(tipoProductores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoProductoresExists(id))
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

        // POST: api/TipoProductores
        [HttpPost]
        public async Task<IActionResult> PostTipoProductores([FromBody] TipoProductores tipoProductores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TipoProductores.Add(tipoProductores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoProductores", new { id = tipoProductores.IdTipoProductores }, tipoProductores);
        }

        // DELETE: api/TipoProductores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoProductores([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoProductores = await _context.TipoProductores.FindAsync(id);
            if (tipoProductores == null)
            {
                return NotFound();
            }

            _context.TipoProductores.Remove(tipoProductores);
            await _context.SaveChangesAsync();

            return Ok(tipoProductores);
        }

        private bool TipoProductoresExists(int id)
        {
            return _context.TipoProductores.Any(e => e.IdTipoProductores == id);
        }
    }
}