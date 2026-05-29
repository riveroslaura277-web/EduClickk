using EduClick.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 👉 Aquí agregamos la conexión a SQL Server usando appsettings.json
builder.Services.AddDbContext<ColegioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));


// 👉 Aquí agregamos la conexión a SQL Server
builder.Services.AddDbContext<ColegioContext>(options =>
    options.UseSqlServer("Server=LAPTOP-2IVQ34EB\\SQLEXPRESS;Database=Educlick;Trusted_Connection=True;"));

 master
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); 
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

 master
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