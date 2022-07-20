using Exam1.BackgroundTasks;
using Exam1.Handler;
using Exam1.Hubs;
using Exam1.Models.DatabaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Exam1
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
            services.AddControllersWithViews();

            services.AddHostedService<DemoBackgroundTask>();
            //Add service
            services.AddScoped<IUserHandler, UserHandler>();
            services.AddScoped<IStockHandler, StockHandler>();

            services.AddAuthentication("AuthCookie")
                .AddCookie("AuthCookie", options =>
                {
                    options.LoginPath = "/Home/Login";
                    options.Cookie.Name = "Cookie.Basic.Auth";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                });

            services.AddDbContext<StockDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("connectdb"));
            });

            //
            services.AddSignalR();
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<StockHub>("/stockHub");
                endpoints.MapHub<WebHub>("/webHub");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
