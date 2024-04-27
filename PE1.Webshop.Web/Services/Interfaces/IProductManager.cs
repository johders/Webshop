using Microsoft.AspNetCore.Mvc.Rendering;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Areas.Admin.ViewModels;

namespace PE1.Webshop.Web.Services.Interfaces
{
    public interface IProductManager
    {
        string SaveImage(IFormFile image);

        void DeleteImage(Coffee coffeeToDelete);

        Task<IEnumerable<SelectListItem>> GetCategories();

        Task<IEnumerable<SelectListItem>> GetProperties();

        Task<Category> SetCategory(AdminUpdateProductViewModel producToUpdate);

        Task<ICollection<Property>> SetProperties(AdminUpdateProductViewModel producToUpdate);
    }
}
