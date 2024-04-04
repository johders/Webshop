using Microsoft.AspNetCore.Mvc.Rendering;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Areas.Admin.ViewModels
{
	public class AdminCreateProductViewModel : ProductsCoffeeDetailsViewModel
	{
        public int SelectedCategoryId { get; set; }

        public List<int> SelectedPropertyIdList { get; set; }
        public IEnumerable<SelectListItem> CategoryOptions { get; set; }

		public IEnumerable<SelectListItem> PropertyOptions { get; set; }
	}
}
