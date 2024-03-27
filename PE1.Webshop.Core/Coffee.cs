using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core
{
    public class Coffee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }
        public decimal Price { get; set; }
        public string Image { get { return $"~/images/sku-{Id}.webp"; } }
        public Category Category { get; set; }
        public IEnumerable<Property> Properties { get; set; }
        public bool CertifiedOrganic { get; set; }
    }
}
