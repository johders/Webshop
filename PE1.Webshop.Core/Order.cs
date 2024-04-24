using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core
{
	public class Order
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; set; }
		public int? TotalQuantity { get; set; }
		public decimal? SubTotal { get; set; }
		public decimal? TotalPrice { get; set; }

		public decimal? Shipping { get; set; }
		public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
