using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Core;
using System.Reflection.Emit;

namespace PE1.Webshop.Web.Data
{
	public class DataSeeder
	{
		public static void Seed(ModelBuilder modelBuilder)
		{

			var categories = new List<Category>
			{
				new Category{Id = 1, Name = "Light Roast", ImageString = $"~/images/roast-1.jpg"},
				new Category{Id = 2, Name = "Medium Roast", ImageString = $"~/images/roast-2.jpg"},
				new Category{Id = 3, Name = "Dark Roast", ImageString = $"~/images/roast-3.jpg"}
			};

			var properties = new List<Property>
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

			var coffees = new List<Coffee>
			{
				new Coffee
				{
					Id = 1,
					Name = "Cantagallo",
					Description = "A floral and chocolatey coffee straight from small farmers in northern Nicaragua. Light Roast.",
					Origin = "Nicaragua",
					Price = 20m,
					CategoryId = 1,
					ImageString = $"~/images/sku-1.webp",
					CertifiedOrganic = true

				},
				new Coffee
				{
					Id = 2,
					Name = "La Flor",
					Description = "A sweet, balanced blend of natural and wash-processed coffees creating one of our favorites. Light Roast.",
					Origin = "Ethiopia Sidama, Mexico, Nicargua",
					Price = 20m,
					CategoryId = 1,
					ImageString = $"~/images/sku-2.webp",
					CertifiedOrganic = true
				},
				new Coffee
				{
					Id = 3,
					Name = "Perú",
					Description = "Deep in the Andes of Perú, the founding farmers of Pachamama grow exceptional organic coffee. Medium Roast.",
					Origin = "Santa Teresa, Cusco, Peru",
					Price = 18.5m,
					CategoryId = 2,
					ImageString = $"~/images/sku-3.webp",
					CertifiedOrganic = false
                },
				 new Coffee
				{
					Id = 4,
					Name = "Nicaragua",
					Description = "The northern mountains of Las Segovia, Nicaragua, are known for their quality coffee and strong cooperatives. Medium Roast.",
					Origin = "Río Coco, Nicaragua",
					Price = 18.5m,
					CategoryId = 2,
					ImageString = $"~/images/sku-4.webp",
					CertifiedOrganic = true
				},
				  new Coffee
				{
					Id = 5,
					Name = "México",
					Description = "In the volcanic highlands of Veracruz, México, the terroir is ideal for growing exceptional coffee. Medium Roast.",
					Origin = "Huatusco, Mexico",
					Price = 19m,
					CategoryId = 2,
					ImageString = $"~/images/sku-5.webp",
					CertifiedOrganic = true
				},
				  new Coffee
				{
					Id = 6,
					Name = "Guatemala",
					Description = "Grown on the volcanic shores of Lago Atitlán, this is an exceptional single origin coffee from Guatemala. Medium Roast.",
					Origin = "Santa Clara, Guatemala",
					Price = 20m,
					CategoryId = 2,
					ImageString = $"~/images/sku-6.webp",
					CertifiedOrganic = true
				},
				  new Coffee
				{
					Id = 7,
					Name = "French Roast",
					Description = "A rich, bold and satisfying, our French Roast Blend is a great coffee for those that prefer a darker roast. French Roast.",
					Origin = "Peru, Mexico, Nicaragua",
					Price = 17.5m,
					CategoryId = 3,
					ImageString = $"~/images/sku-7.webp",
					CertifiedOrganic = false
                },
				  new Coffee
				{
					Id = 8,
					Name = "Decaf French",
					Description = "Our Decaf French Roast is Mountain Water Processed (MWP) in Mexico, without the use of chemicals. Dark Roast.",
					Origin = "Huatusco, Mexico",
					Price = 19m,
					CategoryId = 3,
					ImageString = $"~/images/sku-8.webp",
					CertifiedOrganic = true
				},
				  new Coffee
				{
					Id = 9,
					Name = "Farmer's Blend",
					Description = "Our darkest roast, a bold blend with a full body and rich flavor. Italian Roast.",
					Origin = "Peru, Mexico, Nicaragua",
					Price = 17.5m,
					CategoryId = 3,
					ImageString = $"~/images/sku-9.webp",
					CertifiedOrganic = false
                },
				  new Coffee
				{
					Id = 10,
					Name = "Ethiopia Sidama Natural",
					Description = "A fruity, natural processed coffee from the Sidama region. Light Roast.",
					Origin = "Sidama, Ethiopia",
					Price = 25m,
					CategoryId = 1,
					ImageString = $"~/images/sku-10.webp",
					CertifiedOrganic = true
				},
				  new Coffee
				{
					Id = 11,
					Name = "Machu Picchu",
					Description = "Straight from the valley just below Machu Picchu, Perú, this single origin is roasted medium-dark. Vienna Roast.",
					Origin = "Santa Teresa, Cusco, Peru",
					Price = 18.5m,
					CategoryId = 2,
					ImageString = $"~/images/sku-11.webp",
					CertifiedOrganic = true
				},
				  new Coffee
				{
					Id = 12,
					Name = "Sunrise",
					Description = "The blend formerly known as Breakfast, Sunrise is always a bright and uplifting start to the day. Light Roast.",
					Origin = "Guatemala, Peru, Nicaragua",
					Price = 18.5m,
					CategoryId = 1,
					ImageString = $"~/images/sku-12.webp",
					CertifiedOrganic = false
                },
				  new Coffee
				{
					Id = 13,
					Name = "Classic Espresso",
					Description = "Pachamama's traditional, rich and bold roasted espresso blend. Full Roast.",
					Origin = "Ethiopia Sidama, Peru",
					Price = 20m,
					CategoryId = 3,
					ImageString = $"~/images/sku-13.webp",
					CertifiedOrganic = false
                },
				  new Coffee
				{
					Id = 14,
					Name = "Five Sisters",
					Description = "An all-time favorite and the perfect café de la casa, sure to please a crowd. Medium Roast.",
					Origin = "Ethiopia Yirgacheffe, Guatemala",
					Price = 19m,
					CategoryId = 2,
					ImageString = $"~/images/sku-14.webp",
					CertifiedOrganic = false
                },
				  new Coffee
				{
					Id = 15,
					Name = "Decaf México",
					Description = "Our Decaf Medium Roast is Mountain Water Processed (MWP) in Mexico, without the use of chemicals. Whole Beans.",
					Origin = "Huatusco, Mexico",
					Price = 19.5m,
					CategoryId = 2,
					ImageString = $"~/images/sku-15.webp",
					CertifiedOrganic = true
				},
				  new Coffee
				{
					Id = 16,
					Name = "Sactown",
					Description = "Celebrating our hometown Sacramento, a complex yet balanced blend of fruit forward coffees. Medium Roast.",
					Origin = "Ethiopia Sidama, Ethiopia Yirgacheffe, Guatemala, Mexico",
					Price = 21m,
					CategoryId = 2,
					ImageString = $"~/images/sku-16.webp",
					CertifiedOrganic = false
                },
				  new Coffee
				{
					Id = 17,
					Name = "Inca",
					Description = "A deep, smooth blend of natural and washed-processed coffee that's perfect for cold brewing. Full Roast.",
					Origin = "Ethiopia Sidama, Guatemala, Mexico",
					Price = 20m,
					CategoryId = 3,
					ImageString = $"~/images/sku-17.webp",
					CertifiedOrganic = false
                },
				  new Coffee
				{
					Id = 18,
					Name = "Ethiopia Yirgacheffe",
					Description = "A classic coffee from Yirgacheffe, crisp with layered complexity. Light Roast. Whole Beans.",
					Origin = "Yirgacheffe, Ethiopia",
					Price = 24m,
					CategoryId = 1,
					ImageString = $"~/images/sku-18.webp",
					CertifiedOrganic = true
				}
			};

			var coffeeProperties = new[]
            {
				new { CoffeesId = 1, PropertiesId = 1 },
                new { CoffeesId = 1, PropertiesId = 2 },
                new { CoffeesId = 1, PropertiesId = 3 },

                new { CoffeesId = 2, PropertiesId = 4 },
                new { CoffeesId = 2, PropertiesId = 5 },
                new { CoffeesId = 2, PropertiesId = 6 },

                new { CoffeesId = 3, PropertiesId = 1 },
                new { CoffeesId = 3, PropertiesId = 7 },
                new { CoffeesId = 3, PropertiesId = 8 },

                new { CoffeesId = 4, PropertiesId = 1 },
                new { CoffeesId = 4, PropertiesId = 2 },
                new { CoffeesId = 4, PropertiesId = 9 },

                new { CoffeesId = 5, PropertiesId = 1 },
                new { CoffeesId = 5, PropertiesId = 3 },
                new { CoffeesId = 5, PropertiesId = 10 },

                new { CoffeesId = 6, PropertiesId = 11 },
                new { CoffeesId = 6, PropertiesId = 12 },
                new { CoffeesId = 6, PropertiesId = 13 },

                new { CoffeesId = 7, PropertiesId = 1 },
                new { CoffeesId = 7, PropertiesId = 14 },
                new { CoffeesId = 7, PropertiesId = 15 },

                new { CoffeesId = 8, PropertiesId = 1 },
                new { CoffeesId = 8, PropertiesId = 14 },
                new { CoffeesId = 8, PropertiesId = 16 },

                new { CoffeesId = 9, PropertiesId = 16 },
                new { CoffeesId = 9, PropertiesId = 17 },
                new { CoffeesId = 9, PropertiesId = 18 },

                new { CoffeesId = 10, PropertiesId = 19 },
                new { CoffeesId = 10, PropertiesId = 20 },
                new { CoffeesId = 10, PropertiesId = 13 },

                new { CoffeesId = 11, PropertiesId = 1 },
                new { CoffeesId = 11, PropertiesId = 12 },
                new { CoffeesId = 11, PropertiesId = 17 },

                new { CoffeesId = 12, PropertiesId = 21 },
                new { CoffeesId = 12, PropertiesId = 22 },
                new { CoffeesId = 12, PropertiesId = 23 },

                new { CoffeesId = 13, PropertiesId = 1 },
                new { CoffeesId = 13, PropertiesId = 14 },
                new { CoffeesId = 13, PropertiesId = 17 },

                new { CoffeesId = 14, PropertiesId = 2 },
                new { CoffeesId = 14, PropertiesId = 12 },
                new { CoffeesId = 14, PropertiesId = 24 },

                new { CoffeesId = 15, PropertiesId = 2 },
                new { CoffeesId = 15, PropertiesId = 20 },
                new { CoffeesId = 15, PropertiesId = 11 },

                new { CoffeesId = 16, PropertiesId = 13 },
                new { CoffeesId = 16, PropertiesId = 24 },
                new { CoffeesId = 16, PropertiesId = 19 },

                new { CoffeesId = 17, PropertiesId = 20 },
                new { CoffeesId = 17, PropertiesId = 13 },
                new { CoffeesId = 17, PropertiesId = 19 },

                new { CoffeesId = 18, PropertiesId = 5 },
                new { CoffeesId = 18, PropertiesId = 9 },
                new { CoffeesId = 18, PropertiesId = 20 },

            };

			modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Property>().HasData(properties);
            modelBuilder.Entity<Coffee>().HasData(coffees);
			modelBuilder.Entity($"{nameof(Coffee)}{nameof(Property)}").HasData(coffeeProperties);
		}
	}
}
