using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Best_Shop_Doors.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Best_Shop_DoorsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Best_Shop_DoorsContext")));

//builder.Services.AddDbContext<Best_Shop_DoorsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Best_Shop_DoorsContext") ?? throw new InvalidOperationException("Connection string 'Best_Shop_DoorsContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>().AddDefaultTokenProviders().AddRoles<IdentityRole>().AddEntityFrameworkStores<Best_Shop_DoorsContext>().AddEntityFrameworkStores<Best_Shop_DoorsContext>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
