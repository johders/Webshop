using Microsoft.AspNetCore.Mvc;
using PE1.Webshop.Web.Models;
using PE1.Webshop.Web.Services;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.ViewComponents
{
    [ViewComponent(Name = "ShoppingCart")]
    public class ShoppingCartViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var shoppingCartViewModel = new ShoppingCartComponentViewModel
            {
                NumberOfItems = ShoppingCartItemRepository.CartCount
            };
            return await Task.FromResult(View(shoppingCartViewModel));
        }
    }
}
