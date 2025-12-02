using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Torneo.Modelos;

namespace Torneo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorneosController : ControllerBase
    {
        private readonly TorneoAPIContext _context;

        public TorneosController(TorneoAPIContext context)
        {
            _context = context;
        }

        // GET: api/Torneos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Torneo.Modelos.Torneo>>> GetTorneo()
        {
            return await _context.Torneo.ToListAsync();
        }

        // GET: api/Torneos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Torneo.Modelos.Torneo>> GetTorneo(int id)
        {
            var torneo = await _context.Torneo.FindAsync(id);

            if (torneo == null)
            {
                return NotFound();
            }

            return torneo;
        }

        // PUT: api/Torneos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTorneo(int id, Torneo.Modelos.Torneo torneo)
        {
            if (id != torneo.ID)
            {
                return BadRequest();
            }

            _context.Entry(torneo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TorneoExists(id))
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

        // POST: api/Torneos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Torneo.Modelos.Torneo>> PostTorneo(Torneo.Modelos.Torneo torneo)
        {
            _context.Torneo.Add(torneo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTorneo", new { id = torneo.ID }, torneo);
        }

        // DELETE: api/Torneos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTorneo(int id)
        {
            var torneo = await _context.Torneo.FindAsync(id);
            if (torneo == null)
            {
                return NotFound();
            }

            _context.Torneo.Remove(torneo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TorneoExists(int id)
        {
            return _context.Torneo.Any(e => e.ID == id);
        }
    }
}
