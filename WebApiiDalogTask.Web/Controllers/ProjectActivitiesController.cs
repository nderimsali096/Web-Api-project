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
    public class ProjectActivitiesController : ControllerBase
    {
        private readonly DalogDbContext _context;

        public ProjectActivitiesController(DalogDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjectActivities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectActivity>>> GetProjectActivities()
        {
            return await _context.ProjectActivities.ToListAsync();
        }

        // GET: api/ProjectActivities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectActivity>> GetProjectActivity(int id)
        {
            var projectActivity = await _context.ProjectActivities.FindAsync(id);

            if (projectActivity == null)
            {
                return NotFound();
            }

            return projectActivity;
        }

        // PUT: api/ProjectActivities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectActivity(int id, ProjectActivity projectActivity)
        {
            if (id != projectActivity.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectActivity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectActivityExists(id))
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

        // POST: api/ProjectActivities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectActivity>> PostProjectActivity(ProjectActivity projectActivity)
        {
            _context.ProjectActivities.Add(projectActivity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectActivity", new { id = projectActivity.Id }, projectActivity);
        }

        // DELETE: api/ProjectActivities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectActivity(int id)
        {
            var projectActivity = await _context.ProjectActivities.FindAsync(id);
            if (projectActivity == null)
            {
                return NotFound();
            }

            _context.ProjectActivities.Remove(projectActivity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectActivityExists(int id)
        {
            return _context.ProjectActivities.Any(e => e.Id == id);
        }
    }
}
