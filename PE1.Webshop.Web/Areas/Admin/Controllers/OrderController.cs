using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Web.Areas.Admin.ViewModels;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Services.Interfaces;

namespace PE1.Webshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly CoffeeShopContext _coffeeShopContext;
        private readonly IProductManager _productManager;
        private readonly IProductBuilder _productBuilder;
        public OrderController(CoffeeShopContext coffeeShopContext, IProductManager productManager, IProductBuilder productBuilder)
        {
            _coffeeShopContext = coffeeShopContext;
            _productManager = productManager;
            _productBuilder = productBuilder;
        }
        public async Task<IActionResult> Index()
        {
            var allOrders = new OrderAllOrdersViewModel();
            var coffees = await _productBuilder.GetCoffees();
            var orders = _coffeeShopContext.WebOrders
                .Include(order => order.WebOrderCoffees)
                .Select(order => new OrderDetailsViewModel
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    Items = order.WebOrderCoffees
                }).ToList();
            allOrders.AllOrders = orders;


            return View(allOrders);
        }
    }
}
