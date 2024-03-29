using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core
{
    public class CoffeeRepository
    {
        public IEnumerable<Coffee> Coffees { get; set; }

        public CategoryRepository CategoryRepository { get; set; }

        public PropertyRepository PropertyRepository { get; set; }

        public CoffeeRepository()
        {
            CategoryRepository = new CategoryRepository();
            PropertyRepository = new PropertyRepository();

            Coffees = new List<Coffee>
            {
                new Coffee
                {
                    Id = 1,
                    Name = "Cantagallo",
                    Description = "A floral and chocolatey coffee straight from small farmers in northern Nicaragua. Light Roast.",
                    Origin = "Nicaragua",
                    Price = 20m,
                    Category = CategoryRepository.Categories.FirstOrDefault(cat => cat.Id == 1),
                    Properties = PropertyRepository.Properties.Where(p => p.Id == 1 || p.Id == 2 || p.Id == 3),
                    CertifiedOrganic = true
                    
                },
                new Coffee
                {
                    Id = 2,
                    Name = "La Flor",
                    Description = "A sweet, balanced blend of natural and wash-processed coffees creating one of our favorites. Light Roast.",
                    Origin = "Ethiopia Sidama, Mexico, Nicargua",
                    Price = 20m,
                    Category = CategoryRepository.Categories.FirstOrDefault(cat => cat.Id == 1),
                    Properties = PropertyRepository.Properties.Where(p => p.Id == 4 || p.Id == 5 || p.Id == 6),
                    CertifiedOrganic = true
                },
                new Coffee
                {
                    Id = 3,
                    Name = "Perú",
                    Description = "Deep in the Andes of Perú, the founding farmers of Pachamama grow exceptional organic coffee. Medium Roast.",
                    Origin = "Santa Teresa, Cusco, Peru",
                    Price = 18.5m,
                    Category = CategoryRepository.Categories.FirstOrDefault(cat => cat.Id == 2),
                    Properties = PropertyRepository.Properties.Where(p => p.Id == 1 || p.Id == 7 || p.Id == 8)                    
                },
                 new Coffee
                {
                    Id = 4,
                    Name = "Nicaragua",
                    Description = "The northern mountains of Las Segovia, Nicaragua, are known for their quality coffee and strong cooperatives. Medium Roast.",
                    Origin = "Río Coco, Nicaragua",
                    Price = 18.5m,
                    Category = CategoryRepository.Categories.FirstOrDefault(cat => cat.Id == 2),
                    Properties = PropertyRepository.Properties.Where(p => p.Id == 1 || p.Id == 2 || p.Id == 9),
                    CertifiedOrganic = true
                },
                  new Coffee
                {
                    Id = 5,
                    Name = "México",
                    Description = "In the volcanic highlands of Veracruz, México, the terroir is ideal for growing exceptional coffee. Medium Roast.",
                    Origin = "Huatusco, Mexico",
                    Price = 19m,
                    Category = CategoryRepository.Categories.FirstOrDefault(cat => cat.Id == 2),
                    Properties = PropertyRepository.Properties.Where(p => p.Id == 1 || p.Id == 3 || p.Id == 10),
                    CertifiedOrganic = true
                },
                  new Coffee
                {
                    Id = 6,
                    Name = "Guatemala",
                    Description = "Grown on the volcanic shores of Lago Atitlán, this is an exceptional single origin coffee from Guatemala. Medium Roast.",
                    Origin = "Santa Clara, Guatemala",
                    Price = 20m,
                    Category = CategoryRepository.Categories.FirstOrDefault(cat => cat.Id == 2),
                    Properties = PropertyRepository.Properties.Where(p => p.Id == 11 || p.Id == 12 || p.Id == 13),
                    CertifiedOrganic = true
                },
                  new Coffee
                {
                    Id = 7,
                    Name = "French Roast",
                    Description = "A rich, bold and satisfying, our French Roast Blend is a great coffee for those that prefer a darker roast. French Roast.",
                    Origin = "Peru, Mexico, Nicaragua",
                    Price = 17.5m,
                    Category = CategoryRepository.Categories.FirstOrDefault(cat => cat.Id == 3),
                    Properties = PropertyRepository.Properties.Where(p => p.Id == 1 || p.Id == 14 || p.Id == 15)
                },
                  new Coffee
                {
                    Id = 8,
                    Name = "Decaf French",
                    Description = "Our Decaf French Roast is Mountain Water Processed (MWP) in Mexico, without the use of chemicals. Dark Roast.",
                    Origin = "Huatusco, Mexico",
                    Price = 19m,
                    Category = CategoryRepository.Categories.FirstOrDefault(cat => cat.Id == 3),
                    Properties = PropertyRepository.Properties.Where(p => p.Id == 1 || p.Id == 14 || p.Id == 16),
                    CertifiedOrganic = true
                },
                  new Coffee
                {
                    Id = 9,
                    Name = "Farmer's Blend",
                    Description = "Our darkest roast, a bold blend with a full body and rich flavor. Italian Roast.",
                    Origin = "Peru, Mexico, Nicaragua",
                    Price = 17.5m,
                    Category = CategoryRepository.Categories.FirstOrDefault(cat => cat.Id == 3),
                    Properties = PropertyRepository.Properties.Where(p => p.Id == 16 || p.Id == 17 || p.Id == 18)
                },
                  new Coffee
                {
                    Id = 10,
                    Name = "Ethiopia Sidama Natural",
                    Description = "A fruity, natural processed coffee from the Sidama region. Light Roast.",
                    Origin = "Sidama, Ethiopia",
                    Price = 25m,
                    Category = CategoryRepository.Categories.FirstOrDefault(cat => cat.Id == 1),
                    Properties = PropertyRepository.Properties.Where(p => p.Id == 19 || p.Id == 20 || p.Id == 13),
                    CertifiedOrganic = true
                },
                  new Coffee
                {
                    Id = 11,
                    Name = "Machu Picchu",
                    Description = "Straight from the valley just below Machu Picchu, Perú, this single origin is roasted medium-dark. Vienna Roast.",
                    Origin = "Santa Teresa, Cusco, Peru",
                    Price = 18.5m,
                    Category = CategoryRepository.Categories.FirstOrDefault(cat => cat.Id == 2),
                    Properties = PropertyRepository.Properties.Where(p => p.Id == 12 || p.Id == 17 || p.Id == 1),
                    CertifiedOrganic = true
                },
                  new Coffee
                {
                    Id = 12,
                    Name = "Sunrise",
                    Description = "The blend formerly known as Breakfast, Sunrise is always a bright and uplifting start to the day. Light Roast.",
                    Origin = "Guatemala, Peru, Nicaragua",
                    Price = 18.5m,
                    Category = CategoryRepository.Categories.FirstOrDefault(cat => cat.Id == 1),
                    Properties = PropertyRepository.Properties.Where(p => p.Id == 21 || p.Id == 22 || p.Id == 23)
                },
				  new Coffee
				{
					Id = 13,
					Name = "Classic Espresso",
					Description = "Pachamama's traditional, rich and bold roasted espresso blend. Full Roast.",
					Origin = "Ethiopia Sidama, Peru",
					Price = 20m,
					Category = CategoryRepository.Categories.FirstOrDefault(cat => cat.Id == 3),
					Properties = PropertyRepository.Properties.Where(p => p.Id == 1 || p.Id == 14 || p.Id == 17)
				},
				  new Coffee
				{
					Id = 14,
					Name = "Five Sisters",
					Description = "An all-time favorite and the perfect café de la casa, sure to please a crowd. Medium Roast.",
					Origin = "Ethiopia Yirgacheffe, Guatemala",
					Price = 19m,
					Category = CategoryRepository.Categories.FirstOrDefault(cat => cat.Id == 2),
					Properties = PropertyRepository.Properties.Where(p => p.Id == 2 || p.Id == 12 || p.Id == 24)
				},
				  new Coffee
				{
					Id = 15,
					Name = "Decaf México",
					Description = "Our Decaf Medium Roast is Mountain Water Processed (MWP) in Mexico, without the use of chemicals. Whole Beans.",
					Origin = "Huatusco, Mexico",
					Price = 19.5m,
					Category = CategoryRepository.Categories.FirstOrDefault(cat => cat.Id == 2),
					Properties = PropertyRepository.Properties.Where(p => p.Id == 2 || p.Id == 20 || p.Id == 11),
                    CertifiedOrganic = true
                },
				  new Coffee
				{
					Id = 16,
					Name = "Sactown",
					Description = "Celebrating our hometown Sacramento, a complex yet balanced blend of fruit forward coffees. Medium Roast.",
					Origin = "Ethiopia Sidama, Ethiopia Yirgacheffe, Guatemala, Mexico",
					Price = 21m,
					Category = CategoryRepository.Categories.FirstOrDefault(cat => cat.Id == 2),
					Properties = PropertyRepository.Properties.Where(p => p.Id == 13 || p.Id == 24 || p.Id == 19)
				},
				  new Coffee
				{
					Id = 17,
					Name = "Inca",
					Description = "A deep, smooth blend of natural and washed-processed coffee that's perfect for cold brewing. Full Roast.",
					Origin = "Ethiopia Sidama, Guatemala, Mexico",
					Price = 20m,
					Category = CategoryRepository.Categories.FirstOrDefault(cat => cat.Id == 3),
					Properties = PropertyRepository.Properties.Where(p => p.Id == 20 || p.Id == 13 || p.Id == 19)
				},
				  new Coffee
				{
					Id = 18,
					Name = "Ethiopia Yirgacheffe",
					Description = "A classic coffee from Yirgacheffe, crisp with layered complexity. Light Roast. Whole Beans.",
					Origin = "Yirgacheffe, Ethiopia",
					Price = 24m,
					Category = CategoryRepository.Categories.FirstOrDefault(cat => cat.Id == 1),
					Properties = PropertyRepository.Properties.Where(p => p.Id == 5 || p.Id == 9 || p.Id == 20),
                    CertifiedOrganic = true
                }
			};
        }

        public IEnumerable<Coffee> GetCoffeeWithProperty(int id)
        {
            return Coffees.Where(s => s.Properties.Any(c => c.Id == id));
        }

		public IEnumerable<Coffee> GetCoffeeInCategory(int id)
		{
			return Coffees.Where(s => s.Category.Id == id);
		}

		public IEnumerable<Coffee> GetCoffeeByFlavorCategoryAndPrice(string flavor, decimal price, string category)
		{
			return Coffees.Where(s => s.Properties.Any(c => c.Name.ToLower().Contains(flavor)) && s.Price < price && s.Category.Name.ToLower().Contains(category));
		}

		public IEnumerable<Coffee> GetCoffeeByCategoryAndPrice(decimal price, string category)
		{
			return Coffees.Where(s => s.Price <= price && s.Category.Name.ToLower().Contains(category));
		}

        public IEnumerable<Coffee> GetCoffeeByRegionAndFlavor(string region, string flavor, bool certifiedOrganic)
		{
			return Coffees.Where(s => s.Origin.ToLower().Contains(region) && s.Properties.Any(c => c.Name.ToLower().Contains(flavor)) && s.CertifiedOrganic == certifiedOrganic);
		}

		public IEnumerable<Coffee> GetCoffeeByKeyWord(string keyword)
		{
			return Coffees.Where(s => s.Description.ToLower().Contains(keyword) || 
            s.Origin.ToLower().Contains(keyword) || s.Properties.Any(c => c.Name.ToLower().Contains(keyword)) ||
			s.Category.Name.ToLower().Contains(keyword) || s.Name.ToLower().Contains(keyword));
		}
	}
}
