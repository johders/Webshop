using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Web.Areas.Admin.ViewModels;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.Services.Interfaces;

namespace PE1.Webshop.Web.Services
{
    public class OrderBuilderService : IOrderBuilder
    {
        private readonly CoffeeShopContext _coffeeShopContext;

        public OrderBuilderService(CoffeeShopContext coffeeShopContext)
        {
            _coffeeShopContext = coffeeShopContext;
        }

        public async Task<ICollection<OrderDetailsViewModel>> GetOrders()
        {
            return await _coffeeShopContext.WebOrders
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
        }
    }
}
