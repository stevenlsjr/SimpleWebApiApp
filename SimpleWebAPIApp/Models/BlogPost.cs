﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleWebAPIApp.Areas.Identity.Models;

namespace SimpleWebAPIApp.Models
{
  public class BlogPost
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }

    [Column(TypeName = "bytea")] public byte[] Content { get; set; }


    public DateTime Published { get; set; }
    public int AuthorId { get; set; }
    [ForeignKey("AuthorId")] public BlogUser Author { get; set; }
  }
}