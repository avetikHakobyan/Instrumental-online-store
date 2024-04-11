using avhH60Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using avhH60Store.Data;
using System.Collections.Generic;
using avhH60Common.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<avhH60StoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("avhH60StoreContextConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<avhH60StoreContext>();
builder.Services.AddScoped<IStoreRepository, StoreRestRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

//Source: https://www.infoworld.com/article/3545304/how-to-handle-404-errors-in-aspnet-core-mvc.html#:~:text=Check%20Response.StatusCode%20in%20ASP.NET%20Core%20MVC
app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/Home/NotFoundError";
        await next();
    }
});

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

//using (var scope = app.Services.CreateScope())
//{
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//    if (!roleManager.Roles.Any())
//    {
//        var roles = new List<string>() { "Manager", "Clerk", "Customer" };
//        foreach (var role in roles)
//        {
//            if (!await roleManager.RoleExistsAsync(role))
//                await roleManager.CreateAsync(new IdentityRole(role));
//        }
//    }
//}

app.Run();
