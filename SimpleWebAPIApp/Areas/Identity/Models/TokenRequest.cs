﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPIApp.Areas.Identity.Models
{
  public class TokenRequest
  { 
    public string Email { get; set; }
    public string Password { get; set; }
  }
}
 