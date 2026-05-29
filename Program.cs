<<<<<<< HEAD
using EduClick.Data;
=======
using EduClick.Models;
>>>>>>> 966d477ba3c7f1b39009b3447dd7a5315fabae56
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

<<<<<<< HEAD
// Controllers + Views
builder.Services.AddControllersWithViews();

// DB Context
builder.Services.AddDbContext<EduClickContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

=======
// 👉 Aquí agregamos la conexión a SQL Server usando appsettings.json
builder.Services.AddDbContext<ColegioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));


// 👉 Aquí agregamos la conexión a SQL Server
builder.Services.AddDbContext<ColegioContext>(options =>
    options.UseSqlServer("Server=LAPTOP-2IVQ34EB\\SQLEXPRESS;Database=Educlick;Trusted_Connection=True;"));

 master
// Add services to the container.
builder.Services.AddControllersWithViews();

>>>>>>> 966d477ba3c7f1b39009b3447dd7a5315fabae56
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
<<<<<<< HEAD
    app.UseExceptionHandler("/Home/Error");
=======
    app.UseExceptionHandler("/Home/Error"); 
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

 master
>>>>>>> 966d477ba3c7f1b39009b3447dd7a5315fabae56
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 🔥 IMPORTANTE (aunque no uses login todavía, déjalo correcto)
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();