using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.World.DAL;
using Marvel.World.Interfaces;
using Marvel.World.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Marvel.World
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

            services.AddHttpClient("heroesService", h =>
            {
                h.BaseAddress = new Uri(Configuration["Services:Heroes"]);
            });

            services.AddHttpClient("villainsService", h =>
            {
                h.BaseAddress = new Uri(Configuration["Services:Villains"]);
            });

            services.AddSingleton<IHeroesServices, HeroesServices>();
            services.AddSingleton<IVillainsServices, VillainsServices>();
            services.AddSingleton<IWarServices, WarServices>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
