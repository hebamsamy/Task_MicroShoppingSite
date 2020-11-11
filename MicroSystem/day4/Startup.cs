using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShopping.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MicroShopping.Services;
using Microsoft.AspNetCore.Identity;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using MicroShopping.Services.Interface;

namespace MicroShopping
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddIdentity<IdentityUser, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = true;
                //config.SignIn.RequireConfirmedEmail = true;
            })
              .AddEntityFrameworkStores<DataContext>()
              .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "Identity.Cookie";
                config.LoginPath = "/Account/Login";
            });

            services.AddMailKit(config => config.UseMailKit(Configuration.GetSection("Email").Get<MailKitOptions>()));
            
            services.AddDbContext<DataContext>(optionsBuilder =>
            {
               optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Data"));
            });

            services.AddTransient<IReadable<Order>, OrderService>();
            services.AddTransient<IUpdatable<Order>, OrderService>();
            services.AddTransient<IDeletable, OrderService>();
            services.AddTransient<ISaveChange, OrderService>();

            services.AddTransient<IDeletable, Review_RatingService>();
            services.AddTransient<IUpdatable<Reviews_Ratings>, Review_RatingService>();
            services.AddTransient<IReadable<Reviews_Ratings>, Review_RatingService>();
            services.AddTransient<ISaveChange, Review_RatingService>();
            services.AddTransient<IDeletable, ProductService>();
            services.AddTransient<IUpdatable<Product>, ProductService>();
            services.AddTransient<IReadable<Product>, ProductService>();
            services.AddTransient<ICreatable<Product>, ProductService>();
            services.AddTransient<ISaveChange, ProductService>();

            services.AddControllersWithViews();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("mvcrout", "{Controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
