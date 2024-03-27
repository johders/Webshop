using Microsoft.AspNetCore.Mvc;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Models;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly CoffeeRepository _coffeeRepository;

        public ShoppingCartController()
        {
            _coffeeRepository = new CoffeeRepository();
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult AddToCart(int id)
        {
            
            var coffeeToAdd = _coffeeRepository.Coffees.FirstOrDefault(coffee => coffee.Id == id);
            var existingCartItem = ShoppingCartItemRepository.Items.FirstOrDefault(item => item.Coffee.Id == id);

            if(existingCartItem != null)
            {
                existingCartItem.Quantity++;
            }
            else
            {
				ShoppingCartItemRepository.Add(new ShoppingCartItem
                {
                    Coffee = coffeeToAdd,
                    Quantity = 1
                });
            }

            return RedirectToAction("ViewCart");
        }
        
        public IActionResult RemoveFromCart(int id)
        {

            var coffeeToRemove = _coffeeRepository.Coffees.FirstOrDefault(coffee => coffee.Id == id);
            var existingCartItem = ShoppingCartItemRepository.Items.FirstOrDefault(item => item.Coffee.Id == id);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity--;
                if(existingCartItem.Quantity <= 0)
                {
                    ShoppingCartItemRepository.Remove(coffeeToRemove);
                }
            }
            
            return RedirectToAction("ViewCart");
        }

        public IActionResult ViewCart()
        {
            var cartViewModel = new ShoppingCartViewModel
            {
                CartItems = ShoppingCartItemRepository.Items,
                SubTotal = ShoppingCartItemRepository.Items.Sum(item => item.Coffee.Price * item.Quantity),
                TotalQuantity = ShoppingCartItemRepository.Items.Sum(item => item.Quantity)
            };

            ShoppingCartItemRepository.CartCount = cartViewModel.TotalQuantity;

            return View(cartViewModel);
        }

        public IActionResult Checkout()
        {
            var cartToCheckout = new ShoppingCartViewModel
            {
                CartItems = ShoppingCartItemRepository.Items,
                SubTotal = ShoppingCartItemRepository.Items.Sum(item => item.Coffee.Price * item.Quantity),
                TotalQuantity = ShoppingCartItemRepository.Items.Sum(item => item.Quantity)
            };

            ShoppingCartItemRepository.CartCount = cartToCheckout.TotalQuantity;
            return View(cartToCheckout);
        }

        public IActionResult ClearCart()
        {
            ShoppingCartItemRepository.Items.Clear();
            ShoppingCartItemRepository.CartCount = 0;

            return RedirectToAction("Index", "Home");
        }
    }
}
