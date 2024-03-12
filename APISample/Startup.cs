using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using APISample.Models;
using System;

namespace APISample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false; //bug fix
            })
            //.AddNewtonsoftJson()
            .AddXmlSerializerFormatters();

            //dependency injection for lose coupling
            //and to make it easy to convert this to DB, Entity Framework, etc..
            services.AddSingleton<ILanguageRepository, MockLanguageRepository>();
            //services.AddTransient<ILanguageRepository, MockLanguageRepository>();
            //services.AddScoped<ILanguageRepository, MockLanguageRepository>();
            services.AddSingleton<IUserRepository, MockUserRepository>();

            //Added for session state
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (true)
            {
                DeveloperExceptionPageOptions developerExceptionPage = new DeveloperExceptionPageOptions { SourceCodeLineCount = 25 };
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("You got to this point because the page doesn't exist.");
            });
        }
    }
}
