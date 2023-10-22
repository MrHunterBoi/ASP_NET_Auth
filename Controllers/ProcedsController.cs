using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP_API;
using ASP_API.Models;
using ASP_API.Utils;

namespace ASP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedsController : ControllerBase
    {
        private readonly HospitalDBContext _context;

        public ProcedsController(HospitalDBContext context)
        {
            _context = context;
        }

        // GET: api/Proceds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcedFull>>> GetProced()
        {
          if (_context.Proced == null)
          {
              return NotFound();
          }

            var proceds = await _context.Proced.ToListAsync();

            List<ProcedFull> procedFulls = new List<ProcedFull>();

            foreach ( var proced in proceds)
            {
                var equipment = await _context.Equipment.FindAsync(proced.Equipment_ID);
                var medicine = await _context.Medicine.FindAsync(proced.Medicine_ID);
                var patient = await _context.Patient.FindAsync(proced.Patient_ID);
                var staff = await _context.Staff.FindAsync(proced.Staff_ID);

                ProcedFull procedFull = new ProcedFull(proced);
                procedFull.Equipment = equipment;
                procedFull.Medicine = medicine;
                procedFull.Patient = patient;
                procedFull.Staff = staff;

                procedFulls.Add(procedFull);
            }

            return procedFulls;
        }

        // GET: api/Proceds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProcedFull>> GetProced(int id)
        {
          if (_context.Proced == null)
          {
              return NotFound();
          }
            var proced = await _context.Proced.FindAsync(id);

            if (proced == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment.FindAsync(proced.Equipment_ID);
            var medicine = await _context.Medicine.FindAsync(proced.Medicine_ID);
            var patient = await _context.Patient.FindAsync(proced.Patient_ID);
            var staff = await _context.Staff.FindAsync(proced.Staff_ID);

            ProcedFull procedFull = new ProcedFull(proced);
            procedFull.Equipment = equipment;
            procedFull.Medicine = medicine;
            procedFull.Patient = patient;
            procedFull.Staff = staff;

            return procedFull;
        }

        // PUT: api/Proceds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProced(int id, Proced proced)
        {
            if (id != proced.IDproc)
            {
                return BadRequest();
            }

            _context.Entry(proced).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcedExists(id))
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

        // POST: api/Proceds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proced>> PostProced(Proced proced)
        {
          if (_context.Proced == null)
          {
              return Problem("Entity set 'HospitalDBContext.Proced'  is null.");
          }
            _context.Proced.Add(proced);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProced", new { id = proced.IDproc }, proced);
        }

        // DELETE: api/Proceds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProced(int id)
        {
            if (_context.Proced == null)
            {
                return NotFound();
            }
            var proced = await _context.Proced.FindAsync(id);
            if (proced == null)
            {
                return NotFound();
            }

            _context.Proced.Remove(proced);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProcedExists(int id)
        {
            return (_context.Proced?.Any(e => e.IDproc == id)).GetValueOrDefault();
        }
    }
}
