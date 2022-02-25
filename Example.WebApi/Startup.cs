using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.WebApi.Data;
using Example.WebApi.Interfaces;
using Example.WebApi.Repositories;
using Microsoft.AspNetCore.Cors;

namespace Example.WebApi
{
    [EnableCors]
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

            services.AddDbContext<ProductContex>(opt => {
                opt.UseSqlServer(Configuration.GetConnectionString("Local"));
            });
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddCors(cors =>
            {
                cors.AddPolicy("Example.WebApiPolicy", opt =>
                 {
                     opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                 });
            });

            services.AddControllers().AddNewtonsoftJson(opt=>{
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Example.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Example.WebApi v1"));
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("Example.WebApiPolicy");
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
