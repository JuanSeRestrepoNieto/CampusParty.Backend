using CampuserosService.Data;
using CampuserosService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampuserosService.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CampuserosController : ControllerBase
  {
    private readonly AppDbContext _context;

    public CampuserosController(AppDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Campusero>>> GetCampuseros()
    {
      return await _context.Campuseros
          .Include(c => c.Ciudad)
          .Include(c => c.Carpa)
          .Include(c => c.Pabellon)
          .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Campusero>> GetCampusero(int id)
    {
      var campusero = await _context.Campuseros
          .Include(c => c.Ciudad)
          .Include(c => c.Carpa)
          .Include(c => c.Pabellon)
          .FirstOrDefaultAsync(c => c.Id == id);

      if (campusero == null)
      {
        return NotFound();
      }

      return campusero;
    }

    [HttpPost]
    public async Task<ActionResult<Campusero>> PostCampusero(Campusero campusero)
    {
      _context.Campuseros.Add(campusero);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetCampusero", new { id = campusero.Id }, campusero);
    }
  }
}