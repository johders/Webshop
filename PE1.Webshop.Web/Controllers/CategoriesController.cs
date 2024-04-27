using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Services.Interfaces;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IProductBuilder _productBuilder;
        public CategoriesController(IProductBuilder productBuilder)
        {
            _productBuilder = productBuilder;
        }

        public async Task<IActionResult> AllCategories()
        {
            ViewBag.PageTitle = "Categories";

            var allCategoriesViewModel = new CategoriesAllCategoriesViewModel();

            allCategoriesViewModel.AllCategories = await _productBuilder.GetCategories();

            return View(allCategoriesViewModel);
        }
    }
}
