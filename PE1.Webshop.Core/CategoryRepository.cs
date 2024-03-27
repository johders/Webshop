using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core
{
    public class CategoryRepository
    {
        public IEnumerable<Category> Categories { get; set; }
        public CategoryRepository() 
        {
            Categories = new List<Category>
            {
                new Category{Id = 1, Name = "Light Roast"},
                new Category{Id = 2, Name = "Medium Roast"},
                new Category{Id = 3, Name = "Dark Roast"}
            };       
        }

		public Category GetCategoryById(int id)
		{
			return Categories.FirstOrDefault(c => c.Id == id);
		}
	}
}
