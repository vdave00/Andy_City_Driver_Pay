using Andy_Driver_PayRate_Rule_API.DTO;
using Andy_Driver_PayRate_Rule_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Andy_Driver_PayRate_Rule_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FleetController : ControllerBase
    {
        private readonly TmwLiveContext _context;

        public FleetController(TmwLiveContext context)
        {
            _context = context;
        }

        // GET: api/FleetCompany
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AndyDriverRateFleetCompany>>> GetFleetCompanies()
        {
            return await _context.AndyDriverRateFleetCompanies.ToListAsync();
        }

        // GET: api/FleetCompany/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AndyDriverRateFleetCompany>> GetFleetCompany(string id)
        {
            var fleetCompany = await _context.AndyDriverRateFleetCompanies.FindAsync(id);

            if (fleetCompany == null)
            {
                return NotFound();
            }

            return fleetCompany;
        }
        // POST: api/FleetCompany
        [HttpPost]
        public async Task<ActionResult<AndyDriverRateFleetCompany>> PostFleetCompany(AndyDriverRateFleetCompany fleetCompany)
        {
            _context.AndyDriverRateFleetCompanies.Add(fleetCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFleetCompany), new { id = fleetCompany.FleetCompanyId }, fleetCompany);
        }
        // PUT: api/FleetCompany/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFleetCompany(string id, AndyDriverRateFleetCompany fleetCompany)
        {
            if (id != fleetCompany.FleetCompanyId)
            {
                return BadRequest();
            }

            _context.Entry(fleetCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FleetCompanyExists(id))
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

        // DELETE: api/FleetCompany/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFleetCompany(string id)
        {
            var fleetCompany = await _context.AndyDriverRateFleetCompanies.FindAsync(id);
            if (fleetCompany == null)
            {
                return NotFound();
            }

            _context.AndyDriverRateFleetCompanies.Remove(fleetCompany);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FleetCompanyExists(string id)
        {
            return _context.AndyDriverRateFleetCompanies.Any(e => e.FleetCompanyId == id);
        }

    }
}
