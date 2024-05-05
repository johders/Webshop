using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Services;
using PE1.Webshop.Web.Services.Interfaces;
using PE1.Webshop.Web.Transformers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => {
    options.ConstraintMap["slugTransform"] = typeof(SlugParameterTransformer);
});

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CoffeeShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeShopDb")));

builder.Services.AddTransient<IProductBuilder, ProductBuilderService>();
builder.Services.AddTransient<ISearchFilter, SearchFilterService>();
builder.Services.AddTransient<IProductManager, InventoryManagerService>();
builder.Services.AddTransient<IEmailSender, EmailSenderService>();
builder.Services.AddTransient<IOrderBuilder, OrderBuilderService>();
builder.Services.AddTransient<IStateHelper, SessionStateService>();


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
    name: "productDetails",
    pattern: "/ProductDetails/{id:int}/{slug:slugTransform}",
    defaults: new { Controller = "Products", Action = "CoffeeDetails" });

app.MapControllerRoute(
    name: "categoryRoutes",
    pattern: "/Category/{id:int}/{slug:slugTransform}",
    defaults: new { Controller = "Products", Action = "FilteredByCategory" });

app.MapControllerRoute(
    name: "propertyRoutes",
    pattern: "/Flavor/{id:int}/{slug:slugTransform}",
    defaults: new { Controller = "Products", Action = "FilteredByProperty" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();