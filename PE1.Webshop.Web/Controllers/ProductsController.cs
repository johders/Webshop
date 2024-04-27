using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Models;
using PE1.Webshop.Web.Services;
using PE1.Webshop.Web.Services.Interfaces;
using PE1.Webshop.Web.ViewModels;
using System.Reflection;

namespace PE1.Webshop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductBuilder _productBuilder;

		public ProductsController(IProductBuilder productBuilder)
		{
			_productBuilder = productBuilder;
		}

		public async Task<IActionResult> AllCoffees()
        {
            ViewBag.PageTitle = "All Coffees";

            var coffees = await _productBuilder.GetCoffees();

			var allCoffeesModel = new ProductsAllCoffeesViewModel
            {
                AllCoffees = coffees
            };

            return View(allCoffeesModel);
        }

        public async Task <IActionResult> CoffeeDetails(int id)
        {

            Coffee coffee = await _productBuilder.GetCoffeeById(id);

            if (coffee == null)
            {
                return NotFound();
            }

            var coffeeDetailsViewModel = _productBuilder.CreateProductDetailsViewModel(coffee);
                
            return View(coffeeDetailsViewModel);
        }

        public async Task<IActionResult> FilteredByCategory(int id)
        {

            var coffees = await _productBuilder.GetCoffeesByCategory(id);

            var allCoffeesByCategoryModel = new ProductsAllCoffeesViewModel
            {
                AllCoffees = coffees
            };

            string selectedCategoryName = _productBuilder.GetCategoryName(id, allCoffeesByCategoryModel.AllCoffees);

            ViewBag.PageTitle = $"{selectedCategoryName} Coffees";

            return View(allCoffeesByCategoryModel);

        }

        public async Task<IActionResult> FilteredByProperty(int id)
        {

            var coffees = await _productBuilder.GetCoffeesByProperty(id);             

            var allCoffeesByPropertyModel = new ProductsAllCoffeesViewModel
            {
                AllCoffees = coffees
            };

            string selectedPropertyName = await _productBuilder.GetPropertyName(id);

            ViewBag.PageTitle = $"{selectedPropertyName} flavored Coffees";

            return View(allCoffeesByPropertyModel);
        }

    }
}
