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

		[Column(TypeName = "decimal(6,2)")]
		public decimal? SubTotal { get; set; }

		[Column(TypeName = "decimal(6,2)")]
		public decimal? TotalPrice { get; set; }

		[Column(TypeName = "decimal(6,2)")]
		public decimal? Shipping { get; set; }
		public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
