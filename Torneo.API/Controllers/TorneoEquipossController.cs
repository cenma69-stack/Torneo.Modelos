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
    public class TorneoEquipossController : ControllerBase
    {
        private readonly TorneoAPIContext _context;

        public TorneoEquipossController(TorneoAPIContext context)
        {
            _context = context;
        }

        // GET: api/TorneoEquiposs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TorneoEquipo>>> GetTorneoEquipo()
        {
            return await _context.TorneoEquipo.ToListAsync();
        }

        // GET: api/TorneoEquiposs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TorneoEquipo>> GetTorneoEquipo(int id)
        {
            var torneoEquipo = await _context.TorneoEquipo.FindAsync(id);

            if (torneoEquipo == null)
            {
                return NotFound();
            }

            return torneoEquipo;
        }

        // PUT: api/TorneoEquiposs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTorneoEquipo(int id, TorneoEquipo torneoEquipo)
        {
            if (id != torneoEquipo.TorneoId)
            {
                return BadRequest();
            }

            _context.Entry(torneoEquipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TorneoEquipoExists(id))
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

        // POST: api/TorneoEquiposs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TorneoEquipo>> PostTorneoEquipo(TorneoEquipo torneoEquipo)
        {
            _context.TorneoEquipo.Add(torneoEquipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTorneoEquipo", new { id = torneoEquipo.TorneoId }, torneoEquipo);
        }

        // DELETE: api/TorneoEquiposs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTorneoEquipo(int id)
        {
            var torneoEquipo = await _context.TorneoEquipo.FindAsync(id);
            if (torneoEquipo == null)
            {
                return NotFound();
            }

            _context.TorneoEquipo.Remove(torneoEquipo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TorneoEquipoExists(int id)
        {
            return _context.TorneoEquipo.Any(e => e.TorneoId == id);
        }
    }
}
