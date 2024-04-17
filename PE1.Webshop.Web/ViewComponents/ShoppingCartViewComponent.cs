using Microsoft.AspNetCore.Mvc;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Models;
using PE1.Webshop.Web.Services;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.ViewComponents
{
    [ViewComponent(Name = "ShoppingCart")]
    public class ShoppingCartViewComponent : ViewComponent
    {

        private readonly CoffeeShopContext _coffeeShopContext;

        public ShoppingCartViewComponent(CoffeeShopContext coffeeShopContext)
        {
            _coffeeShopContext = coffeeShopContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cartItems = _coffeeShopContext.ShoppingCartItems;

            var shoppingCartViewModel = new ShoppingCartComponentViewModel
            {
                NumberOfItems = cartItems.Sum(item => item.Quantity)
            };
            return await Task.FromResult(View(shoppingCartViewModel));
        }
    }
}
