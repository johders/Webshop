using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Web.Areas.Admin.ViewModels;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Services.Interfaces;
using System.Text;

namespace PE1.Webshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly CoffeeShopContext _coffeeShopContext;
        private readonly IEmailSender _emailSender;
        private readonly IProductBuilder _productBuilder;
        public OrderController(CoffeeShopContext coffeeShopContext, IEmailSender emailSender, IProductBuilder productBuilder)
        {
            _coffeeShopContext = coffeeShopContext;
            _emailSender = emailSender;
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
                    Status = order.Status,
                    Items = order.WebOrderCoffees
                }).ToListAsync();
            allOrders.AllOrders = orders;


            return View(allOrders);
        }

        public async Task<IActionResult> ShowDetails(Guid id)
        {
           
            //var coffees = await _productBuilder.GetCoffees();
            var orders = await _coffeeShopContext.WebOrders
                .Include(order => order.WebOrderCoffees)
                .ThenInclude(weborder => weborder.Coffee)
                .Select(order => new OrderDetailsViewModel
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    CustomerName = order.User.FirstName + " " + order.User.LastName,
                    Status = order.Status,
                    Items = order.WebOrderCoffees
                }).ToListAsync();

            var selectedOrder = orders.FirstOrDefault(order => order.Id == id);         

            return View(selectedOrder);
        }

        public async Task<IActionResult> Confirm(Guid id) 
        {

            //var coffees = await _productBuilder.GetCoffees();
            var orders = await _coffeeShopContext.WebOrders
                .Include(order => order.WebOrderCoffees)
                .ThenInclude(weborder => weborder.Coffee)
                .Select(order => new OrderDetailsViewModel
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    CustomerName = order.User.FirstName + " " + order.User.LastName,
                    Status = order.Status,
                    Items = order.WebOrderCoffees,
                    TotalPrice = (decimal)order.TotalPrice
                }).ToListAsync();

            var orderCompleted = orders
                .FirstOrDefault(order => order.Id == id);

            if(orderCompleted != null)
            {

                string recipientEmail = "djohannes7@gmail.com";
                string subject = "Your Pachamama order has been dispatched!";
                string body = WriteEmail(orderCompleted);

                await _emailSender.SendEmailAsync(recipientEmail, subject, body);

                orderCompleted.Status = "Completed";
            }

            var orderToUpdate = _coffeeShopContext.WebOrders.Find(id);
            orderToUpdate.Status = orderCompleted.Status;

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

        private string WriteEmail(OrderDetailsViewModel orderDetails)
        {

            StringBuilder sb = new StringBuilder();

            foreach (var item in orderDetails.Items)
            {
                sb.AppendLine($"Product: {item.Coffee.Name} - Quantity: {item.Quantity} - Unit Price: {item.UnitPrice}");
            }

            string output =

$@"Hello {orderDetails.CustomerName},

We thought you'd like to know that we dispatched your order.

ORDER SUMMARY:
Order #: {orderDetails.Id}
Order Date: {orderDetails.OrderDate}
Order Total: {orderDetails.TotalPrice}

ITEMS:
{sb}

SHIPPING ADDRESS: 
Kriekenstraat 12, 3500 Hasselt, Limburg


Whe hope to see you again soon,
Pachamama Coffee Farmers";

            return output;
        }
    }

}
