namespace PE1.Webshop.Web.ViewModels
{
    public class CategoriesAllCategoriesViewModel
    {
        public IEnumerable<CategoriesCategoryDetailsViewModel> AllCategories { get; set; }
        public CategoriesAllCategoriesViewModel()
        {
            AllCategories = new List<CategoriesCategoryDetailsViewModel>();
        }
    }
}
