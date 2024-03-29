using Microsoft.AspNetCore.Mvc;
using PE1.Webshop.Core;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Controllers
{
    public class PropertiesController : Controller
    {
        //private readonly PropertyRepository _propertyRepository;

        //public PropertiesController()
        //{
        //    _propertyRepository = new PropertyRepository();
        //}
        //public IActionResult AllProperties()
        //{
        //    ViewBag.PageTitle = "Flavors";

        //    IEnumerable<Property> properties = _propertyRepository.Properties.OrderBy(p => p.Name);

        //    var allPropertiesViewModel = new PropertiesAllPropertiesViewModel();

        //    allPropertiesViewModel.AllProperties = properties.Select(property => new PropertiesPropertyDetailsViewModel
        //    {
        //        Id = property?.Id,
        //        Name = property?.Name
        //    });

        //    return View(allPropertiesViewModel);
        //}
    }
}
