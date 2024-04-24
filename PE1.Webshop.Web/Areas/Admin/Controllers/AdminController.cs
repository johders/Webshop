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
using System.Data.Common;

namespace PE1.Webshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {

        private readonly CoffeeShopContext _coffeeShopContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminController(CoffeeShopContext coffeeShopContext, IWebHostEnvironment webHostEnvironment)
        {
            _coffeeShopContext = coffeeShopContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {

            var coffees = await _coffeeShopContext.Coffees
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
            }).ToListAsync();

            var allCoffeesModel = new ProductsAllCoffeesViewModel
            {
                AllCoffees = coffees
            };

            return View(allCoffeesModel);

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createProductModel = new AdminCreateProductViewModel
            {
                CategoryOptions = await GetCategories(),
                PropertyOptions = await GetProperties()
            };

            return View(createProductModel);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminCreateProductViewModel createProductModel)
        {

			if (!ModelState.IsValid)
			{
                createProductModel.CategoryOptions = await GetCategories();
                createProductModel.PropertyOptions = await GetProperties();

                return View(createProductModel);
            }

			string newPrice = createProductModel.PriceInput;

			if (createProductModel.PriceInput.Contains("."))
			{
				newPrice = createProductModel.PriceInput.Replace(".", ",");
			}

			Coffee newCoffee = new Coffee
            {
                Name = createProductModel.Name,
                Description = createProductModel.Description,
                Origin = createProductModel.Origin,
                Price = decimal.Parse(newPrice),
                CertifiedOrganic = createProductModel.CertifiedOrganic,
                Category = await _coffeeShopContext.Categories.FirstOrDefaultAsync(c => c.Id == createProductModel.SelectedCategoryId),
                Properties = await _coffeeShopContext.Properties.Where(p => createProductModel.SelectedPropertyIdList.Contains(p.Id)).ToListAsync()
            };

            if(createProductModel.ImageFile != null)
            {
                newCoffee.ImageString = $"~/images/{SaveImage(createProductModel.ImageFile)}";
            }

            try
			{
                _coffeeShopContext.Coffees.Add(newCoffee);
                await _coffeeShopContext.SaveChangesAsync();
                TempData["success"] = "New product created successfully";
            }
			catch(DbUpdateException ex)
			{
				Console.WriteLine(ex.Message);
			}
           
            
            return RedirectToAction("Index");
        }

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var editProduct = await _coffeeShopContext.Coffees
			   .Include(c => c.Category)
			   .Include(c => c.Properties).FirstOrDefaultAsync(c => c.Id == id);

            if (editProduct == null)
            {
                return NotFound();
            }

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
				CategoryOptions = await GetCategories(),
				PropertyOptions = await GetProperties(),
				SelectedCategoryId = editProduct.CategoryId,
				SelectedPropertyIdList = editProduct.Properties.Select(p => p.Id).ToList()
			};

			return View(editProductModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(AdminEditProductViewModel editProductModel)
		{

			var editProduct = await _coffeeShopContext.Coffees
			   .Include(c => c.Category)
			   .Include(c => c.Properties).FirstOrDefaultAsync(c => c.Id == editProductModel.Id);

            if (editProduct == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
			{
                editProductModel.ImageString = editProduct.ImageString;
                editProductModel.CategoryOptions = await GetCategories();
                editProductModel.PropertyOptions = await GetProperties();

                return View(editProductModel);

            }
		
            editProduct.Name = editProductModel.Name;
            editProduct.Description = editProductModel.Description;
            editProduct.Origin = editProductModel.Origin;

            string newPrice = editProductModel.PriceInput;

			if (editProductModel.PriceInput.Contains("."))
            {
                newPrice = editProductModel.PriceInput.Replace(".", ",");
            }

            editProduct.Price = decimal.Parse(newPrice);

            if (editProductModel.ImageFile != null)
            {
                editProduct.ImageString = $"~/images/{SaveImage(editProductModel.ImageFile)}";
            }

            editProduct.CertifiedOrganic = editProductModel.CertifiedOrganic;
            editProduct.Category = await _coffeeShopContext.Categories.FirstOrDefaultAsync(c => c.Id == editProductModel.SelectedCategoryId);
            editProduct.Properties = await _coffeeShopContext.Properties.Where(p => editProductModel.SelectedPropertyIdList.Contains(p.Id)).ToListAsync();

            try
            {
                await _coffeeShopContext.SaveChangesAsync();
                TempData["success"] = "Product updated successfully";
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Index");
        }

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
            var deleteProduct = await _coffeeShopContext.Coffees
				.Include(c => c.Category)
				.Include(c => c.Properties).FirstOrDefaultAsync(c => c.Id == id);

            if (deleteProduct == null)
            {
                return NotFound();
            }

            var deleteProductViewModel = new AdminDeleteProductViewModel
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
		
			return View(deleteProductViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeletePost(int id)
		{

			var deleteProduct = await _coffeeShopContext.Coffees.FindAsync(id);

            if (deleteProduct == null)
            {
                return NotFound();
            }

            var matchingImageCheck = await _coffeeShopContext.Coffees.Where(c => c.ImageString == deleteProduct.ImageString).ToListAsync();
			
			if (matchingImageCheck.Count() == 1)
			{
				string imagePath = deleteProduct.ImageString.Replace("~/images/", "");
                string path = Path.Combine(_webHostEnvironment.WebRootPath, "images", imagePath);

				if (System.IO.File.Exists(path))
				{
					System.IO.File.Delete(path);
				}
			}

            try
            {
                _coffeeShopContext.Coffees.Remove(deleteProduct);
                await _coffeeShopContext.SaveChangesAsync();
                TempData["success"] = "Product deleted successfully";
            }
			catch(DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }

			return RedirectToAction("Index");
		}


		private async Task<IEnumerable<SelectListItem>> GetCategories()
		{
            return await _coffeeShopContext.Categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
            }).ToListAsync();
		}

		private async Task<IEnumerable<SelectListItem>> GetProperties()
		{
			return await _coffeeShopContext.Properties.Select(c => new SelectListItem
			{
				Value = c.Id.ToString(),
				Text = c.Name,
			}).ToListAsync();
		}

        private string SaveImage(IFormFile image)
        {
            string fileName = image.FileName;
            string savePath = Path.Combine(_webHostEnvironment.WebRootPath, "images");

            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            string saveFilePath = Path.Combine(savePath, fileName);

            using (var newFileStream = new FileStream(saveFilePath, FileMode.Create))
            {
                image.CopyTo(newFileStream);
            }

            return fileName;
        }
    }
}
