using System.ComponentModel.DataAnnotations;

namespace PE1.Webshop.Web.ViewModels
{
    public class AccountLoginViewModel
    {
        [Required(ErrorMessage = "Please provide Username")]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please provide password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
        public bool Authenticated { get; set; }
        public string ImageString 
        { 
            get 
            {
                if (Username == "bsoete" || Username == "jders" || Username == "bob" || Username == "joemama")
                {
                    return Username;
                }
                else return "generic";
            } 
        }
    }
}
