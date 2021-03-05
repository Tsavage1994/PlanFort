using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using PlanFort.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlanFort.Services;
using System.Net.Http.Headers;

namespace PlanFort
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
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;

            }).AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddHttpClient<SeatGeekClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://api.seatgeek.com/2");

            });
            services.AddHttpClient<YelpClient>(httpClient =>
            {
          
                httpClient.BaseAddress = new Uri("https://api.yelp.com/v3/");
                httpClient.DefaultRequestHeaders.Add
                ("Authorization", "Bearer W3vRwSOPMcpBMhoJKscEEDbPuDpTBJI9hZl63oU5sXhCkMGR2OmWN8PFywOLoj0z93DRQjy2Ma4PQDMBbrEGJK_CEhkL9OFj_DqPwiGvs5_2V0R_9OvBYNLS9DxAYHYx");

            });

<<<<<<< HEAD
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
=======
>>>>>>> 2ba33e3a30b13e843dbda8513224aa3e7a9c9fd5
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
