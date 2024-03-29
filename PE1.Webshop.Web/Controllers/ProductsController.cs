using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Models;
using PE1.Webshop.Web.ViewModels;
using System.Reflection;

namespace PE1.Webshop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly CoffeeShopContext _coffeeShopContext;

        public ProductsController(CoffeeShopContext coffeeShopContext)
        {
            _coffeeShopContext = coffeeShopContext;
        }

        public IActionResult AllCoffees()
        {
            ViewBag.PageTitle = "All Coffees";

            var coffees = _coffeeShopContext.Coffees
                .Select(coffee => new ProductsCoffeeDetailsViewModel
                {
                    Id = coffee.Id,
                    Name = coffee.Name,
                    Description = coffee.Description,
                    Origin = coffee.Origin,
                    Price = coffee.Price,
                    Category = coffee.Category,
                    Properties = coffee.Properties,
                    ImageString = coffee.ImageString,
                    CertifiedOrganic = coffee.CertifiedOrganic
                });

            var allCoffeesModel = new ProductsAllCoffeesViewModel
            {
                AllCoffees = coffees.ToList()
            };

            return View(allCoffeesModel);
        }

        public IActionResult CoffeeDetails(int id)
        {

            var coffees = _coffeeShopContext.Coffees
                .Include(c => c.Category)
                .Include(c => c.Properties);

            if (coffees == null)
            {
                return View("Error", new ErrorViewModel());
            }

            Coffee coffee = coffees.FirstOrDefault(coffee => coffee.Id == id);

            var coffeeDetailsViewModel = new ProductsCoffeeDetailsViewModel
            {
                Id = coffee?.Id,
                Name = coffee?.Name,
                Description = coffee?.Description,
                Origin = coffee?.Origin,
                Price = coffee?.Price,
                Category = coffee.Category,
                Properties = coffee?.Properties,
                ImageString = coffee?.ImageString,
                CertifiedOrganic = coffee.CertifiedOrganic
            };
            return View(coffeeDetailsViewModel);
        }

        public IActionResult FilteredByCategory(int id)
        {

            var coffees = _coffeeShopContext.Coffees
                .Where(c => c.CategoryId == id)
                .Select(coffee => new ProductsCoffeeDetailsViewModel
                {
                    Id = coffee.Id,
                    Name = coffee.Name,
                    Description = coffee.Description,
                    Origin = coffee.Origin,
                    Price = coffee.Price,
                    Category = coffee.Category,
                    Properties = coffee.Properties,
                    ImageString = coffee.ImageString,
                    CertifiedOrganic = coffee.CertifiedOrganic
                });


            var allCoffeesByCategoryModel = new ProductsAllCoffeesViewModel
            {
                AllCoffees = coffees.ToList()
            };

            string selectedCategoryName = allCoffeesByCategoryModel.AllCoffees
                .Select(c => c.Category.Name)
                .First();

            ViewBag.PageTitle = $"{selectedCategoryName} Coffees";

            return View(allCoffeesByCategoryModel);

        }

        public IActionResult FilteredByProperty(int id)
        {

            var coffees = _coffeeShopContext.Coffees
                .Where(c => c.Properties.Any(p => p.Id == id))
                .Select(coffee => new ProductsCoffeeDetailsViewModel
                {
                    Id = coffee.Id,
                    Name = coffee.Name,
                    Description = coffee.Description,
                    Origin = coffee.Origin,
                    Price = coffee.Price,
                    Category = coffee.Category,
                    Properties = coffee.Properties,
                    ImageString = coffee.ImageString,
                    CertifiedOrganic = coffee.CertifiedOrganic
                });

            var allCoffeesByPropertyModel = new ProductsAllCoffeesViewModel
            {
                AllCoffees = coffees.ToList()
            };

            string selectedPropertyName = _coffeeShopContext.Properties
                .Where(p => p.Id == id)
                .Select(p => p.Name)
                .First();

            ViewBag.PageTitle = $"{selectedPropertyName} flavored Coffees";

            return View(allCoffeesByPropertyModel);
        }

    }
}
