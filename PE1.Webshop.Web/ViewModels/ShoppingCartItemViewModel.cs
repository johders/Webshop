﻿using PE1.Webshop.Core;

namespace PE1.Webshop.Web.ViewModels
{
    public class ShoppingCartItemViewModel
    {
        public int Id { get; set; }
        public Coffee Coffee { get; set; }
        public int Quantity { get; set; }
        public decimal ItemsTotal { get { return Quantity * Coffee.Price; } }
    }
}
