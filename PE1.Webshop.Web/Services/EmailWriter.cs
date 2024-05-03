using PE1.Webshop.Web.Areas.Admin.ViewModels;
using System.Text;

namespace PE1.Webshop.Web.Services
{
	public static class EmailWriter
	{
		public static string WriteEmail(OrderDetailsViewModel orderDetails)
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
