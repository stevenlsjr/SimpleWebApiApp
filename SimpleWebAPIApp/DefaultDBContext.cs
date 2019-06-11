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
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
    {
      ChangeTracker.LazyLoadingEnabled = false;
    }

    public DbSet<SimpleWebAPIApp.Models.BlogPost> BlogPosts { get; set; }

    public DbSet<SimpleWebAPIApp.Models.BlogUser> BlogUsers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      var user = modelBuilder.Entity<BlogUser>();
      user.Property(u => u.CreationDate).HasDefaultValueSql("now()");
    }
  }
}