using Microsoft.AspNetCore.Mvc;
using PE1.Webshop.Web.Services;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.ViewComponents
{
    [ViewComponent(Name = "NavigationLinks")]
    public class NavigationLinksViewComponent : ViewComponent
    {
        private readonly ActionLinkBuilder _actionLinkBuilder = new();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var navigationLinksComponentViewModel = new NavigationLinksComponentViewModel
            {
                MenuLinks = _actionLinkBuilder.MenuItems
            };
            return await Task.FromResult(View(navigationLinksComponentViewModel));
        }
    }
}
