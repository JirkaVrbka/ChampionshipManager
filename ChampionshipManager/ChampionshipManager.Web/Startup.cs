using ChampionshipManager.BusinessLayer.Services;
using ChampionshipManager.Db.Context;
using ChampionshipManager.Db.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ChampionshipManager.Web.Areas.Identity;
using ChampionshipManager.Web.Data;

namespace ChampionshipManager.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ChampionshipManagerContext>(options =>
                options.UseSqlite("Filename=./manager.db"), ServiceLifetime.Scoped);

            services.AddDefaultIdentity<IdentityUser>(options =>
                {
                    // Lowered security for demonstration
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 1;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services
                .AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>
                >();

            services.AddScoped<OrganizerRepository>();
            services.AddScoped<CompetitorRepository>();
            services.AddScoped<SkillRepository>();
            services.AddScoped<ChampionshipRepository>();
            services.AddScoped<TournamentRepository>();
            services.AddScoped<GameRepository>();
            services.AddScoped<TeamRepository>();

            services.AddScoped<OrganizerService>();
            services.AddScoped<ChampionshipService>();
            services.AddScoped<SkillService>();
            services.AddScoped<CompetitorService>();
            services.AddScoped<TournamentService>();
            services.AddScoped<GameService>();
            services.AddScoped<TeamService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}