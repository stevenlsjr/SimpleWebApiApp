using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace SimpleWebAPIApp
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
        .AddJsonOptions(options =>
        {
          options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info {Title = "Sample Asp.net core api", Version = "v1"});
      });

      services.AddDbContext<DefaultDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("DefaultDb")));
      services.AddAuthentication();
      services.AddAuthentication().AddGitHub(githubOptions =>
      {
        githubOptions.ClientId = Configuration["Github:ClientId"];
        githubOptions.ClientSecret = Configuration["Github:ClientSecret"];
      });
      
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();
      else
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseAuthentication();
      app.UseMvc();
      app.UseSwagger();
      app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple Asp.net core api"); });
    }
  }
}