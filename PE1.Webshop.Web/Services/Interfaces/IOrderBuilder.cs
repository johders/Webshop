using PE1.Webshop.Web.Areas.Admin.ViewModels;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Services.Interfaces
{
    public interface IOrderBuilder
    {
        Task<ICollection<OrderDetailsViewModel>> GetOrders();
    }
}
