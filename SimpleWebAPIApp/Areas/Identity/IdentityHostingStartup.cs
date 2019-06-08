using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SimpleWebAPIApp.Areas.Identity;
using SimpleWebAPIApp.Areas.Identity.Models;
using SimpleWebAPIApp.Areas.Identity.Services;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]

namespace SimpleWebAPIApp.Areas.Identity
{
  public class IdentityHostingStartup : IHostingStartup
  {
    public void Configure(IWebHostBuilder builder)
    {
      builder.ConfigureServices((context, services) =>
      {
        services.AddDefaultIdentity<ApiAuthUser>(o =>
          {
            o.Password.RequireDigit = false;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            
          })
          .AddEntityFrameworkStores<IdentityContext>();
        services.AddSingleton<AuthUserService>();
      });
    }
  }
}