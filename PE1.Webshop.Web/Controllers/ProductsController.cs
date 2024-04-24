using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Models;
using PE1.Webshop.Web.Services.Interfaces;
using PE1.Webshop.Web.ViewModels;
using System.Reflection;

namespace PE1.Webshop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly CoffeeShopContext _coffeeShopContext;
        private IProductBuilder _productBuilder;

		public ProductsController(CoffeeShopContext coffeeShopContext, IProductBuilder productBuilder)
		{
			_coffeeShopContext = coffeeShopContext;
			_productBuilder = productBuilder;
		}

		public async Task<IActionResult> AllCoffees()
        {
            ViewBag.PageTitle = "All Coffees";

            var coffees = await _productBuilder.GetCoffees();



				//await _coffeeShopContext.Coffees
				//.Select(coffee => new ProductsCoffeeDetailsViewModel
				//{
				//    Id = coffee.Id,
				//    Name = coffee.Name,
				//    Description = coffee.Description,
				//    Origin = coffee.Origin,
				//    Price = coffee.Price,
				//    Category = coffee.Category,
				//    Properties = coffee.Properties,
				//    ImageString = coffee.ImageString,
				//    CertifiedOrganic = coffee.CertifiedOrganic
				//}).ToListAsync();

			var allCoffeesModel = new ProductsAllCoffeesViewModel
            {
                AllCoffees = coffees
            };

            return View(allCoffeesModel);
        }

        public async Task <IActionResult> CoffeeDetails(int id)
        {

			Coffee coffee = await _coffeeShopContext.Coffees
                .Include(c => c.Category)
                .Include(c => c.Properties)
				.FirstOrDefaultAsync(coffee => coffee.Id == id);         

            //Coffee coffee = coffees.FirstOrDefault(coffee => coffee.Id == id);

            if (coffee == null)
            {
                return NotFound();
            }

            var coffeeDetailsViewModel = _productBuilder.CreateProductDetailsViewModel(coffee);
                
            //    new ProductsCoffeeDetailsViewModel
            //{
            //    Id = coffee?.Id,
            //    Name = coffee?.Name,
            //    Description = coffee?.Description,
            //    Origin = coffee?.Origin,
            //    Price = coffee?.Price,
            //    Category = coffee.Category,
            //    Properties = coffee?.Properties,
            //    ImageString = coffee?.ImageString,
            //    CertifiedOrganic = coffee.CertifiedOrganic
            //};
            return View(coffeeDetailsViewModel);
        }

        public async Task<IActionResult> FilteredByCategory(int id)
        {

            var coffees = await _productBuilder.GetCoffeesByCategory(id);
                
                //await _coffeeShopContext.Coffees
                //.Where(c => c.CategoryId == id)
                //.Select(coffee => new ProductsCoffeeDetailsViewModel
                //{
                //    Id = coffee.Id,
                //    Name = coffee.Name,
                //    Description = coffee.Description,
                //    Origin = coffee.Origin,
                //    Price = coffee.Price,
                //    Category = coffee.Category,
                //    Properties = coffee.Properties,
                //    ImageString = coffee.ImageString,
                //    CertifiedOrganic = coffee.CertifiedOrganic
                //}).ToListAsync();


            var allCoffeesByCategoryModel = new ProductsAllCoffeesViewModel
            {
                AllCoffees = coffees
            };

            string selectedCategoryName = allCoffeesByCategoryModel.AllCoffees
                .Select(c => c.Category.Name)
                .First();

            ViewBag.PageTitle = $"{selectedCategoryName} Coffees";

            return View(allCoffeesByCategoryModel);

        }

        public async Task<IActionResult> FilteredByProperty(int id)
        {

            var coffees = await _productBuilder.GetCoffeesByProperty(id);
                
                
                //await _coffeeShopContext.Coffees
                //.Where(c => c.Properties.Any(p => p.Id == id))
                //.Select(coffee => new ProductsCoffeeDetailsViewModel
                //{
                //    Id = coffee.Id,
                //    Name = coffee.Name,
                //    Description = coffee.Description,
                //    Origin = coffee.Origin,
                //    Price = coffee.Price,
                //    Category = coffee.Category,
                //    Properties = coffee.Properties,
                //    ImageString = coffee.ImageString,
                //    CertifiedOrganic = coffee.CertifiedOrganic
                //}).ToListAsync();

            var allCoffeesByPropertyModel = new ProductsAllCoffeesViewModel
            {
                AllCoffees = coffees
            };

            string selectedPropertyName = await _coffeeShopContext.Properties
                .Where(p => p.Id == id)
                .Select(p => p.Name)
                .FirstOrDefaultAsync();

            ViewBag.PageTitle = $"{selectedPropertyName} flavored Coffees";

            return View(allCoffeesByPropertyModel);
        }

    }
}
