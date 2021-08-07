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
    public class ProductoresController : ControllerBase
    {
        private readonly sapContext _context;

        public ProductoresController(sapContext context)
        {
            _context = context;
        }

        // GET: api/Productores
        [HttpGet]
        public IEnumerable<Productores> GetProductores()
        {
            return _context.Productores;
        }

        // GET: api/Productores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductores([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productores = await _context.Productores.FindAsync(id);

            if (productores == null)
            {
                return NotFound();
            }

            return Ok(productores);
        }

        // PUT: api/Productores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductores([FromRoute] int id, [FromBody] Productores productores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productores.IdProductores)
            {
                return BadRequest();
            }

            _context.Entry(productores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoresExists(id))
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

        // POST: api/Productores
        [HttpPost]
        public async Task<IActionResult> PostProductores([FromBody] Productores productores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Productores.Add(productores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductores", new { id = productores.IdProductores }, productores);
        }

        // DELETE: api/Productores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductores([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productores = await _context.Productores.FindAsync(id);
            if (productores == null)
            {
                return NotFound();
            }

            _context.Productores.Remove(productores);
            await _context.SaveChangesAsync();

            return Ok(productores);
        }

        private bool ProductoresExists(int id)
        {
            return _context.Productores.Any(e => e.IdProductores == id);
        }
    }
}