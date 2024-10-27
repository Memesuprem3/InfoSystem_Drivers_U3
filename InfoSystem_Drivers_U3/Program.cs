using InfoSystem_Drivers_U3.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace InfoSystem_Drivers_U3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Load environment setting from appsettings.json
            var environmentSetting = builder.Configuration.GetValue<string>("Environment") ?? "Production";

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionToDB")));

            // Configure authentication with cookies
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Employee/Login";
                    options.AccessDeniedPath = "/Employee/AccessDenied";
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline based on the environment setting
            if (environmentSetting == "Development")
            {
                app.UseDeveloperExceptionPage(); // Show detailed error pages in Development
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Enable authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();

            // Set up the default route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=Login}/{id?}");

            app.Run();
        }
    }
}