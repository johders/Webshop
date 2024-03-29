namespace PE1.Webshop.Web.ViewModels
{
    public class ProductsAllCoffeesViewModel
    {
        public IEnumerable<ProductsCoffeeDetailsViewModel> AllCoffees { get; set; }

        public ProductsAllCoffeesViewModel() 
        {
            AllCoffees = new List<ProductsCoffeeDetailsViewModel>();
        }
    }
}
