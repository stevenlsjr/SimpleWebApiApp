using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPIApp.Areas.Identity.Models
{
  public class TokenManagement
  {
    public  string Secret { get; set;}
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int AccessExpriation { get; set; }
    public int RefreshExpiration { get; set; }
  }
}
