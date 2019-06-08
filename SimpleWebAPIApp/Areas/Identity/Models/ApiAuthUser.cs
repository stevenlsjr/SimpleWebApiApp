using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SimpleWebAPIApp.Models;

namespace SimpleWebAPIApp.Areas.Identity.Models
{
    // Add profile data for application users by adding properties to the ApiAuthUser class
    public class ApiAuthUser : IdentityUser
    {

    }

    class ApiUserResource : IApiUserResource
    {
      public string Id { get; set; }
      public string Username { get; set; }
    }
}
