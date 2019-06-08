using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleWebAPIApp.Areas.Identity.Models;

namespace SimpleWebAPIApp.Areas.Identity
{
  public class IdentityContext: IdentityDbContext<ApiAuthUser>
  {
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }
  }
}
