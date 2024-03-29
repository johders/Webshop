using Microsoft.AspNetCore.Mvc;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Models;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.ViewComponents
{
    [ViewComponent(Name = "CategoryList")]
    public class CategoryListViewComponent : ViewComponent
    {
        //private readonly CategoryRepository _categoryRepository = new();

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var categoryLinksViewComponent = new CategoryListComponentViewModel
        //    {
        //        MenuLinks = _categoryRepository.Categories.Select(category => new ActionLink
        //        {
        //            Controller = "Products",
        //            Action = "FilteredByCategory",
        //            Name = category.Name,
        //            Id = category.Id
        //        })
        //    };
        //    return await Task.FromResult(View(categoryLinksViewComponent));
        //}
    }
}
