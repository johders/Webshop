using System.ComponentModel.DataAnnotations;

namespace PE1.Webshop.Web.Services
{
	public class PropertiesRequired : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			if(value != null)
			{
				var input = value as List<int>;
				if (input.Count > 0)
				{
					return true;
				}
			}
			

			return false;
		}
	}
}
