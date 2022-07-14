
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var services = new ServiceCollection();
var connectionString =  builder.Configuration.GetConnectionString("LampshadeDb");
//builder.Services.AddDbContext<DbContext>(options =>
// options.UseSqlServer(builder.Configuration.GetConnectionString("LampshadeDb")));
ShopManagementBoostrapper.Configure(services, connectionString);

builder.Services
    .AddRazorPages();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
   
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();
app.MapDefaultControllerRoute();
app.Run();
