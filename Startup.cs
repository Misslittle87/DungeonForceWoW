using DungeonForceWoW.Data;
using DungeonForceWoW.Services;

namespace DungeonForceWoW
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DungeonForceContext>();
            services.AddControllersWithViews()
                    .AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddTransient<IMailServices, NullMailServices>();
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
