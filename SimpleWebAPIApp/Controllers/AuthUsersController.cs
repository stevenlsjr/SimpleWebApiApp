using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWebAPIApp.Models;

namespace SimpleWebAPIApp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthUsersController : ControllerBase
  {
    private readonly DefaultDbContext _context;

    public AuthUsersController(DefaultDbContext context)
    {
      _context = context;
    }

    // GET: api/AuthUsers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
      return await _context.AppUsers.ToListAsync();
    }

    // GET: api/AuthUsers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetAuthUser(int id)
    {
      _context.ChangeTracker.LazyLoadingEnabled = false;
      var authUser = await _context.AppUsers.FindAsync(id);
      if (authUser == null) return NotFound();

      return authUser;
    }

    // PUT: api/AuthUsers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAuthUser(int id, AppUser appUser)
    {
      if (id != appUser.Id) return BadRequest();

      _context.Entry(appUser).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AuthUserExists(id))
          return NotFound();
        throw;
      }

      return NoContent();
    }

    // POST: api/AuthUsers
    [HttpPost]
    public async Task<ActionResult<AppUser>> PostAuthUser(AppUser appUser)
    {
      _context.AppUsers.Add(appUser);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetAuthUser", new {id = appUser.Id}, appUser);
    }

    // DELETE: api/AuthUsers/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<AppUser>> DeleteAuthUser(int id)
    {
      var authUser = await _context.AppUsers.FindAsync(id);
      if (authUser == null) return NotFound();

      _context.AppUsers.Remove(authUser);
      await _context.SaveChangesAsync();

      return authUser;
    }

    private bool AuthUserExists(int id)
    {
      return _context.AppUsers.Any(e => e.Id == id);
    }
  }
}