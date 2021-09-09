using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzariaASP.services;
using PizzariaDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaASP
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
            services.AddControllersWithViews(); // remplace "services.AddMvc();" dans dotNet Core 2.0

            // définition 
            services.AddDbContext<PizzariaContext>(
                    option => option.UseSqlServer(Configuration.GetConnectionString("Default")) // La connectionstring ne se met pas ici c'est dans AppSettin
                );
            // Ajouter le service étendu (portée) ICategorieService et spécification du type d'implémentation (CategorieService)
            services.AddScoped<ICategorieService, CategorieService>();
            // Ajouter le service étendu (portée) IPlatService et spécification du type d'implémentation (PlatService)
            services.AddScoped<IPlatService, PlatService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IHashService, HashService>();
            services.AddScoped<IHashService, HashService>();

            services.AddScoped<IMailService>(s => new MailService(Configuration.GetSection("Email").Get<MailConfiguration>()));

            // ajout des cookies et sessions
            services.AddDistributedMemoryCache();

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                });

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
            }
            app.UseStaticFiles();
            app.UseSession();

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
