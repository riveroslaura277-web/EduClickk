using EduClick.Data;
using Microsoft.AspNetCore.Identity;
using EduClick.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

<<<<<<< HEAD
// 👉 Aquí agregamos la conexión a SQL Server usando appsettings.json
builder.Services.AddDbContext<ColegioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

=======
>>>>>>> c92993177020f95f7f9702566506a31b25470f38
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EduClickContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));
// Configuración de Identity con tu modelo Usuarios


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
<<<<<<< HEAD
    app.UseExceptionHandler("/Home/Error"); 
=======
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
>>>>>>> c92993177020f95f7f9702566506a31b25470f38
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