using System.ComponentModel.DataAnnotations;

namespace PE1.Webshop.Web.Services.Validation
{
    public class PriceInputStringDigitValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var input = value as string;
                var removeDecimalPoints = input;

                if (input.Contains("."))
                {
                    removeDecimalPoints = input.Replace(".", "");
                }


                if (input.Contains(","))
                {
                    removeDecimalPoints = input.Replace(",", "");
                }

                bool onlyDigits = removeDecimalPoints.All(char.IsDigit);

                return onlyDigits;
            }


            return false;
        }
    }
}
