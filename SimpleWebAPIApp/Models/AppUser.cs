﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPIApp.Models
{
  public class AppUser
  {
    public int Id { get; set; }

    [Required]
    public string UserName { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }


  }
}
