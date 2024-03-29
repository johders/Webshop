using System.ComponentModel.DataAnnotations;

namespace PE1.Webshop.Web.Services
{
	public class CheckBoxRequired : ValidationAttribute
	{

		public override bool IsValid(object value)
		{
			if (value is bool)
			{
				return (bool)value;
			}

			return false;
		}
	}
}
