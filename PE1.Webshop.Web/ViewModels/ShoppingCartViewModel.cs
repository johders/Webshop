using PE1.Webshop.Web.Models;

namespace PE1.Webshop.Web.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<ShoppingCartItem> CartItems { get; set; }
        public int? TotalQuantity { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? TotalPrice { get { return SubTotal + Shipping; } }

        public decimal? Shipping
        {
            get
            {
                if (SubTotal < 50m && TotalQuantity > 0)
                {
                    return 6.95m;
                }
                else if (SubTotal < 70 && TotalQuantity > 0)
                {
                    return 3.95m;
                }
                else return 0;

            }
        }
    }
}
