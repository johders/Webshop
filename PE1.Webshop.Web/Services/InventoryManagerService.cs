using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Areas.Admin.ViewModels;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Services.Interfaces;

namespace PE1.Webshop.Web.Services
{
    public class InventoryManagerService : IProductManager

	{
        private readonly CoffeeShopContext _coffeeShopContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public InventoryManagerService(CoffeeShopContext coffeeShopContext, IWebHostEnvironment webHostEnvironment)
        {
            _coffeeShopContext = coffeeShopContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategories()
        {
            return await _coffeeShopContext.Categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
            }).ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetProperties()
        {
            return await _coffeeShopContext.Properties.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
            }).ToListAsync();
        }

        public string SaveImage(IFormFile image)
        {
            string extension = Path.GetExtension(image.FileName);

            string uniqueGuid = Guid.NewGuid().ToString();
            string newFileName = uniqueGuid + extension;

            string savePath = Path.Combine(_webHostEnvironment.WebRootPath, "images");

            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            string saveFilePath = Path.Combine(savePath, newFileName);

            using (var newFileStream = new FileStream(saveFilePath, FileMode.Create))
            {
                image.CopyTo(newFileStream);
            }

            return newFileName;
        }

        public void DeleteImage(Coffee coffeeToDelete)
        {
            string imagePath = coffeeToDelete.ImageString.Replace("~/images/", "");
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "images", imagePath);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public async Task<Category> SetCategory(AdminUpdateProductViewModel updateProductModel)
        {
            return await _coffeeShopContext.Categories
                .FirstOrDefaultAsync(c => c.Id == updateProductModel.SelectedCategoryId);
        }

        public async Task<ICollection<Property>> SetProperties(AdminUpdateProductViewModel updateProductModel)
        {
            return await _coffeeShopContext.Properties
                .Where(p => updateProductModel.SelectedPropertyIdList.Contains(p.Id))
                .ToListAsync();
        }

		public async Task Create(Coffee coffee)
		{
            await _coffeeShopContext.Coffees.AddAsync(coffee);
			await _coffeeShopContext.SaveChangesAsync();
		}

		public async Task Update(Coffee coffee)
		{
			_coffeeShopContext.Coffees.Update(coffee);
			await _coffeeShopContext.SaveChangesAsync();
		}

		public async Task Delete(Coffee coffee)
		{
			_coffeeShopContext.Coffees.Remove(coffee);
			await _coffeeShopContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<Coffee>> FindImageMatch(Coffee coffee)
		{
			return await _coffeeShopContext.Coffees.Where(c => c.ImageString == coffee.ImageString).ToListAsync();
		}
	}
}
