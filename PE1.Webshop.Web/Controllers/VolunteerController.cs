using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Controllers
{
    public class VolunteerController : Controller
    {
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
        public IActionResult Apply(VolunteerApplyViewModel applicantForm)
        {

            applicantForm.Countries = GetCountries();

            if (ModelState.IsValid)
            {
                return RedirectToAction("Success", applicantForm);              
            }

            return View(applicantForm);
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
