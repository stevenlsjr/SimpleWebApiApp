using Microsoft.EntityFrameworkCore;
using SimpleWebAPIApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleWebAPIApp.Areas.Identity.Models;

namespace SimpleWebAPIApp
{
  public class DefaultDbContext : DbContext
  {

    DbSet<BlogPost> Posts;

    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
    {
      ChangeTracker.LazyLoadingEnabled = false;
    }

    public DbSet<SimpleWebAPIApp.Models.BlogPost> BlogPost { get; set; }
    
  }


}