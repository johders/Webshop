using Newtonsoft.Json.Linq;
using PE1.Webshop.Core;

namespace PE1.Webshop.Web.ViewModels
{
    public class ProductsCoffeeDetailsViewModel : BaseViewModel
    {
        public string Description { get; set; }
        public string Origin { get; set; }
        public decimal? Price { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Property> Properties { get; set; }
        public string ImageString { get; set; }
        public bool CertifiedOrganic { get; set; }
    }

}
