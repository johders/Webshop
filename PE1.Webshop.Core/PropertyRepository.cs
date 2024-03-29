using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core
{
    public class PropertyRepository
    {
        public IEnumerable<Property> Properties { get; set; }      

        public PropertyRepository() 
        {
            Properties = new List<Property>
            {
                new Property{Id = 1, Name = "Chocolate"},
                new Property{Id = 2, Name = "Citrus"},
				new Property{Id = 3, Name = "Almond"},
				new Property{Id = 4, Name = "Vanilla"},
                new Property{Id = 5, Name = "Lemon"},
                new Property{Id = 6, Name = "Bright"},
                new Property{Id = 7, Name = "Cream"},
                new Property{Id = 8, Name = "Cherry"},
                new Property{Id = 9, Name = "Floral"},
                new Property{Id = 10, Name = "Orange"},
                new Property{Id = 11, Name = "Pear"},
                new Property{Id = 12, Name = "Caramel"},
                new Property{Id = 13, Name = "Cacao"},
                new Property{Id = 14, Name = "Bold"},
                new Property{Id = 15, Name = "Pecan nut"},
                new Property{Id = 16, Name = "Walnut"},
                new Property{Id = 17, Name = "Rich"},
                new Property{Id = 18, Name = "Butterscotch"},
                new Property{Id = 19, Name = "Blackberry"},
                new Property{Id = 20, Name = "Honey"},
                new Property{Id = 21, Name = "Honeydew"},
                new Property{Id = 22, Name = "Crisp"},
                new Property{Id = 23, Name = "Lime"},
				new Property{Id = 24, Name = "Balanced"}
			};
        }

        public Property GetPropertyById(int id)
        {
            return Properties.FirstOrDefault(s => s.Id == id);
        }

    }
}
