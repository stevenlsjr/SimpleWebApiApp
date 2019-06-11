using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWebAPIApp;
using SimpleWebAPIApp.Models;

namespace SimpleWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogUsersController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public BlogUsersController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: api/BlogUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogUser>>> GetBlogUser()
        {
            return await _context.BlogUsers.ToListAsync();
        }

        // GET: api/BlogUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogUser>> GetBlogUser(int id)
        {
            var blogUser = await _context.BlogUsers.FindAsync(id);

            if (blogUser == null)
            {
                return NotFound();
            }

            return blogUser;
        }

        // PUT: api/BlogUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogUser(int id, BlogUser blogUser)
        {
            if (id != blogUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(blogUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogUserExists(id))
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

        // POST: api/BlogUsers
        [HttpPost]
        public async Task<ActionResult<BlogUser>> PostBlogUser(BlogUser blogUser)
        {
            _context.BlogUsers.Add(blogUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogUser", new { id = blogUser.Id }, blogUser);
        }

        // DELETE: api/BlogUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BlogUser>> DeleteBlogUser(int id)
        {
            var blogUser = await _context.BlogUsers.FindAsync(id);
            if (blogUser == null)
            {
                return NotFound();
            }

            _context.BlogUsers.Remove(blogUser);
            await _context.SaveChangesAsync();

            return blogUser;
        }

        private bool BlogUserExists(int id)
        {
            return _context.BlogUsers.Any(e => e.Id == id);
        }
    }
}
