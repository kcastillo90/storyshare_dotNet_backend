using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace storyshare_dotNet_backend
{
    public class Startup
    {
        // Constructor: Grabs the configuartion object that allows us to grab vars from appsettings.json
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // Property to receive configuration object
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // The collects all our controllers for routing
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "storyshare_dotNet_backend", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "storyshare_dotNet_backend v1"));
            }

            // Forces site to use https, will need to comment in before pushing to heroku
            // app.UseHttpsRedirection();

            app.UseRouting(); // enables writing

            app.UseAuthorization(); // enables auth

            // function to define all routing
            app.UseEndpoints(endpoints =>
            {
                // Enables attribute routing
                endpoints.MapControllers();
                // Enables Pattern Matching
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{URLParam}");
            });
        }
    }
}
