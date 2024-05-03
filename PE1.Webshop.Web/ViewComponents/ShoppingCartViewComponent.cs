using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Models;
using PE1.Webshop.Web.Services;
using PE1.Webshop.Web.Services.Interfaces;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.ViewComponents
{
    [ViewComponent(Name = "ShoppingCart")]
    public class ShoppingCartViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sessionCart = new ShoppingCartViewModel();
            sessionCart.CartItems = new List<ShoppingCartItemViewModel>();

            if (HttpContext.Session.Keys.Contains("Cart"))
            {
                sessionCart = JsonConvert.DeserializeObject<ShoppingCartViewModel>(HttpContext.Session.GetString("Cart"));
            }

            var cartItems = sessionCart.CartItems;

            var shoppingCartViewModel = new ShoppingCartComponentViewModel
            {
                NumberOfItems = cartItems.Sum(item => item.Quantity)
            };
            return await Task.FromResult(View(shoppingCartViewModel));
        }
    }
}
