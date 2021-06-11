using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParkSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationalParkSystem.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class StateParksController : ControllerBase
  {
    private readonly NationalParkSystemContext _db; // database property

    private bool StateParkExists(int id) // helper method for PUT route
    {
      return _db.StateParks.Any(np => np.StateParkId == id);
    }

    public StateParksController(NationalParkSystemContext db) // instantiates the database with class
    {
      _db = db;
    }

    // POST route
    [HttpPost]
    public async Task<ActionResult<StatePark>> Post(StatePark statePark)
    {
      _db.StateParks.Add(statePark);
      await _db.SaveChangesAsync();
      return CreatedAtAction("Post", new { id = statePark.StateParkId }, statePark);
    }

    // GET general route
    // stretch goals to add queries for more complex LatLong, Visits, Climate data; figure out boolean false return
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StatePark>>> Get(string name, string state)
    {
      var query = _db.StateParks.AsQueryable();

      if (name != null)
      {
        query = query.Where(park => park.Name.Contains(name)); // soft .Contains() broadens query result
      }

      if (state != null)
      {
        query = query.Where(park => park.State == state);
      }

      return await query.ToListAsync();
    }

    // GET with id
    [HttpGet("{id}")]
    public async Task<ActionResult<StatePark>> GetStatePark(int id)
    {
      var park = await _db.StateParks.FirstOrDefaultAsync(park => park.StateParkId == id);
      
      if (park == null)
      {
        return NotFound();
      }

      return park;
    }

    // PUT with id
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, StatePark park)
    {
      if (id != park.StateParkId)
      {
        return BadRequest();
      }

      _db.Entry(park).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }

      catch (DbUpdateConcurrencyException)
      {
        if (!StateParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return CreatedAtAction("Put", park); // optimizes PUT response with 200 OK and updated object
    }


    // DELETE with id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStatePark(int id)
    {
      var park = await _db.StateParks.FindAsync(id);

      if (park == null)
      {
        return NotFound();
      }

      _db.StateParks.Remove(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }

  }
}