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
    public class TipoTorneosController : ControllerBase
    {
        private readonly TorneoAPIContext _context;

        public TipoTorneosController(TorneoAPIContext context)
        {
            _context = context;
        }

        // GET: api/TipoTorneos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoTorneo>>> GetTipoTorneo()
        {
            return await _context.TipoTorneo.ToListAsync();
        }

        // GET: api/TipoTorneos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoTorneo>> GetTipoTorneo(int id)
        {
            var tipoTorneo = await _context.TipoTorneo.FindAsync(id);

            if (tipoTorneo == null)
            {
                return NotFound();
            }

            return tipoTorneo;
        }

        // PUT: api/TipoTorneos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoTorneo(int id, TipoTorneo tipoTorneo)
        {
            if (id != tipoTorneo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoTorneo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoTorneoExists(id))
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

        // POST: api/TipoTorneos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoTorneo>> PostTipoTorneo(TipoTorneo tipoTorneo)
        {
            _context.TipoTorneo.Add(tipoTorneo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoTorneo", new { id = tipoTorneo.Id }, tipoTorneo);
        }

        // DELETE: api/TipoTorneos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoTorneo(int id)
        {
            var tipoTorneo = await _context.TipoTorneo.FindAsync(id);
            if (tipoTorneo == null)
            {
                return NotFound();
            }

            _context.TipoTorneo.Remove(tipoTorneo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoTorneoExists(int id)
        {
            return _context.TipoTorneo.Any(e => e.Id == id);
        }
    }
}
