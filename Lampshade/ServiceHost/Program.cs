using _01_LampshadeQuery.Contracts.Slide;
using _01_LampShadeQuery.Query;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.EntityFrameworkCore;
using ShopMagement.Domain.ProductAgg;
using ShopMagement.Domain.ProductCategoryAgg;
using ShopMagement.Domain.ProductPictureAgg;
using ShopMagement.Domain.SlideAgg;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Infrastructure.EFCore.Repository;
using ShopManagement.Infrastructure.EFCore;
using DiscountManagement.Infrastructure.EFCore;
using DiscountManagement.Infrastructure.EFCore.Repository;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Application.Contract.ColleagueDiscount;

using DiscountManagement.Application;
using InventoryManagement.Infrastructure.EFCore;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.EFCore.Repository;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Application;
using _01_LampshadeQuery.Contracts.Product;
using _01_LampshadeQuery.Contracts.ProductCategory;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

 builder.Services.AddDbContext<ShopManagement.Infrastructure.EFCore.ShopContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("LampshadeDb")));
builder.Services.AddDbContext<DiscountContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("LampshadeDb")));
builder.Services.AddDbContext<InventoryContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("LampshadeDb")));



builder.Services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
builder.Services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

builder.Services.AddTransient<IProductApplication, ProductApplication>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
builder.Services.AddTransient<IProductPictureRepository, ProductPictureRepository>();

builder.Services.AddTransient<ISlideApplication, SlideApplication>();
builder.Services.AddTransient<ISlideRepository, SlideRepository>();

builder.Services.AddTransient<ISlideQuery, SlideQuery>();
builder.Services.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
builder.Services.AddTransient<IProductQuery, ProductQuery>();

builder.Services.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
builder.Services.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();

builder.Services.AddTransient<IColleagueDiscountApplication, ColleagueDiscountApplication>();
builder.Services.AddTransient<IColleagueDiscountRepository, ColleagueDiscountRepository>();

builder.Services.AddTransient<IInventoryApplication, InventoryApplicatin>();
builder.Services.AddTransient<IInventoryRepository, InventoryRepository>();

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
