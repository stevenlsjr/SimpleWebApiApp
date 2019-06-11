using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWebAPIApp;
using SimpleWebAPIApp.Models;

namespace SimpleWebAPIApp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BlogPostsController : ControllerBase
  {
    private readonly DefaultDbContext _context;

    public BlogPostsController(DefaultDbContext context)
    {
      _context = context;
    }

    // GET: api/BlogPosts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BlogPost>>> GetBlogPost()
    {
      return await _context.BlogPosts.ToListAsync();
    }

    // GET: api/BlogPosts/5
    [HttpGet("{id}")]
    public async Task<ActionResult<BlogPost>> GetBlogPost(int id)
    {
      var blogPost = await _context.BlogPosts
        .Include(p => p.Author)
        .Where(p => p.Id == id)
        .FirstAsync();

      if (blogPost == null)
      {
        return NotFound();
      }


      return blogPost;
    }

    [HttpGet("{id}/content"),
     ProducesResponseType(200),
     ProducesResponseType(404)]
    public async Task<ActionResult<string>> GetContent(int id)
    {
      var post = await _context.BlogPosts.Where(p => p.Id == id).Select(p => p.Content).FirstAsync();
      if (post == null)
      {
        return NotFound();
      }

      return Ok(Encoding.UTF8.GetString(post));

    }

    [HttpPut("{id}/content"),
     ProducesResponseType(204),
     ProducesResponseType(404),
      ]
    public async Task<ActionResult> SetContent([FromRoute] int id, [FromBody] byte[] content)
    {
      

      var post = await _context.BlogPosts.FindAsync(id);
      if (post == null)
      {
        return NotFound();
      }

      post.Content = content;
      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BlogPostExists(id))
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

    // PUT: api/BlogPosts/5
    [HttpPut("{id}"),
     ProducesResponseType(200),
     ProducesResponseType(400),
     ProducesResponseType(404)]
    public async Task<IActionResult> PutBlogPost(int id, BlogPost blogPost)
    {
      if (id != blogPost.Id)
      {
        return BadRequest();
      }

      _context.Entry(blogPost).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BlogPostExists(id))
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


    // POST: api/BlogPosts
    [HttpPost,
    ProducesResponseType(201)]
    public async Task<ActionResult<BlogPost>> PostBlogPost(BlogPost blogPost)
    {
      _context.BlogPosts.Add(blogPost);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetBlogPost", new {id = blogPost.Id}, blogPost);
    }

    // DELETE: api/BlogPosts/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<BlogPost>> DeleteBlogPost(int id)
    {
      var blogPost = await _context.BlogPosts.FindAsync(id);
      if (blogPost == null)
      {
        return NotFound();
      }

      _context.BlogPosts.Remove(blogPost);
      await _context.SaveChangesAsync();

      return blogPost;
    }

    private bool BlogPostExists(int id)
    {
      return _context.BlogPosts.Any(e => e.Id == id);
    }
  }
}