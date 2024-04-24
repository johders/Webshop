using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Models;
using PE1.Webshop.Web.ViewModels;
using System.Linq;
using System.Xml.Linq;

namespace PE1.Webshop.Web.Controllers
{
	public class SearchController : Controller
	{
        private readonly CoffeeShopContext _coffeeShopContext;

        public SearchController(CoffeeShopContext coffeeShopContext)
        {
            _coffeeShopContext = coffeeShopContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SearchByMultipleKeys(decimal price, string category, string flavor, string region, bool certOrganic)
        {
            var searchResultsListView = new SearchByMultipleKeysViewModel();

            ICollection<Coffee> coffees = new List<Coffee>();
         
            if (string.IsNullOrEmpty(region) && string.IsNullOrEmpty(flavor))
            {
                var priceEntered = (decimal)price;
                coffees = await _coffeeShopContext.Coffees
                    .Include(c => c.Category)
                    .Include(c => c.Properties)
                    .Where(c => c.Category.Name.ToUpper().Contains(category.ToUpper()) && c.Price == priceEntered)
                    .ToListAsync();
            }
            else if (price == 0 && string.IsNullOrEmpty(category))
            {
                coffees = await _coffeeShopContext.Coffees
                    .Include(c => c.Category)
                    .Include(c => c.Properties)
                    .Where(c => c.Origin.ToUpper().Contains(region.ToUpper()) && c.Properties
                    .Any(c => c.Name.ToUpper().Contains(flavor.ToUpper())) && c.CertifiedOrganic == certOrganic)
                    .ToListAsync();
            }
            else if (string.IsNullOrEmpty(region))
            {
                var priceEntered = (decimal)price;
                coffees = await _coffeeShopContext.Coffees
                    .Include(c => c.Category)
                    .Include(c => c.Properties)
                    .Where(s => s.Properties.Any(c => c.Name.ToUpper().Contains(flavor.ToUpper())) && s.Price < price && s.Category.Name.ToUpper()
                    .Contains(category.ToUpper()))
                    .ToListAsync();
            }
            else
            {
                NotFound();
            }

            searchResultsListView.AllCoffees = coffees
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
                }).ToList();

            return View(searchResultsListView);
        }

        public async Task<IActionResult> SearchByKeyWord(string keyword)
        {
            var keywordSearchResultsListView = new SearchByKeywordViewModel();

            var coffees = await _coffeeShopContext.Coffees
                 .Include(c => c.Category)
                 .Include(c => c.Properties)
                 .Where(s => s.Description.ToUpper().Contains(keyword.ToUpper()) || s.Origin.ToUpper().Contains(keyword.ToUpper()) || s.Properties
                 .Any(c => c.Name.ToUpper().Contains(keyword.ToUpper())) ||s.Category.Name.ToUpper().Contains(keyword.ToUpper()) || s.Name.ToUpper()
                 .Contains(keyword.ToUpper())).ToListAsync();

            if (coffees == null)
            {
                return View("Error", new ErrorViewModel());
            }

            keywordSearchResultsListView.AllCoffees = coffees.Select(coffee => new ProductsCoffeeDetailsViewModel
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
            }).ToList();

            return View(keywordSearchResultsListView);
        }
    }
}
