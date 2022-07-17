using Microsoft.EntityFrameworkCore;
using ShopMagement.Domain.ProductCategoryAgg;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Configuration;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



        builder.Services.AddDbContext<ShopManagement.Infrastructure.EFCore.ShopContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("LampshadeDb")));

       builder.Services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
       builder.Services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

builder.Services.AddRazorPages();
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
    