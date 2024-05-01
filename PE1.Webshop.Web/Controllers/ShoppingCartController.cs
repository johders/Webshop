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
        private readonly IProductBuilder _productBuilder;

        public ShoppingCartController(CoffeeShopContext coffeeShopContext, IProductBuilder productBuilder)
        {
            _coffeeShopContext = coffeeShopContext;
            _productBuilder = productBuilder;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var sessionCart = new ShoppingCartViewModel();
            sessionCart.CartItems = new List<ShoppingCartItemViewModel>();

            var coffeeToAdd = await _productBuilder.GetCoffeeById(id);

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
            }

            return RedirectToAction("ViewCart");
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {

            var sessionCart = new ShoppingCartViewModel();
            sessionCart.CartItems = new List<ShoppingCartItemViewModel>();

            var coffeeToRemove = await _productBuilder.GetCoffeeById(id);

            if (coffeeToRemove == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (HttpContext.Session.Keys.Contains(stateKey))
            {
                sessionCart = JsonConvert.DeserializeObject<ShoppingCartViewModel>(HttpContext.Session.GetString(stateKey));
            }

            var existingCartItem = sessionCart.CartItems.FirstOrDefault(item => item.Coffee.Id == id);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity--;
                if (existingCartItem.Quantity <= 0)
                {
                    sessionCart.CartItems.Remove(existingCartItem);
                }

                HttpContext.Session.SetString(stateKey, JsonConvert.SerializeObject(sessionCart, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                }));
            }

            return RedirectToAction("ViewCart");
        }

        public IActionResult ViewCart()
        {
            var sessionCart = JsonConvert.DeserializeObject<ShoppingCartViewModel>(HttpContext.Session.GetString(stateKey));

            sessionCart.SubTotal = sessionCart.CartItems.Sum(item => item.Coffee.Price * item.Quantity);
            sessionCart.TotalQuantity = sessionCart.CartItems.Sum(item => item.Quantity);

            return View(sessionCart);
        }

        public async Task<IActionResult> Checkout()
        {
            var sessionCart = new ShoppingCartViewModel();
            sessionCart.CartItems = new List<ShoppingCartItemViewModel>();

            if (HttpContext.Session.Keys.Contains(stateKey))
            {
                sessionCart = JsonConvert.DeserializeObject<ShoppingCartViewModel>(HttpContext.Session.GetString(stateKey));
            }

            sessionCart.SubTotal = sessionCart.CartItems.Sum(item => item.Coffee.Price * item.Quantity);
            sessionCart.TotalQuantity = sessionCart.CartItems.Sum(item => item.Quantity);

            if(sessionCart != null)
            {

                Guid orderId = Guid.NewGuid();
                sessionCart.CartId = orderId;

                WebOrder newOrder = new WebOrder
                {
                    Id = orderId,
                    OrderDate = DateTime.Now,
                    TotalQuantity = sessionCart.TotalQuantity,
                    SubTotal = sessionCart.SubTotal,
                    TotalPrice = sessionCart.SubTotal + sessionCart.Shipping,
                    Shipping = sessionCart.Shipping,
                    WebOrderCoffees = sessionCart.CartItems.Select(item => new WebOrderCoffee
                    {
                        WebOrderId = orderId,
                        CoffeeId = item.Coffee.Id,
                        UnitPrice = item.Coffee.Price,
                        Quantity = item.Quantity
                    }).ToList()
                };

                try
                {
                    _coffeeShopContext.WebOrders.Add(newOrder);
                    await _coffeeShopContext.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                HttpContext.Session.Clear();
            }

            return View(sessionCart);
        }

    }
}
