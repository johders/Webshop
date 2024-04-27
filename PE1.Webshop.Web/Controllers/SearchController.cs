using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Models;
using PE1.Webshop.Web.Services.Interfaces;
using PE1.Webshop.Web.ViewModels;
using System.Linq;
using System.Xml.Linq;

namespace PE1.Webshop.Web.Controllers
{
	public class SearchController : Controller
	{
        private readonly ISearchFilter _searchFilter;
        private readonly IProductBuilder _productBuilder;

        public SearchController(ISearchFilter searchFilter , IProductBuilder productBuilder)
        {
            _searchFilter = searchFilter;
            _productBuilder = productBuilder;
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
                coffees = await _searchFilter.FilteredByCategoryAndPrice(priceEntered, category);
            }
            else if (price == 0 && string.IsNullOrEmpty(category))
            {
                coffees = await _searchFilter.FilteredByIsOrganicRegionAndProperty(certOrganic, region, flavor);
            }
            else if (string.IsNullOrEmpty(region))
            {
                var priceEntered = (decimal)price;

                coffees = await _searchFilter.FilteredByCategoryPriceAndProperty(price, category, flavor);
            }
            else
            {
                NotFound();
            }

            searchResultsListView.AllCoffees = coffees
                .Select(coffee => _productBuilder.CreateProductDetailsViewModel(coffee))
                .ToList();

            return View(searchResultsListView);
        }

        public async Task<IActionResult> SearchByKeyWord(string keyword)
        {
            var keywordSearchResultsListView = new SearchByKeywordViewModel();

            var coffees = await _searchFilter.FilteredByKeyword(keyword);

            if (coffees == null)
            {
                return View("Error", new ErrorViewModel());
            }

            keywordSearchResultsListView.AllCoffees = coffees
                .Select(coffee => _productBuilder.CreateProductDetailsViewModel(coffee))
                .ToList();

            return View(keywordSearchResultsListView);
        }
    }
}
