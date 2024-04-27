namespace PE1.Webshop.Web.ViewModels
{
    public class CategoriesAllCategoriesViewModel
    {
        public ICollection<CategoriesCategoryDetailsViewModel> AllCategories { get; set; }
        public CategoriesAllCategoriesViewModel()
        {
            AllCategories = new List<CategoriesCategoryDetailsViewModel>();
        }
    }
}
