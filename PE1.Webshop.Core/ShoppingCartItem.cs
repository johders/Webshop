using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
		public decimal ItemsTotal { get { return Quantity * Coffee.Price; } }

		public int CoffeeId { get; set; }
        public Coffee Coffee { get; set; }
    }
}
