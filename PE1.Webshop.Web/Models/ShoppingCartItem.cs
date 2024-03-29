using PE1.Webshop.Core;

namespace PE1.Webshop.Web.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public Coffee Coffee { get; set; }
        public int Quantity { get; set; }
        public decimal ItemsTotal { get { return Quantity * Coffee.Price; } }
    }
}
