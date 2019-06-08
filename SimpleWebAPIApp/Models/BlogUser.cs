using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPIApp.Models
{
  public class BlogUser
  {
    public int Id { get; set; }

    /// <summary>
    /// Primary key to an Auth User on the identity db context
    /// </summary>
    public string AuthUserPk { get; set; }
  }
}
