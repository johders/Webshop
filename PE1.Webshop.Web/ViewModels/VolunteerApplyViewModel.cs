using Microsoft.AspNetCore.Mvc.Rendering;
using PE1.Webshop.Web.Services;
using System.ComponentModel.DataAnnotations;

namespace PE1.Webshop.Web.ViewModels
{
    public class VolunteerApplyViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter email address")]
        public string Email { get; set; }

        [Display(Name = "Arrival")]
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        [Display(Name = "Departure")]
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }

        [Display(Name = "Pick a country to volunteer in")]
        [SelectListItemRequired(ErrorMessage = "Please select a location")]
        public int SelectedCountryId { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }

		[CheckBoxRequired(ErrorMessage = "Please agree to Terms and Conditions to proceed")]
		public bool AgreeToTermsAndConditions { get; set; }
        public bool SignUpNewsLetter { get; set; }

        public string GetCountry(int selectedCountryId)
        {
            var result = Countries.FirstOrDefault(c => int.Parse(c.Value) == selectedCountryId);

            return result.Text;
        }
    }
}
