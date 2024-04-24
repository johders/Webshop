using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly CoffeeShopContext _coffeeShopContext;

        public PropertiesController(CoffeeShopContext coffeeShopContext)
        {
            _coffeeShopContext = coffeeShopContext;
        }
        public async Task<IActionResult> AllProperties()
        {
            ViewBag.PageTitle = "Flavors";

            //var properties = _coffeeShopContext.Properties.OrderBy(p => p.Name);

            var allPropertiesViewModel = new PropertiesAllPropertiesViewModel();

            allPropertiesViewModel.AllProperties = await _coffeeShopContext.Properties
				.Select(property => new PropertiesPropertyDetailsViewModel
            {
                Id = property.Id,
                Name = property.Name
            }).OrderBy(p => p.Name).ToListAsync();

            return View(allPropertiesViewModel);
        }
    }
}
