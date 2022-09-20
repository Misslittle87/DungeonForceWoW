using DungeonForceWoW.Data;
using DungeonForceWoW.Data.Entities;
using DungeonForceWoW.Services;
using Microsoft.AspNetCore.Identity;

namespace DungeonForceWoW
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<StoreUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            })
                    .AddEntityFrameworkStores<DungeonForceContext>();
            services.AddAuthentication().AddCookie().AddJwtBearer();
            services.AddDbContext<DungeonForceContext>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddTransient<IMailServices, NullMailServices>();
            services.AddTransient<ExempelSeeder>();
            services.AddScoped<IExempelRepository, ExempelRepository>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(cfg =>
            {
                cfg.MapRazorPages();
                cfg.MapControllerRoute("Default,",
                "/{controller}/{action}/{id?}",
                new { controller = "App", action = "Index" });
            });
        }
    }
}
