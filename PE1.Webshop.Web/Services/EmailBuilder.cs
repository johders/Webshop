using Microsoft.CodeAnalysis.CSharp;
using PE1.Webshop.Web.Areas.Admin.ViewModels;
using System.Text;

namespace PE1.Webshop.Web.Services
{
    public class EmailBuilder
    {
        public OrderDetailsViewModel OrderDetails { get; set; }

        public EmailBuilder(OrderDetailsViewModel orderDetails)
        {
            OrderDetails = orderDetails;
        }

        public string WriteEmail(OrderDetailsViewModel orderDetails)
        {

            StringBuilder sb = new StringBuilder();

            foreach (var item in OrderDetails.Items)
            {
                sb.AppendLine($"Product: {item.Coffee.Name} - Quantity: {item.Quantity} - Unit Price: {item.UnitPrice}");
            }

            string output =

$@"Hello,

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
