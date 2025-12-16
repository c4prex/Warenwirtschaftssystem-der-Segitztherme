using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
<<<<<<< HEAD
using Warenwritschaftssystem_der_Segitztherme;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
=======
using Warenwritschaftssystem_der_Segitztherme.Data;

>>>>>>> 91cd7ec984242c172787f87bd78cc06f4ea5c6e7

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WarenwirtschaftContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

<<<<<<< HEAD
// Add Pages

=======
// Datenbank-Migrationen beim Start ausführen
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<WarenwirtschaftContext>();
    context.Database.Migrate();
}
>>>>>>> 91cd7ec984242c172787f87bd78cc06f4ea5c6e7

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
