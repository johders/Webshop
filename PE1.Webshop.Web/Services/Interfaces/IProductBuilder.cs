using PE1.Webshop.Core;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Services.Interfaces
{
	public interface IProductBuilder
	{
		Task<ICollection<ProductsCoffeeDetailsViewModel>> GetCoffees();
		Task<ICollection<ProductsCoffeeDetailsViewModel>> GetCoffeesByCategory(int id);
		Task<ICollection<ProductsCoffeeDetailsViewModel>> GetCoffeesByProperty(int id);
		ProductsCoffeeDetailsViewModel CreateProductDetailsViewModel(Coffee coffee);
	}
}
