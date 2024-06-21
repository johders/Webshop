using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Web.Areas.Admin.ViewModels;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Services;
using PE1.Webshop.Web.Services.Interfaces;
using System.Text;

namespace PE1.Webshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly CoffeeShopContext _coffeeShopContext;
        private readonly IEmailSender _emailSender;
        private readonly IOrderBuilder _orderBuilder;
        public OrderController(CoffeeShopContext coffeeShopContext, IEmailSender emailSender, IOrderBuilder orderBuilder)
        {
            _coffeeShopContext = coffeeShopContext;
            _emailSender = emailSender;
            _orderBuilder = orderBuilder;
        }
        public async Task<IActionResult> Index()
        {
            var allOrders = new OrderAllOrdersViewModel();

            var orders = await _orderBuilder.GetOrders();
            allOrders.AllOrders = orders.OrderByDescending(order => order.Status).ToList();

            return View(allOrders);
        }

        public async Task<IActionResult> ShowDetails(Guid id)
        {
            var orders = await _orderBuilder.GetOrders();
            var selectedOrder = orders.FirstOrDefault(order => order.Id == id);         

            return View(selectedOrder);
        }

        public async Task<IActionResult> Confirm(Guid id) 
        {
            var orders = await _orderBuilder.GetOrders();
            var orderCompleted = orders
                .FirstOrDefault(order => order.Id == id);

            if(orderCompleted != null)
            {
                //Enter recipient email address below
                string recipientEmail = "someone@somewhere.com";
                string subject = "Your Pachamama order has been dispatched!";
                string body = EmailWriter.WriteEmail(orderCompleted);

                try
                {
                    _emailSender.SendEmail(recipientEmail, subject, body);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

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
    }

}
