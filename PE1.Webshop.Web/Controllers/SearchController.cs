using Microsoft.AspNetCore.Mvc;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Models;
using PE1.Webshop.Web.ViewModels;
using System.Xml.Linq;

namespace PE1.Webshop.Web.Controllers
{
	public class SearchController : Controller
	{
		//private readonly CoffeeRepository _coffeeRepository;

  //      public SearchController()
  //      {
  //          _coffeeRepository = new CoffeeRepository();
  //      }
		
		//public IActionResult Index()
		//{
		//	return View();
		//}

		//public IActionResult SearchByMultipleKeys(decimal price, string category, string flavor, string region, bool certOrganic)
		//{
		//	var searchResultsListView = new SearchByMultipleKeysViewModel();
		//	var coffees = _coffeeRepository.Coffees;

  //          if (coffees == null)
  //          {
  //              return View("Error", new ErrorViewModel());
  //          }

  //          if (string.IsNullOrEmpty(region) && string.IsNullOrEmpty(flavor))
		//	{
		//		var priceEntered = (decimal)price;
		//		coffees = _coffeeRepository.GetCoffeeByCategoryAndPrice(priceEntered, category);
		//	}
		//	else if (price == 0 && string.IsNullOrEmpty(category))
		//	{
		//		coffees = _coffeeRepository.GetCoffeeByRegionAndFlavor(region, flavor, certOrganic);
		//	}
		//	else if (string.IsNullOrEmpty(region))
		//	{
		//		var priceEntered = (decimal)price;
		//		coffees = _coffeeRepository.GetCoffeeByFlavorCategoryAndPrice(flavor, priceEntered, category);
		//	}
		//	else
		//	{
		//		NotFound();
		//	}

		//	searchResultsListView.AllCoffees = coffees.Select(coffee => new ProductsCoffeeDetailsViewModel
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


		//	return View(searchResultsListView);
		//}

		//public IActionResult SearchByKeyWord(string keyword)
		//{
		//	var keywordSearchResultsListView = new SearchByKeywordViewModel();
			
		//	var coffees = _coffeeRepository.GetCoffeeByKeyWord(keyword);

  //          if (coffees == null)
  //          {
  //              return View("Error", new ErrorViewModel());
  //          }

  //          keywordSearchResultsListView.AllCoffees = coffees.Select(coffee => new ProductsCoffeeDetailsViewModel
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

  //          return View(keywordSearchResultsListView);
  //      }
	}
}
