using Microsoft.EntityFrameworkCore;
using Hung_Models.Models;

var builder = WebApplication.CreateBuilder(args);

// Dang ky DbContext vao DI container
//builder.Services.AddDbContext<Hung_Models.Models.LapTrinhWebBanHangContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("LapTrinhWebBanHangContext"))
//    );

// Dung PostgreSQL
builder.Services.AddDbContext<pdhDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ServerConnection"))
);


// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
