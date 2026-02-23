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
    public class EventosController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public EventosController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Eventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoModel>>> GetEventos()
        {
            return await _context.Eventos.ToListAsync();
        }

        // GET: api/Eventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventoModel>> GetEventoModel(int id)
        {
            var eventoModel = await _context.Eventos.FindAsync(id);

            if (eventoModel == null)
            {
                return NotFound();
            }

            return eventoModel;
        }

        // PUT: api/Eventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventoModel(int id, EventoModel eventoModel)
        {
            if (id != eventoModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoModelExists(id))
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

        // POST: api/Eventos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventoModel>> PostEventoModel(EventoModel eventoModel)
        {
            _context.Eventos.Add(eventoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventoModel", new { id = eventoModel.Id }, eventoModel);
        }

        // DELETE: api/Eventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventoModel(int id)
        {
            var eventoModel = await _context.Eventos.FindAsync(id);
            if (eventoModel == null)
            {
                return NotFound();
            }

            _context.Eventos.Remove(eventoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventoModelExists(int id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}
