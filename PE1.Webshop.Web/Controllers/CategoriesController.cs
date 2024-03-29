using Microsoft.AspNetCore.Mvc;
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

        public IActionResult AllCategories()
        {
            ViewBag.PageTitle = "Categories";

            var categories = _coffeeShopContext.Categories;

            var allCategoriesViewModel = new CategoriesAllCategoriesViewModel();

            allCategoriesViewModel.AllCategories = categories
                .Select(category => new CategoriesCategoryDetailsViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    ImageString = category.ImageString
                });

            return View(allCategoriesViewModel);
        }
    }
}
