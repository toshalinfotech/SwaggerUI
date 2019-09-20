using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SwaggerUI.Models;

namespace SwaggerUI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v1",
                    Title = "My Swagger Demo",
                    Description = "My Swagger Demo"
                });
                var filePath = Path.Combine(AppContext.BaseDirectory, "swagger_demo.xml");
                if (File.Exists(filePath))
                {
                    c.IncludeXmlComments(filePath, true);
                }
            });

            services.ConfigureSwaggerGen(x =>
            {
                x.EnableAnnotations();
            });

            var connection = @"Data Source={source};Initial Catalog={dbname};uid={uid};pwd={pwd}";
            services.AddDbContext<MyDBContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseReDoc(c =>
            {
                c.SpecUrl = "/swagger/v1/swagger.json";
                c.DocumentTitle = "My Swagger Demo - v1";
                c.RoutePrefix = string.Empty;
                c.ConfigObject = new Swashbuckle.AspNetCore.ReDoc.ConfigObject
                {
                    LazyRendering = true,
                    NoAutoAuth = true,
                };
            });
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
