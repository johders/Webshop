using PE1.Webshop.Core;

namespace PE1.Webshop.Web.Models
{
    public static class ShoppingCartItemRepository
    {
        public static List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public static int? CartCount { get; set; }

        public static void Add(ShoppingCartItem item)
        {
            Items.Add(item);
        }
        public static void Remove(Coffee coffeeToRemove)
        {
            ShoppingCartItem toRemove = Items.FirstOrDefault(item => item.Coffee.Id == coffeeToRemove.Id);
            Items.Remove(toRemove);
        }
    }
}
