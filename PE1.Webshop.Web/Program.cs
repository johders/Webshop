var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//SearchByMultipleKeys(decimal price, string category, string flavor, string region)

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

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