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
  // [Authorize]
  public class NationalParksController : ControllerBase
  {
    private readonly NationalParkSystemContext _db; // database property

    private bool NationalParkExists(int id) // helper method for PUT route
    {
      return _db.NationalParks.Any(np => np.NationalParkId == id);
    }

    public NationalParksController(NationalParkSystemContext db) // instantiates the database with class
    {
      _db = db;
    }

    // POST route
    [HttpPost]
    public async Task<ActionResult<NationalPark>> Post(NationalPark nationalPark)
    {
      _db.NationalParks.Add(nationalPark);
      await _db.SaveChangesAsync();
      return CreatedAtAction("Post", new { id = nationalPark.NationalParkId }, nationalPark);
    }

    // GET general route
    // stretch goals to add queries for more complex LatLong, Visits, Climate data; figure out boolean false return
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NationalPark>>> Get(string name, string state)
    {
      var query = _db.NationalParks.AsQueryable();

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
    public async Task<ActionResult<NationalPark>> GetNationalPark(int id)
    {
      var park = await _db.NationalParks.FirstOrDefaultAsync(park => park.NationalParkId == id);
      
      if (park == null)
      {
        return NotFound();
      }

      return park;
    }

    // PUT with id
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, NationalPark park)
    {
      if (id != park.NationalParkId)
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
        if (!NationalParkExists(id))
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
    public async Task<IActionResult> DeleteNationalPark(int id)
    {
      var park = await _db.NationalParks.FindAsync(id);

      if (park == null)
      {
        return NotFound();
      }

      _db.NationalParks.Remove(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }

  }
}