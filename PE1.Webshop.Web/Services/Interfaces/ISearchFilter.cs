using PE1.Webshop.Core;

namespace PE1.Webshop.Web.Services.Interfaces
{
    public interface ISearchFilter
    {
        Task<ICollection<Coffee>> FilteredByCategoryAndPrice(decimal price, string category);
        Task<ICollection<Coffee>> FilteredByCategoryPriceAndProperty(decimal price, string category, string flavor);
        Task<ICollection<Coffee>> FilteredByIsOrganicRegionAndProperty(bool certOrganic, string region, string flavor);
        Task<ICollection<Coffee>> FilteredByKeyword(string keyword);
    }
}
