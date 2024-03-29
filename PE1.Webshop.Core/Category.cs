using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get { return $"~/images/roast-{Id}.jpg"; } }
        public IEnumerable<Coffee> Coffees { get; set; }
    }
}
