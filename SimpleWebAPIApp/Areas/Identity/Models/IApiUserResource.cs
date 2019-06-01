using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPIApp.Areas.Identity.Models
{
  public interface IApiUserResource
  {
    string Id { get; set; }
    string Username { get; set; }
  }
}
