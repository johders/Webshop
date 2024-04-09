using Microsoft.AspNetCore.Mvc.Rendering;
using PE1.Webshop.Web.Services;
using PE1.Webshop.Web.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace PE1.Webshop.Web.Areas.Admin.ViewModels
{
	public class AdminCreateProductViewModel : ProductsCoffeeDetailsViewModel
	{
        public int SelectedCategoryId { get; set; }

        public List<int> SelectedPropertyIdList { get; set; }
        public IEnumerable<SelectListItem> CategoryOptions { get; set; }

		public IEnumerable<SelectListItem> PropertyOptions { get; set; }

		public string PriceInput { get; set; }

        public IFormFile ImageFile { get; set; }

        public async void CreateImageFile(IFormFile file)
        {
			string path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/images", file.FileName);
			using (var stream = new FileStream(path, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}
		}
    }
}
