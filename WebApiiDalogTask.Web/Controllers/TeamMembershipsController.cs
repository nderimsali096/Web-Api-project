using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDalogTask.Data;
using WebApiDalogTask.Data.Models;

namespace WebApiiDalogTask.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMembershipsController : ControllerBase
    {
        private readonly DalogDbContext _context;

        public TeamMembershipsController(DalogDbContext context)
        {
            _context = context;
        }

        // GET: api/TeamMemberships
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMembership>>> GetTeamMemberships()
        {
            return await _context.TeamMemberships.ToListAsync();
        }

        // GET: api/TeamMemberships/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamMembership>> GetTeamMembership(int id)
        {
            var teamMembership = await _context.TeamMemberships.FindAsync(id);

            if (teamMembership == null)
            {
                return NotFound();
            }

            return teamMembership;
        }

        // PUT: api/TeamMemberships/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamMembership(int id, TeamMembership teamMembership)
        {
            if (id != teamMembership.Id)
            {
                return BadRequest();
            }

            _context.Entry(teamMembership).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamMembershipExists(id))
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

        // POST: api/TeamMemberships
        [HttpPost]
        public async Task<ActionResult<TeamMembership>> PostTeamMembership(TeamMembership teamMembership)
        {
            _context.TeamMemberships.Add(teamMembership);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamMembership", new { id = teamMembership.Id }, teamMembership);
        }

        // DELETE: api/TeamMemberships/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMembership(int id)
        {
            var teamMembership = await _context.TeamMemberships.FindAsync(id);
            if (teamMembership == null)
            {
                return NotFound();
            }

            _context.TeamMemberships.Remove(teamMembership);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamMembershipExists(int id)
        {
            return _context.TeamMemberships.Any(e => e.Id == id);
        }
    }
}
