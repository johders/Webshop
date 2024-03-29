using Microsoft.AspNetCore.Mvc;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Models;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.ViewComponents
{
    [ViewComponent(Name = "FlavorList")]
    public class FlavorListViewComponent : ViewComponent
    {
        //private readonly PropertyRepository _propertyRepository = new();

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var flavorListComponentViewModel = new FlavorListComponentViewModel
        //    {
        //        MenuLinks = _propertyRepository.Properties.Select(flavor => new ActionLink
        //        {
        //            Controller = "Products",
        //            Action = "FilteredByProperty",
        //            Name = flavor.Name,
        //            Id = flavor.Id
        //        })
        //    };
        //    return await Task.FromResult(View(flavorListComponentViewModel));
        //}


    }
}
