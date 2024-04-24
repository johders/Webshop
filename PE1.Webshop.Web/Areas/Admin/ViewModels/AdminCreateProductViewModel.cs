using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Services;
using PE1.Webshop.Web.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace PE1.Webshop.Web.Areas.Admin.ViewModels
{
	public class AdminCreateProductViewModel
	{
		[HiddenInput]
		public int? Id { get; set; }

		[Display(Name = "Product Name")]
		[Required(ErrorMessage = "Please enter product name")]
		public string Name { get; set; }

		[Display(Name = "Description")]
		[Required(ErrorMessage = "Please enter a description")]
		public string Description { get; set; }

		[Display(Name = "Origin")]
		[Required(ErrorMessage = "Please enter origin")]
		public string Origin { get; set; }

		[Display(Name = "Price")]
        [PriceInputStringDigitValidation(ErrorMessage = "Please enter valid price (eg. 18,50)")]
		public string PriceInput { get; set; }

		[Display(Name = "Product Image")]
		[Required(ErrorMessage = "Please select an image file")]
		public IFormFile ImageFile { get; set; }

		[Display(Name = "Is product Certified Organic?")]
		public bool CertifiedOrganic { get; set; }		

		[Display(Name = "Roast Type")]
		[Required(ErrorMessage = "Please select a category")]
		public int SelectedCategoryId { get; set; }

		[Display(Name = "Choose flavors from options below")]
		[PropertiesRequired(ErrorMessage = "Please select at lease one flavor")]
		public List<int> SelectedPropertyIdList { get; set; }
		
		public Category Category { get; set; }
		public ICollection<Property> Properties { get; set; }
		public IEnumerable<SelectListItem> CategoryOptions { get; set; }
		public IEnumerable<SelectListItem> PropertyOptions { get; set; }
		public string ImageString { get; set; }
		public decimal? Price { get; set; }

    }
}
