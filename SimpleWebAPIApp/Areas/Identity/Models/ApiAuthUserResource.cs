using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SimpleWebAPIApp.Models;

namespace SimpleWebAPIApp.Areas.Identity.Models
{
    // Add profile data for application users by adding properties to the ApiAuthUserResource class
    public class ApiAuthUserResource : IdentityUser
    {

      public BlogPost AuthoredPosts { get; set; }
      public string Username { get; set; }

     


    }

    class ApiUserResource : IApiUserResource
    {
      public string Id { get; set; }
      public string Username { get; set; }
    }
}
