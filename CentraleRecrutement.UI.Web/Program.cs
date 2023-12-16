using CentraleRecrutement.ApplicationCore.Interfaces;
using CentraleRecrutement.ApplicationCore.Services;
using CentraleRecrutement.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IOffreService, OffreService>();
builder.Services.AddScoped<IServiceEntreprise, ServiceEntreprise>();
builder.Services.AddScoped<IServicePostulant, ServicePostulant>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddDbContext<DbContext,Context>();
builder.Services.AddSingleton<Type>(t=>typeof(GenericRepository<>));

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
    pattern: "{controller=Home}/{action=privacy}/{id?}");

app.Run();
