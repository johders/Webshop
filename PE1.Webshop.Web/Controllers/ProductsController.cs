using Microsoft.AspNetCore.Mvc;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Models;
using PE1.Webshop.Web.ViewModels;
using System.Reflection;

namespace PE1.Webshop.Web.Controllers
{
    public class ProductsController : Controller
    {
  //      private readonly CoffeeRepository _coffeeRepository;
  //      private readonly PropertyRepository _propertyRepository;
		//private readonly CategoryRepository _categoryRepository;

		//public ProductsController()
  //      {
  //          _coffeeRepository = new CoffeeRepository();
  //          _propertyRepository = new PropertyRepository();
		//	_categoryRepository = new CategoryRepository();

		//}
  //      public IActionResult Index()
  //      {
  //          return View();
  //      }

  //      public IActionResult CoffeeDetails(int id)
  //      {

  //          IEnumerable<Coffee> coffees = _coffeeRepository.Coffees;

  //          if(coffees == null)
  //          {
  //              return View("Error", new ErrorViewModel());
  //          }

  //          Coffee coffee = coffees.FirstOrDefault(coffee => coffee.Id == id);

  //          var coffeeDetailsViewModel = new ProductsCoffeeDetailsViewModel
  //          {
  //              Id = coffee?.Id,
  //              Name = coffee?.Name,
  //              Description = coffee?.Description,
  //              Origin = coffee?.Origin,
  //              Price = coffee?.Price,
  //              Category = coffee?.Category,
  //              Properties = coffee?.Properties,
  //              ImageString = coffee?.ImageString,
  //              CertifiedOrganic = coffee.CertifiedOrganic
  //          };
  //          return View(coffeeDetailsViewModel);
  //      }

  //      public IActionResult AllCoffees()
  //      {
  //          ViewBag.PageTitle = "All Coffees";

  //          IEnumerable<Coffee> coffees = _coffeeRepository.Coffees;

  //          var allCoffeesViewModel = new ProductsAllCoffeesViewModel();

  //          allCoffeesViewModel.AllCoffees = coffees.Select(coffee => new ProductsCoffeeDetailsViewModel
  //          {
  //              Id = coffee?.Id,
  //              Name = coffee?.Name,
  //              Description = coffee?.Description,
  //              Origin = coffee?.Origin,
  //              Price = coffee?.Price,
  //              Category = coffee?.Category,
  //              Properties = coffee?.Properties,
  //              ImageString = coffee?.ImageString,
  //              CertifiedOrganic = coffee.CertifiedOrganic
  //          });

  //          return View(allCoffeesViewModel);
  //      }

  //      public IActionResult FilteredByCategory(int id)
  //      {           
		//	var allCoffeesInCategory = new ProductsAllCoffeesViewModel();
            
  //          var categorySelected = _categoryRepository.GetCategoryById(id);
  //          categorySelected.Coffees = _coffeeRepository.GetCoffeeInCategory(id);

		//	var catString = categorySelected.Coffees.Select(c => c.Category.Name).First();

		//	ViewBag.PageTitle = $"{catString} Coffees";

		//	if (categorySelected.Coffees == null)
		//	{
		//		return View("Error", new ErrorViewModel());
		//	}

		//	allCoffeesInCategory.AllCoffees = categorySelected.Coffees.Select(coffee => new ProductsCoffeeDetailsViewModel
  //          {
  //              Id = coffee?.Id,
  //              Name = coffee?.Name,
  //              Description = coffee?.Description,
  //              Origin = coffee?.Origin,
  //              Price = coffee?.Price,
  //              Category = coffee?.Category,
  //              Properties = coffee?.Properties,
  //              ImageString = coffee?.ImageString,
  //              CertifiedOrganic = coffee.CertifiedOrganic
  //          }).Where(coffee => coffee.Category.Id == id);
        
  //          return View(allCoffeesInCategory);

  //      }

  //      public IActionResult FilteredByProperty(int id)
  //      {
           
		//	var productsFilteredByPropertyViewModel = new ProductsAllCoffeesViewModel();

		//	var property = _propertyRepository.GetPropertyById(id);

  //          property.Coffees = _coffeeRepository.GetCoffeeWithProperty(id);

  //          ViewBag.PageTitle = $"{property.Name} flavored Coffees";

  //          productsFilteredByPropertyViewModel.AllCoffees = property.Coffees.Select(coffee => new ProductsCoffeeDetailsViewModel
		//	{
  //              Id = coffee?.Id,
  //              Name = coffee?.Name,
  //              Description = coffee?.Description,
  //              Origin = coffee?.Origin,
  //              Price = coffee?.Price,
  //              Category = coffee?.Category,
  //              Properties = coffee?.Properties,
  //              ImageString = coffee?.ImageString,
  //              CertifiedOrganic = coffee.CertifiedOrganic
  //          });

		//	return View(productsFilteredByPropertyViewModel);
		//}
    }
}
