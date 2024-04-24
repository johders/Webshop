using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CoffeeShopContext _coffeeShopContext;

        public CategoriesController(CoffeeShopContext coffeeShopContext)
        {
            _coffeeShopContext = coffeeShopContext;
        }

        public async Task<IActionResult> AllCategories()
        {
            ViewBag.PageTitle = "Categories";

            //var categories = _coffeeShopContext.Categories;

            var allCategoriesViewModel = new CategoriesAllCategoriesViewModel();

            allCategoriesViewModel.AllCategories = await _coffeeShopContext.Categories
				.Select(category => new CategoriesCategoryDetailsViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    ImageString = category.ImageString
                }).ToListAsync();

            return View(allCategoriesViewModel);
        }
    }
}
