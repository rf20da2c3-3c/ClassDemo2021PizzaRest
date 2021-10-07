using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassDemo2021PizzaRest.managers;
using Microsoft.EntityFrameworkCore;

namespace ClassDemo2021PizzaRest
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClassDemo2021PizzaRest", Version = "v1" });
            });
            // defineret CORS
            services.AddCors(
                builder => builder.AddPolicy("GET-PUT",
                    b => b.AllowAnyHeader().AllowAnyOrigin().WithMethods("GET", "PUT")
                )
            );

            services.AddDbContext<PizzaContext>(opt =>
                opt.UseSqlServer(MySecret.ConnectionStringAzure));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClassDemo2021PizzaRest v1"));
            }

            app.UseRouting();

            app.UseCors("GET-PUT");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
