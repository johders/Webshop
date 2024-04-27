using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Services.Interfaces;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IProductBuilder _productBuilder;

        public PropertiesController(IProductBuilder productBuilder)
        {
            _productBuilder = productBuilder;
        }
        public async Task<IActionResult> AllProperties()
        {
            ViewBag.PageTitle = "Flavors";

            var allPropertiesViewModel = new PropertiesAllPropertiesViewModel();

            allPropertiesViewModel.AllProperties = await _productBuilder.GetProperties();

            return View(allPropertiesViewModel);
        }
    }
}
