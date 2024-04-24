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

        public async Task<IActionResult> AddToCart(int id)
        {

            var coffeeToAdd = await _coffeeShopContext.Coffees.FirstOrDefaultAsync(coffee => coffee.Id == id);
            var existingCartItem = await _coffeeShopContext.ShoppingCartItems.FirstOrDefaultAsync(item => item.Coffee.Id == id);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
                try
                {
                    await _coffeeShopContext.SaveChangesAsync();
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
                    await _coffeeShopContext.SaveChangesAsync();
                }
                catch(DbUpdateException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            return RedirectToAction("ViewCart");
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {

            var coffeeToRemove = await _coffeeShopContext.Coffees.FirstOrDefaultAsync(coffee => coffee.Id == id);
            var existingCartItem = await _coffeeShopContext.ShoppingCartItems.FirstOrDefaultAsync(item => item.Coffee.Id == id);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity--;
                if (existingCartItem.Quantity <= 0)
                {                  
                    try
                    {
                        _coffeeShopContext.ShoppingCartItems.Remove(existingCartItem);
                        await _coffeeShopContext.SaveChangesAsync();
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

        public async Task<IActionResult> ViewCart()
        {

            var cartItems = await _coffeeShopContext.ShoppingCartItems
                .Include(i => i.Coffee)
                .ThenInclude(c => c.Category)
                .Select(item => new ShoppingCartItemViewModel
            {
                Id = item.Id,
                Quantity = item.Quantity,
                Coffee = item.Coffee,
            }).ToListAsync();


            var cartViewModel = new ShoppingCartViewModel
            {
                CartItems = cartItems,
                SubTotal = cartItems.Sum(item => item.Coffee.Price * item.Quantity),
                TotalQuantity = cartItems.Sum(item => item.Quantity)
            };

            return View(cartViewModel);
        }

        public async Task<IActionResult> Checkout()
        {
            var cartItems = await _coffeeShopContext.ShoppingCartItems.Select(item => new ShoppingCartItemViewModel
            {
                Id = item.Id,
                Quantity = item.Quantity,
                Coffee = item.Coffee,
            }).ToListAsync();

            var cartToCheckout = new ShoppingCartViewModel
            {
                CartItems = cartItems,
                SubTotal = cartItems.Sum(item => item.Coffee.Price * item.Quantity),
                TotalQuantity = cartItems.Sum(item => item.Quantity)
            };

            var newOrder = new Order
            {
                ShoppingCartItems = await _coffeeShopContext.ShoppingCartItems.ToListAsync(),
                TotalQuantity = cartToCheckout.TotalQuantity,
                SubTotal = cartToCheckout.SubTotal,
                Shipping = cartToCheckout.Shipping,
                TotalPrice = cartToCheckout.TotalPrice,
            };

            try
            {
                _coffeeShopContext.Orders.Add(newOrder);
                await _coffeeShopContext.SaveChangesAsync();
            }
			catch (DbUpdateException ex)
			{
				Console.WriteLine(ex.Message);
			}

			return View(cartToCheckout);
        }

        public async Task<IActionResult> ClearCart()
        {
            IEnumerable<ShoppingCartItem> allItems = await _coffeeShopContext.ShoppingCartItems.ToListAsync();

            try
            {
                _coffeeShopContext.ShoppingCartItems.RemoveRange(allItems);
                await _coffeeShopContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
