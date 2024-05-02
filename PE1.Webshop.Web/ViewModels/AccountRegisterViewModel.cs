using System.ComponentModel.DataAnnotations;

namespace PE1.Webshop.Web.ViewModels
{
    public class AccountRegisterViewModel
    {
        [Required(ErrorMessage = "Please provide username")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please provide password")]
        [Display(Name = "Password")]
        [Compare("PasswordCheck", ErrorMessage = "Passwords must match!")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password needs to be at least 6 characters in length")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Passwords repeat password")]
        [Display(Name = "Repeat Password")]
        [DataType(DataType.Password)]
        public string PasswordCheck { get; set; }

        [Required(ErrorMessage = "Please provide first name")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide last name")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide email address")]
        [Display(Name = "Email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
