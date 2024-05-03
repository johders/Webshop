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

            var orders = await _coffeeShopContext.WebOrders
                .Include(order => order.WebOrderCoffees)
                .ThenInclude(weborder => weborder.Coffee)
                .Select(order => new OrderDetailsViewModel
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    CustomerName = order.User.FirstName + " " + order.User.LastName,
                    Status = "Unshipped",
                    Items = order.WebOrderCoffees
                }).ToListAsync();
            allOrders.AllOrders = orders;


            return View(allOrders);
        }

        public async Task<IActionResult> ShowDetails(Guid id)
        {
           
            var coffees = await _productBuilder.GetCoffees();
            var orders = await _coffeeShopContext.WebOrders
                .Include(order => order.WebOrderCoffees)
                .ThenInclude(weborder => weborder.Coffee)
                .Select(order => new OrderDetailsViewModel
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    CustomerName = order.User.FirstName + " " + order.User.LastName,
                    Status = "Unshipped",
                    Items = order.WebOrderCoffees
                }).ToListAsync();

            var selectedOrder = orders.FirstOrDefault(order => order.Id == id);         

            return View(selectedOrder);
        }

        public async Task<IActionResult> Complete(Guid id) 
        {
            var orderCompleted = await _coffeeShopContext.WebOrders
                .FirstOrDefaultAsync(order => order.Equals(id));

            if(orderCompleted != null)
            {
                orderCompleted.Status = "Completed";
            }

            try
            {
                await _coffeeShopContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return RedirectToAction("Index");
        
        }
    }

}
