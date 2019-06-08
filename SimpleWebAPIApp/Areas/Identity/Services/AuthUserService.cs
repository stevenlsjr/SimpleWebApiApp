using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleWebAPIApp.Areas.Identity.Models;

namespace SimpleWebAPIApp.Areas.Identity.Services
{
  public class AuthUserService
  {
    private DefaultDbContext ctx { get; set; }
    public AuthUserService(DefaultDbContext ctx)
    {
      this.ctx = ctx;
    }




  }
}
