using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SimpleWebAPIApp.Areas.Identity.Models;

namespace SimpleWebAPIApp.Models
{
  public class BlogUser
  {
    public int Id { get; set; }

    [Required]
    
public string Username { get; set; }

    public DateTime CreationDate { get; set; }

    [MaxLength(255)]
    public string DisplayName { get; set; }

    [MaxLength(255)]
    public string Bio { get; set; }

    /// <summary>
    /// Primary key to an Auth User on the identity db context
    /// </summary>
    public string AuthUserPk { get; set; }
  }
}
