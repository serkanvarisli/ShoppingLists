using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie("UserAuthentication", options =>
    {
        options.LoginPath = "/Login/Index";
    })
    .AddCookie("AdminAuthentication", options =>
    {
        options.LoginPath = "/Login/Admin";
    });

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Sql"));
});
builder.Services.AddSession(
    a =>
    {
        a.IdleTimeout = TimeSpan.FromMinutes(30);
        a.Cookie.Name = "ShoppingList";
    });
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "admin",
//    pattern: "admin",
//    defaults: new { controller = "Admin", action = "Login" });

//app.MapControllerRoute(
//    name: "adminDefault",
//    pattern: "admin/{action=Panel}",
//    defaults: new { controller = "Admin", action = "Panel" });



app.Run();
