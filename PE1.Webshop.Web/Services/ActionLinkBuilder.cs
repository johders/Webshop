using PE1.Webshop.Web.Models;

namespace PE1.Webshop.Web.Services
{
    public class ActionLinkBuilder
    {
        public IEnumerable<ActionLink> MenuItems { get; set; }

        public ActionLinkBuilder() 
        {
            MenuItems = new List<ActionLink>
            {
                 new ActionLink
                {
                    Controller = "Products",
                    Action = "AllCoffees",
                    Name = "Our Coffees"
                },
                  new ActionLink
                {
                    Controller = "Search",
                    Action = "Index",
                    Name = "Search"
                }
                  ,
                  new ActionLink
                {
                    Controller = "Volunteer",
                    Action = "Apply",
                    Name = "Volunteer"
                }
            };
        }
    }
}
