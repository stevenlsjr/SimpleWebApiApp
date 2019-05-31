using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleWebAPIApp;
using SimpleWebAPIApp.Areas.Identity.Data;

[assembly: HostingStartup(typeof(SimpleWebAPIApp.Areas.Identity.IdentityHostingStartup))]
namespace SimpleWebAPIApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DefaultDbContext>(options =>
                    options.UseNpgsql(
                        context.Configuration.GetConnectionString("DefaultDb")));

                services.AddDefaultIdentity<AuthUser>()
                    .AddEntityFrameworkStores<DefaultDbContext>();
            });
        }
    }
}