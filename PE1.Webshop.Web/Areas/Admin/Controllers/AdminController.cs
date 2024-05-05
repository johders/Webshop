using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using NuGet.Versioning;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Areas.Admin.ViewModels;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Services;
using PE1.Webshop.Web.Services.Interfaces;
using PE1.Webshop.Web.ViewModels;
using System.Data.Common;

namespace PE1.Webshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly IProductBuilder _productBuilder;
        public AdminController(IProductManager productManager, IProductBuilder productBuilder)
        {
            _productManager = productManager;
            _productBuilder = productBuilder;
        }

        public async Task<IActionResult> Index()
        {

            var coffees = await _productBuilder.GetCoffees();

            var allCoffeesModel = new ProductsAllCoffeesViewModel
            {
                AllCoffees = coffees
            };

            return View(allCoffeesModel);

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createProductModel = new AdminUpdateProductViewModel
            {
                CategoryOptions = await _productManager.GetCategories(),
                PropertyOptions = await _productManager.GetProperties()
            };

            return View(createProductModel);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminUpdateProductViewModel createProductModel)
        {

			if (!ModelState.IsValid)
			{
                createProductModel.CategoryOptions = await _productManager.GetCategories();
                createProductModel.PropertyOptions = await _productManager.GetProperties();

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
                Category = await _productManager.SetCategory(createProductModel),
                Properties = await _productManager.SetProperties(createProductModel)
            };

            if (createProductModel.ImageFile != null)
            {
                string newImageString = _productManager.SaveImage(createProductModel.ImageFile);
				newCoffee.ImageString = $"~/images/{newImageString}";
            }
            else newCoffee.ImageString = $"~/images/placeholder.webp";

            try
			{
                await _productManager.Create(newCoffee);
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
			var editProduct = await _productBuilder.GetCoffeeById(id);

            if (editProduct == null)
            {
                return NotFound();
            }

            var editProductModel = new AdminUpdateProductViewModel
            {
				Id = id,
				Name = editProduct.Name,
				Description = editProduct.Description,
				Origin = editProduct.Origin,
				Price = (decimal)editProduct.Price,
				PriceInput = editProduct.Price.ToString(),
				CertifiedOrganic = editProduct.CertifiedOrganic,
				ImageString = editProduct.ImageString,
				CategoryOptions = await _productManager.GetCategories(),
				PropertyOptions = await _productManager.GetProperties(),
				SelectedCategoryId = editProduct.CategoryId,
				SelectedPropertyIdList = editProduct.Properties.Select(p => p.Id).ToList()
			};

			return View(editProductModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(AdminUpdateProductViewModel editProductModel)
		{

			var editProduct = await _productBuilder.GetCoffeeById((int)editProductModel.Id);

            if (editProduct == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
			{
                editProductModel.ImageString = editProduct.ImageString;
                editProductModel.CategoryOptions = await _productManager.GetCategories();
                editProductModel.PropertyOptions = await _productManager.GetProperties();

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
                if (!editProduct.ImageString.Contains("placeholder"))
                {
				    _productManager.DeleteImage(editProduct);
                }

				string newImageString = _productManager.SaveImage(editProductModel.ImageFile);
				editProduct.ImageString = $"~/images/{newImageString}";
            }

            editProduct.CertifiedOrganic = editProductModel.CertifiedOrganic;
            editProduct.Category = await _productManager.SetCategory(editProductModel);
            editProduct.Properties = await _productManager.SetProperties(editProductModel);

            try
            {
                await _productManager.Update(editProduct);
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
            var deleteProduct = await _productBuilder.GetCoffeeById(id);

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
			var deleteProduct = await _productBuilder.GetCoffeeById(id);

			if (deleteProduct == null)
            {
                return NotFound();
            }

            var matchingImageCheck = await _productManager.FindImageMatch(deleteProduct);

			if (matchingImageCheck.Count() == 1 && !deleteProduct.ImageString.Contains("placeholder"))
			{
                _productManager.DeleteImage(deleteProduct);
			}

            try
            {
                await _productManager.Delete(deleteProduct);
                TempData["success"] = "Product deleted successfully";
            }
			catch(DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }

			return RedirectToAction("Index");
		}

    }
}
