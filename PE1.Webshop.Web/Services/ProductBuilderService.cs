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
	}
}
