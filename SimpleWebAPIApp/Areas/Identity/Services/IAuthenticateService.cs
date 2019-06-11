using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleWebAPIApp.Areas.Identity.Models;

namespace SimpleWebAPIApp.Areas.Identity.Services
{
  public interface IAuthenticateService
  {
    bool IsAuthenticated(TokenRequest request, out string token);
  }
}
