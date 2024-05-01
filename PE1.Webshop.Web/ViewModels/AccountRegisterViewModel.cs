using System.ComponentModel.DataAnnotations;

namespace PE1.Webshop.Web.ViewModels
{
    public class AccountRegisterViewModel
    {
        [Required(ErrorMessage = "Please provide username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please provide password")]
        [Display(Name = "Password")]
        [Compare("PasswordCheck", ErrorMessage = "Passwords must match!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Passwords repeat password")]
        [Display(Name = "Repeat Password")]
        [DataType(DataType.Password)]
        public string PasswordCheck { get; set; }

        [Required(ErrorMessage = "Please provide first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide email address")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
