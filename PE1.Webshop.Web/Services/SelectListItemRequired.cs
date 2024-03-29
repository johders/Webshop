using System.ComponentModel.DataAnnotations;

namespace PE1.Webshop.Web.Services
{
	public class SelectListItemRequired : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			var input = value as int?;
			if (input != 0)
			{
				return true;
			}

			return false;
		}
	
	}
}
