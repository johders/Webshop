using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Areas.Admin.ViewModels;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {

        private readonly CoffeeShopContext _coffeeShopContext;

        public AdminController(CoffeeShopContext coffeeShopContext)
        {
            _coffeeShopContext = coffeeShopContext;
        }

        public IActionResult Index()
        {

            var coffees = _coffeeShopContext.Coffees
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
            });

            var allCoffeesModel = new ProductsAllCoffeesViewModel
            {
                AllCoffees = coffees.ToList()
            };

            return View(allCoffeesModel);

        }

        [HttpGet]
        public IActionResult Create()
        {
            var createProductModel = new AdminCreateProductViewModel
            {
                CategoryOptions = GetCategories(),
                PropertyOptions = GetProperties()
            };

            return View(createProductModel);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
        public IActionResult Create(AdminCreateProductViewModel createProductModel)
        {
            //createProductModel.CategoryOptions = GetCategories();
            //createProductModel.PropertyOptions = GetProperties();

            Coffee newCoffee = new Coffee
            {
                Name = createProductModel.Name,
                Description = createProductModel.Description,
                Origin = createProductModel.Origin,
                Price = (decimal)createProductModel.Price,
                ImageString = "",
                CertifiedOrganic = createProductModel.CertifiedOrganic,
                Category = _coffeeShopContext.Categories.FirstOrDefault(c => c.Id == createProductModel.SelectedCategoryId),
				Properties = _coffeeShopContext.Properties.Where(p => createProductModel.SelectedPropertyIdList.Contains(p.Id)).ToList()
			};


			if (ModelState.IsValid)
            {
				_coffeeShopContext.Coffees.Add(newCoffee);
                _coffeeShopContext.SaveChanges();
			}
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
            var deleteProduct = _coffeeShopContext.Coffees
				.Include(c => c.Category)
				.Include(c => c.Properties).FirstOrDefault(c => c.Id == id);

			var coffeeDetailsViewModel = new AdminDeleteProductViewModel
			{
				Id = deleteProduct?.Id,
				Name = deleteProduct?.Name,
				Description = deleteProduct?.Description,
				Origin = deleteProduct?.Origin,
				Price = deleteProduct?.Price,
				Category = deleteProduct.Category,
				Properties = deleteProduct?.Properties,
				ImageString = deleteProduct?.ImageString,
				CertifiedOrganic = deleteProduct.CertifiedOrganic
			};

			return View(coffeeDetailsViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePost(int id)
		{

			var deleteProduct = _coffeeShopContext.Coffees.Find(id);

				_coffeeShopContext.Coffees.Remove(deleteProduct);
				_coffeeShopContext.SaveChanges();

			return RedirectToAction("Index");
		}


		public IEnumerable<SelectListItem> GetCategories()
		{
            return _coffeeShopContext.Categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
            });
		}

		public IEnumerable<SelectListItem> GetProperties()
		{
			return _coffeeShopContext.Properties.Select(c => new SelectListItem
			{
				Value = c.Id.ToString(),
				Text = c.Name,
			});
		}
	}
}
