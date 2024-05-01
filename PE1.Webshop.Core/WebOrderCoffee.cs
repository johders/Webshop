using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core
{
    public class WebOrderCoffee
    {
        //public int Id { get; set; }
        public Guid WebOrderId { get; set; }

        public WebOrder WebOrder { get; set; }
        public int CoffeeId { get; set; }

        public Coffee Coffee { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal UnitPrice { get; set; }

        public decimal ItemsTotal { get { return Quantity * Coffee.Price; } }
        public int Quantity { get; set; }
    }
}
