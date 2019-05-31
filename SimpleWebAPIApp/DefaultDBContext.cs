using Microsoft.EntityFrameworkCore;
using SimpleWebAPIApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SimpleWebAPIApp
{
  public class DefaultDbContext : IdentityDbContext<Areas.Identity.Data.AuthUser>
  {
    public DefaultDbContext(DbContextOptions options) : base(options)
    {
      ChangeTracker.LazyLoadingEnabled = false;
    }

    public DbSet<AppUser> AppUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<AppUser>()
        .HasIndex(row => row.UserName).IsUnique();
      modelBuilder.Entity<AppUser>()
        .HasIndex(row => new {row.FirstName, row.LastName}).IsUnique();
 
    }
  }
}