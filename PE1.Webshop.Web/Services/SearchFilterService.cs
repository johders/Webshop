using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Services.Interfaces;

namespace PE1.Webshop.Web.Services
{
    public class SearchFilterService : ISearchFilter
    {
        private readonly CoffeeShopContext _coffeeShopContext;

        public SearchFilterService(CoffeeShopContext coffeeShopContext)
        {
            _coffeeShopContext = coffeeShopContext;
        }
        public async Task<ICollection<Coffee>> FilteredByCategoryAndPrice(decimal price, string category)
        {
            return await _coffeeShopContext.Coffees
                    .Include(c => c.Category)
                    .Include(c => c.Properties)
                    .Where(c => c.Category.Name.ToUpper().Contains(category.ToUpper()) && c.Price <= price)
                    .ToListAsync();
        }

        public async Task<ICollection<Coffee>> FilteredByCategoryPriceAndProperty(decimal price, string category, string flavor)
        {
            return await _coffeeShopContext.Coffees
                    .Include(c => c.Category)
                    .Include(c => c.Properties)
                    .Where(s => s.Properties.Any(c => c.Name.ToUpper().Contains(flavor.ToUpper())) && s.Price < price && s.Category.Name.ToUpper()
                    .Contains(category.ToUpper()))
                    .ToListAsync();
        }

        public async Task<ICollection<Coffee>> FilteredByIsOrganicRegionAndProperty(bool certOrganic, string region, string flavor)
        {
            return await _coffeeShopContext.Coffees
                    .Include(c => c.Category)
                    .Include(c => c.Properties)
                    .Where(c => c.Origin.ToUpper().Contains(region.ToUpper()) && c.Properties
                    .Any(c => c.Name.ToUpper().Contains(flavor.ToUpper())) && c.CertifiedOrganic == certOrganic)
                    .ToListAsync();
        }

        public async Task<ICollection<Coffee>> FilteredByKeyword(string keyword)
        {
            return await _coffeeShopContext.Coffees
                 .Include(c => c.Category)
                 .Include(c => c.Properties)
                 .Where(s => s.Description.ToUpper().Contains(keyword.ToUpper()) || s.Origin.ToUpper().Contains(keyword.ToUpper()) || s.Properties
                 .Any(c => c.Name.ToUpper().Contains(keyword.ToUpper())) || s.Category.Name.ToUpper().Contains(keyword.ToUpper()) || s.Name.ToUpper()
                 .Contains(keyword.ToUpper())).ToListAsync();
        }
    }
}
