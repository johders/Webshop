using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Models;
using PE1.Webshop.Web.Services;
using PE1.Webshop.Web.Services.Interfaces;
using PE1.Webshop.Web.ViewModels;
using System.Text.Json;

namespace PE1.Webshop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        const string stateKey = "Cart";
        private readonly CoffeeShopContext _coffeeShopContext;
        private List<ShoppingCartItem> _cartItems;

        public ShoppingCartController(CoffeeShopContext coffeeShopContext)
        {
            _coffeeShopContext = coffeeShopContext;
            _cartItems = new List<ShoppingCartItem>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddToCart([FromServices] IProductBuilder productBuilder, int id)
        {
            var sessionCart = new ShoppingCartViewModel();
            sessionCart.CartItems = new List<ShoppingCartItemViewModel>();

            var coffeeToAdd = await productBuilder.GetCoffeeById(id);
                
                //_coffeeShopContext.Coffees.FirstOrDefaultAsync(coffee => coffee.Id == id);


            if(coffeeToAdd == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if(HttpContext.Session.Keys.Contains(stateKey))
            {
                sessionCart = JsonConvert.DeserializeObject<ShoppingCartViewModel>(HttpContext.Session.GetString(stateKey));
            }

            var existingCartItem = sessionCart.CartItems.FirstOrDefault(item => item.Coffee.Id == id);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
                //try
                //{
                //    await _coffeeShopContext.SaveChangesAsync();
                //}
                //catch (DbUpdateException ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
                HttpContext.Session.SetString(stateKey, JsonConvert.SerializeObject(sessionCart, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                }));
            }
            else
            {
                var newItem = new ShoppingCartItemViewModel
                {
                    Id = coffeeToAdd.Id,
                    Coffee = coffeeToAdd,
                    Quantity = 1
                };

                sessionCart.CartItems.Add(newItem);

                HttpContext.Session.SetString(stateKey, JsonConvert.SerializeObject(sessionCart, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                }));
                //try
                //{
                //    _coffeeShopContext.ShoppingCartItems.Add(newItem);
                //    await _coffeeShopContext.SaveChangesAsync();
                //}
                //catch(DbUpdateException ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}

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
            //var sessionCartItems = HttpContext.Session.Get<List<ShoppingCartItem>>(stateKey);

            //var cartItems = await _coffeeShopContext.ShoppingCartItems
            //    .Include(i => i.Coffee)
            //    .ThenInclude(c => c.Category)
            //    .Select(item => new ShoppingCartItemViewModel
            //{
            //    Id = item.Id,
            //    Quantity = item.Quantity,
            //    Coffee = item.Coffee,
            //}).ToListAsync();


            //var cartViewModel = new ShoppingCartViewModel
            //{
            //    CartItems = cartItems,
            //    SubTotal = cartItems.Sum(item => item.Coffee.Price * item.Quantity),
            //    TotalQuantity = cartItems.Sum(item => item.Quantity)
            //};
            var sessionCart = JsonConvert.DeserializeObject<ShoppingCartViewModel>(HttpContext.Session.GetString(stateKey));

            var cartViewModel = new ShoppingCartViewModel
            {
                CartItems = sessionCart.CartItems,
                SubTotal = sessionCart.CartItems.Sum(item => item.Coffee.Price * item.Quantity),
                TotalQuantity = sessionCart.CartItems.Sum(item => item.Quantity)
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
