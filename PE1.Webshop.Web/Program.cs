using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Services;
using PE1.Webshop.Web.Services.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CoffeeShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeShopDb")));

builder.Services.AddTransient<IProductBuilder, ProductBuilderService>();
builder.Services.AddTransient<ISearchFilter, SearchFilterService>();
builder.Services.AddTransient<IProductManager, InventoryManagerService>();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "searchbypricecategoryandflavor",
    pattern: "Search/lessthan{price:decimal}dollars/{category}/{flavor}",
    defaults: new { Controller = "Search", Action = "SearchByMultipleKeys" });

app.MapControllerRoute(
    name: "searchbypriceandcategory",
    pattern: "Search/maximum{price:decimal}dollars/{category}",
    defaults: new { Controller = "Search", Action = "SearchByMultipleKeys" });

app.MapControllerRoute(
    name: "searchbyregionandflavor",
    pattern: "Search/{region}/{flavor}/{certOrganic}",
    defaults: new { Controller = "Search", Action = "SearchByMultipleKeys" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();