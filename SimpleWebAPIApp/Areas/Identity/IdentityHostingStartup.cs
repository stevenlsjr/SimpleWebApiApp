using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SimpleWebAPIApp.Areas.Identity;
using SimpleWebAPIApp.Areas.Identity.Models;
using SimpleWebAPIApp.Areas.Identity.Services;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]

namespace SimpleWebAPIApp.Areas.Identity
{
  public class IdentityHostingStartup : IHostingStartup
  {
    private IConfiguration Configuration;

    public void Configure(IWebHostBuilder builder)
    {
      builder.ConfigureServices((context, services) =>
      {
        Configuration = context.Configuration;
        services.AddDbContext<IdentityContext>(options =>
        {
          options.UseNpgsql(Configuration.GetConnectionString("IdentityDb"));
        });

        services.Configure<TokenManagement>(Configuration.GetSection("tokenManagement"));
        var token = Configuration.GetSection("tokenManagement").Get<TokenManagement>();
        

        services.AddAuthentication(options =>
          {
//            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
          })
          .AddGitHub(githubOptions =>
          {
            githubOptions.ClientId = Configuration["Github:ClientId"];
            githubOptions.ClientSecret = Configuration["Github:ClientSecret"];
          })
          .AddJwtBearer(options =>
          {
            var secret = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret));
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters {
              ValidateIssuerSigningKey = true,
              IssuerSigningKey = secret,
              ValidIssuer = token.Issuer,
              ValidAudience = token.Audience,
              ValidateIssuer = true,
              ValidateAudience = false
            };
          });
        services.AddDefaultIdentity<ApiAuthUser>(o =>
          {
            o.Password.RequireDigit = false;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
          })
          .AddEntityFrameworkStores<IdentityContext>();
        services.AddScoped<IAuthenticateService, AuthUserService>();
      });

      
    }
  }
}