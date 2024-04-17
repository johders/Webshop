using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Models;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly CoffeeShopContext _coffeeShopContext;

        public ShoppingCartController(CoffeeShopContext coffeeShopContext)
        {
            _coffeeShopContext = coffeeShopContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToCart(int id)
        {

            var coffeeToAdd = _coffeeShopContext.Coffees.FirstOrDefault(coffee => coffee.Id == id);
            var existingCartItem = _coffeeShopContext.ShoppingCartItems.FirstOrDefault(item => item.Coffee.Id == id);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
                try
                {
                    _coffeeShopContext.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                var newItem = new ShoppingCartItem
                {
                    Coffee = coffeeToAdd,
                    Quantity = 1
                };

                try
                {
                    _coffeeShopContext.ShoppingCartItems.Add(newItem);
                    _coffeeShopContext.SaveChanges();
                }
                catch(DbUpdateException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            return RedirectToAction("ViewCart");
        }

        public IActionResult RemoveFromCart(int id)
        {

            var coffeeToRemove = _coffeeShopContext.Coffees.FirstOrDefault(coffee => coffee.Id == id);
            var existingCartItem = _coffeeShopContext.ShoppingCartItems.FirstOrDefault(item => item.Coffee.Id == id);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity--;
                if (existingCartItem.Quantity <= 0)
                {                  
                    try
                    {
                        _coffeeShopContext.ShoppingCartItems.Remove(existingCartItem);
                        _coffeeShopContext.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                try
                {
                    _coffeeShopContext.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            return RedirectToAction("ViewCart");
        }

        public IActionResult ViewCart()
        {

            var cartItems = _coffeeShopContext.ShoppingCartItems
                .Include(i => i.Coffee)
                .ThenInclude(c => c.Category)
                .Select(item => new ShoppingCartItemViewModel
            {
                Id = item.Id,
                Quantity = item.Quantity,
                Coffee = item.Coffee,
            });


            var cartViewModel = new ShoppingCartViewModel
            {
                CartItems = cartItems,
                SubTotal = cartItems.Sum(item => item.Coffee.Price * item.Quantity),
                TotalQuantity = cartItems.Sum(item => item.Quantity)
            };

            return View(cartViewModel);
        }

        public IActionResult Checkout()
        {
            var cartItems = _coffeeShopContext.ShoppingCartItems.Select(item => new ShoppingCartItemViewModel
            {
                Id = item.Id,
                Quantity = item.Quantity,
                Coffee = item.Coffee,
            });

            var cartToCheckout = new ShoppingCartViewModel
            {
                CartItems = cartItems,
                SubTotal = cartItems.Sum(item => item.Coffee.Price * item.Quantity),
                TotalQuantity = cartItems.Sum(item => item.Quantity)
            };

            return View(cartToCheckout);
        }

        public IActionResult ClearCart()
        {
            IEnumerable<ShoppingCartItem> allItems = _coffeeShopContext.ShoppingCartItems;

            try
            {
                _coffeeShopContext.ShoppingCartItems.RemoveRange(allItems);
                _coffeeShopContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
