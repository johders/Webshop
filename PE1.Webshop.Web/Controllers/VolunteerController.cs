using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Controllers
{
    public class VolunteerController : Controller
    {

        private readonly CoffeeShopContext _coffeeShopContext;

		public VolunteerController(CoffeeShopContext coffeeShopContext)
		{
			_coffeeShopContext = coffeeShopContext;
		}

		[HttpGet]
        public IActionResult Apply()
        {
            var applicationModel = new VolunteerApplyViewModel
            {
                FromDate = DateTime.Today,
                ToDate = DateTime.Today,
                Countries = GetCountries()
            };
           
            return View(applicationModel);
        }

        [HttpPost]
        public async Task<IActionResult> Apply(VolunteerApplyViewModel applicantForm)
        {
			applicantForm.Countries = GetCountries();

			if (!ModelState.IsValid)
            {
                
				return View(applicantForm);
			}

            var newApplication = new VolunteerApplication
            {
                FirstName = applicantForm.FirstName,
                LastName = applicantForm.LastName,
                Email = applicantForm.Email,
                ArrivalDate = applicantForm.FromDate,
                DepartureDate = applicantForm.ToDate,
                Country = applicantForm.GetCountry(applicantForm.SelectedCountryId),
                NewsLetterSignUp = applicantForm.SignUpNewsLetter
            };

            try
            {
                _coffeeShopContext.VolunteerApplications.Add(newApplication);
                await _coffeeShopContext.SaveChangesAsync();
            }
			catch (DbUpdateException ex)
			{
				Console.WriteLine(ex.Message);
			}

			return RedirectToAction("Success", applicantForm);              
            
        }

        public IActionResult Success(VolunteerApplyViewModel applicantForm)
        {
            applicantForm.Countries = GetCountries();
            return View(applicantForm);
        }

        public IEnumerable<SelectListItem> GetCountries()
        {
            List<SelectListGroup> continents = new List<SelectListGroup>
            {
                new SelectListGroup { Name = "Latin America" },
                new SelectListGroup { Name = "Africa" }
            };

            yield return new SelectListItem { Value = "0", Text = "--Choose Country--"};
            yield return new SelectListItem { Value = "1", Text = "Nicaragua", Group = continents[0] };
            yield return new SelectListItem { Value = "2", Text = "Peru", Group = continents[0] };
            yield return new SelectListItem { Value = "3", Text = "Mexico", Group = continents[0] };
            yield return new SelectListItem { Value = "4", Text = "Guatemala", Group = continents[0] };
            yield return new SelectListItem { Value = "5", Text = "Ethiopia", Group = continents[1] };
        }
      
    }
}
