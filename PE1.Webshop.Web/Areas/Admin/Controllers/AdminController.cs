using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using NuGet.Versioning;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Areas.Admin.ViewModels;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Services;
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

			if (ModelState.IsValid)
			{
				Coffee newCoffee = new Coffee
				{
					Name = createProductModel.Name,
					Description = createProductModel.Description,
					Origin = createProductModel.Origin,
					Price = decimal.Parse(createProductModel.PriceInput),
					CertifiedOrganic = createProductModel.CertifiedOrganic,
					Category = _coffeeShopContext.Categories.FirstOrDefault(c => c.Id == createProductModel.SelectedCategoryId),
					Properties = _coffeeShopContext.Properties.Where(p => createProductModel.SelectedPropertyIdList.Contains(p.Id)).ToList(),
					ImageString = $"~/images/{createProductModel.ImageFile.FileName}"
				};

				ImageCreator.CreateImageFile(createProductModel.ImageFile);

				_coffeeShopContext.Coffees.Add(newCoffee);
				_coffeeShopContext.SaveChanges();
				return RedirectToAction("Index");
			}
			else

			createProductModel.CategoryOptions = GetCategories();
			createProductModel.PropertyOptions = GetProperties();


				return View(createProductModel);
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var editProduct = _coffeeShopContext.Coffees
			   .Include(c => c.Category)
			   .Include(c => c.Properties).FirstOrDefault(c => c.Id == id);

			var editProductModel = new AdminEditProductViewModel
			{
				Id = id,
				Name = editProduct.Name,
				Description = editProduct.Description,
				Origin = editProduct.Origin,
				Price = (decimal)editProduct.Price,
				PriceInput = editProduct.Price.ToString(),
				CertifiedOrganic = editProduct.CertifiedOrganic,
				ImageString = editProduct.ImageString,
				CategoryOptions = GetCategories(),
				PropertyOptions = GetProperties(),
				SelectedCategoryId = editProduct.CategoryId,
				SelectedPropertyIdList = editProduct.Properties.Select(p => p.Id).ToList()
			};

			return View(editProductModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(AdminEditProductViewModel editProductModel)
		{

			var editProduct = _coffeeShopContext.Coffees
			   .Include(c => c.Category)
			   .Include(c => c.Properties).FirstOrDefault(c => c.Id == editProductModel.Id);

			if (ModelState.IsValid)
			{

				editProduct.Name = editProductModel.Name;
				editProduct.Description = editProductModel.Description;
				editProduct.Origin = editProductModel.Origin;
				editProduct.Price = decimal.Parse(editProductModel.PriceInput);

				if (editProductModel.ImageFile != null)
				{
					ImageCreator.CreateImageFile(editProductModel.ImageFile);
					editProduct.ImageString = $"~/images/{editProductModel.ImageFile.FileName}";
				}

				
				editProduct.CertifiedOrganic = editProductModel.CertifiedOrganic;
				editProduct.Category = _coffeeShopContext.Categories.FirstOrDefault(c => c.Id == editProductModel.SelectedCategoryId);
				editProduct.Properties = _coffeeShopContext.Properties.Where(p => editProductModel.SelectedPropertyIdList.Contains(p.Id)).ToList();

				_coffeeShopContext.SaveChanges();

				return RedirectToAction("Index");
			}
			else
			{

				editProductModel.CategoryOptions = GetCategories();
				editProductModel.PropertyOptions = GetProperties();

				return View(editProductModel);
			}
			
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

			var matchingImageCheck = _coffeeShopContext.Coffees.Where(c => c.ImageString == deleteProduct.ImageString);
			
			if (matchingImageCheck.Count() == 1)
			{
				string imagePath = deleteProduct.ImageString.Replace("~/images/", "");
				string path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/images", imagePath);
				if (System.IO.File.Exists(path))
				{
					System.IO.File.Delete(path);
				}
			}

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
