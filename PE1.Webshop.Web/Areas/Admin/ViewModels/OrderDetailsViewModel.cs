using PE1.Webshop.Core;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Areas.Admin.ViewModels
{
    public class OrderDetailsViewModel
    {
        public Guid Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string CustomerName { get; set; }
        public string Status { get; set; }

        public decimal TotalPrice { get; set; }

        public ICollection<WebOrderCoffee> Items { get; set; }
    }
}
