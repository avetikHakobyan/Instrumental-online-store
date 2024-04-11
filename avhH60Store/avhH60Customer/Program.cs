using avhH60Common.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using avhH60Customer.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<avhH60CustomerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("avhH60CustomerContextConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<avhH60CustomerContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
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
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
