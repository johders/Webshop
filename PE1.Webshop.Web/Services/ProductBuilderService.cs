using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Services.Interfaces;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Services
{
	public class ProductBuilderService : IProductBuilder
	{
		private readonly CoffeeShopContext _coffeeShopContext;

		public ProductBuilderService(CoffeeShopContext coffeeShopContext)
		{
			_coffeeShopContext = coffeeShopContext;
		}

		public ProductsCoffeeDetailsViewModel CreateProductDetailsViewModel(Coffee coffee)
		{
			return new ProductsCoffeeDetailsViewModel
			{
				Id = coffee?.Id,
				Name = coffee?.Name,
				Description = coffee?.Description,
				Origin = coffee?.Origin,
				Price = coffee?.Price,
				Category = coffee.Category,
				Properties = coffee?.Properties,
				ImageString = coffee?.ImageString,
				CertifiedOrganic = coffee.CertifiedOrganic
			};
		}

		public async Task<ICollection<ProductsCoffeeDetailsViewModel>> GetCoffees()
		{
			return await _coffeeShopContext.Coffees
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
		}

		public async Task<ICollection<ProductsCoffeeDetailsViewModel>> GetCoffeesByCategory(int id)
		{
			return await _coffeeShopContext.Coffees
				.Where(c => c.CategoryId == id)
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
		}

		public async Task<ICollection<ProductsCoffeeDetailsViewModel>> GetCoffeesByProperty(int id)
		{
			return await _coffeeShopContext.Coffees
				.Where(c => c.Properties.Any(p => p.Id == id))
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
		}

		public async Task<Coffee> GetCoffeeById(int id)
		{
			return await _coffeeShopContext.Coffees
                .Include(c => c.Category)
                .Include(c => c.Properties)
                .FirstOrDefaultAsync(coffee => coffee.Id == id);
        }

        public async Task<string> GetPropertyName(int id)
        {
            return await _coffeeShopContext.Properties
                .Where(p => p.Id == id)
                .Select(p => p.Name)
                .FirstOrDefaultAsync();
        }

        public string GetCategoryName(int id, ICollection<ProductsCoffeeDetailsViewModel> model)
        {
            return model
				.Select(c => c.Category.Name)
                .First();
        }

        public async Task<ICollection<CategoriesCategoryDetailsViewModel>> GetCategories()
        {
            return await _coffeeShopContext.Categories
                .Select(category => new CategoriesCategoryDetailsViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    ImageString = category.ImageString
                }).ToListAsync();
        }

        public async Task<ICollection<PropertiesPropertyDetailsViewModel>> GetProperties()
        {
            return await _coffeeShopContext.Properties
                .Select(property => new PropertiesPropertyDetailsViewModel
                {
                    Id = property.Id,
                    Name = property.Name
                }).OrderBy(p => p.Name).ToListAsync();
        }
    }
}
