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
    public class ProjectAreasController : ControllerBase
    {
        private readonly DalogDbContext _context;

        public ProjectAreasController(DalogDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjectAreas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectArea>>> GetProjectAreas()
        {
            return await _context.ProjectAreas.ToListAsync();
        }

        // GET: api/ProjectAreas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectArea>> GetProjectArea(int id)
        {
            var projectArea = await _context.ProjectAreas.FindAsync(id);

            if (projectArea == null)
            {
                return NotFound();
            }

            return projectArea;
        }

        // PUT: api/ProjectAreas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectArea(int id, ProjectArea projectArea)
        {
            if (id != projectArea.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectArea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectAreaExists(id))
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

        // POST: api/ProjectAreas
        [HttpPost]
        public async Task<ActionResult<ProjectArea>> PostProjectArea(ProjectArea projectArea)
        {
            _context.ProjectAreas.Add(projectArea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectArea", new { id = projectArea.Id }, projectArea);
        }

        // DELETE: api/ProjectAreas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectArea(int id)
        {
            var projectArea = await _context.ProjectAreas.FindAsync(id);
            if (projectArea == null)
            {
                return NotFound();
            }

            _context.ProjectAreas.Remove(projectArea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectAreaExists(int id)
        {
            return _context.ProjectAreas.Any(e => e.Id == id);
        }
    }
}
