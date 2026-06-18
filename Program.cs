using EduClick.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using EduClick.Services;

var builder = WebApplication.CreateBuilder(args);

// =====================
// SERVICES
// =====================

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<UsuarioService>();

builder.Services.AddDbContext<EduClickContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// SESIONES
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

// AUTENTICACIÓN
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options =>
{
    options.LoginPath = "/Usuario/Login";
    options.AccessDeniedPath = "/Home/AccesoDenegado";
});

// =====================
// BUILD APP
// =====================

var app = builder.Build();

// =====================
// PIPELINE
// =====================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// SESIONES (ANTES DE AUTHORIZATION)
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();