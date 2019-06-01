using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWebAPIApp.Areas.Identity.Models;

namespace SimpleWebAPIApp.Areas.Identity.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ApiAuthUserController : ControllerBase
  {
    private DefaultDbContext context;

    public ApiAuthUserController(DefaultDbContext context)
    {
      this.context = context;
    }

    // GET: api/ApiAuthUserResource
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApiAuthUserResource>>> Get()
    {
      var users = await (from s in context.Users select s).ToListAsync();
      return users;
    }

    // GET: api/ApiAuthUserResource/5
    [HttpGet("{id}", Name = "Get")]
    public async Task<ActionResult<ApiAuthUserResource>> Get(string id)
    {
      var user = await (from u in context.Users
        where u.Id == id
        select u).FirstAsync();
      if (user == null)
        return NotFound();

      return user;
    }

   
  }
}

