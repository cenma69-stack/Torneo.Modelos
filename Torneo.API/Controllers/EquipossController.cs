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
    public class EquipossController : ControllerBase
    {
        private readonly TorneoAPIContext _context;

        public EquipossController(TorneoAPIContext context)
        {
            _context = context;
        }

        // GET: api/Equiposs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipos>>> GetEquipos()
        {
            return await _context.Equipos.ToListAsync();
        }

        // GET: api/Equiposs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipos>> GetEquipos(int id)
        {
            var equipos = await _context.Equipos.FindAsync(id);

            if (equipos == null)
            {
                return NotFound();
            }

            return equipos;
        }

        // PUT: api/Equiposs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipos(int id, Equipos equipos)
        {
            if (id != equipos.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquiposExists(id))
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

        // POST: api/Equiposs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Equipos>> PostEquipos(Equipos equipos)
        {
            _context.Equipos.Add(equipos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipos", new { id = equipos.Id }, equipos);
        }

        // DELETE: api/Equiposs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipos(int id)
        {
            var equipos = await _context.Equipos.FindAsync(id);
            if (equipos == null)
            {
                return NotFound();
            }

            _context.Equipos.Remove(equipos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquiposExists(int id)
        {
            return _context.Equipos.Any(e => e.Id == id);
        }
    }
}
