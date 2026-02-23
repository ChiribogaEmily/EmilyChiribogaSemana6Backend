using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmilyChiribogaSemana6Backend.Models;

namespace EmilyChiribogaSemana6Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public FacturasController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Facturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaModel>>> GetFacturas()
        {
            return await _context.Facturas.ToListAsync();
        }

        // GET: api/Facturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaModel>> GetFacturaModel(int id)
        {
            var facturaModel = await _context.Facturas.FindAsync(id);

            if (facturaModel == null)
            {
                return NotFound();
            }

            return facturaModel;
        }

        // PUT: api/Facturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaModel(int id, FacturaModel facturaModel)
        {
            if (id != facturaModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(facturaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaModelExists(id))
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

        // POST: api/Facturas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FacturaModel>> PostFacturaModel(FacturaModel facturaModel)
        {
            _context.Facturas.Add(facturaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacturaModel", new { id = facturaModel.Id }, facturaModel);
        }

        // DELETE: api/Facturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturaModel(int id)
        {
            var facturaModel = await _context.Facturas.FindAsync(id);
            if (facturaModel == null)
            {
                return NotFound();
            }

            _context.Facturas.Remove(facturaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturaModelExists(int id)
        {
            return _context.Facturas.Any(e => e.Id == id);
        }
    }
}
