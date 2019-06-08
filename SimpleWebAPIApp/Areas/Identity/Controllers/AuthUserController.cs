using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleWebAPIApp.Areas.Identity.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        // GET: api/AuthUser
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AuthUser/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AuthUser
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/AuthUser/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
