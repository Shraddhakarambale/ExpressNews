using ExpressNews.Data;
using ExpressNews.Models;
using ExpressNews.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExpressNews
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            var connectionString = builder.Configuration.GetConnectionString("LexiconConnection") ?? throw new InvalidOperationException("Connection string 'LexiconConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();


            builder.Services.AddScoped<IArticleService, ArticleService>();
            builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
            builder.Services.AddTransient<IArticleService, ArticleService>();
            builder.Services.AddSession ();
            //builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(60));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
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
            app.UseSession();

            app.UseAuthorization();
            app.UseSession();//Session
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            using(var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "Editor", "Journalist", "Member" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }

            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager = 
                    scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roles = new[] { "Admin", "Editor", "Journalist", "Member" };

                string email = "admin@admin.com";
                string password = "Test1234,";

                if(await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new User();
                    user.UserName = email;
                    user.Email = email;


                    await userManager.CreateAsync(user, password);
                    userManager.AddToRoleAsync(user, "Admin");
                }
            }

            app.Run();
        }
    }
}
