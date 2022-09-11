using Fiap.SPraia.UI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("conexao");
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UsuarioContexto>
    (options => options.UseSqlServer
    (connectionString));

builder.Services.AddDbContext<DenunciaContexto>
    (options => options.UseSqlServer
    (connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
