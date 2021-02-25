using Biblioteca.Core.DTO;
using Biblioteca.Core.Interfaces;
using Biblioteca.Core.Interfaces.Editorial;
using Biblioteca.Core.Interfaces.Libro;
using Biblioteca.Core.Services;
using Biblioteca.Infraestructure.Data;
using Biblioteca.Infraestructure.Repositories;
using Biblioteca.Infraestructure.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

namespace BibliotecaJorgePoveda
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<BibliotecaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Registering services
            services.AddTransient<IAutorService, AutorService>();
            services.AddTransient<IEditorialService, EditorialService>();
            services.AddTransient<ILibroService, LibroService>();

            //Registering repos
            services.AddTransient<IAutorRepository, AutorRepository>();
            services.AddTransient<IEditorialRepository, EditorialRepository>();
            services.AddTransient<ILibroRepository, LibroRepository>();


            services.AddControllersWithViews()
                .AddFluentValidation(opt =>
                {
                    opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });

            services.AddTransient<IValidator<LibrosDTO>, LibroValidator>();
            services.AddTransient<IValidator<EditorialesDTO>, EditorialValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
