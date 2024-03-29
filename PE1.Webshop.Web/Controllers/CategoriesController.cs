using Microsoft.AspNetCore.Mvc;
using PE1.Webshop.Core;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Controllers
{
    public class CategoriesController : Controller
    {
     //   private readonly CategoryRepository _categoryRepository;

     //   public CategoriesController()
     //   {
     //       _categoryRepository = new CategoryRepository();
     //   }

     //   public IActionResult AllCategories()
     //   {
     //       ViewBag.PageTitle = "Categories";

     //       IEnumerable<Category> categories = _categoryRepository.Categories;

     //       var allCategoriesViewModel = new CategoriesAllCategoriesViewModel();

     //       allCategoriesViewModel.AllCategories = categories
     //           .Select(category => new CategoriesCategoryDetailsViewModel 
     //           {
     //               Id = category?.Id,
     //               Name = category?.Name,
					//ImageString = category?.ImageString
     //           });

     //       return View(allCategoriesViewModel);
     //   }
    }
}
