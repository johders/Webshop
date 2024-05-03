using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.ViewComponents
{
    [ViewComponent(Name = "Login")]
    public class LoginViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var accountLoginViewModel = new AccountLoginViewModel();

            if (HttpContext.Session.Keys.Contains("Account"))
            {
                accountLoginViewModel = JsonConvert.DeserializeObject<AccountLoginViewModel>(HttpContext.Session.GetString("Account"));
            }

            var loginComponentViewModel = new LoginComponentViewModel
            {
                SignedIn = accountLoginViewModel.Authenticated,
                IsAdmin = accountLoginViewModel.IsAdmin,
                Username = accountLoginViewModel.Username
            };

            return await Task.FromResult(View(loginComponentViewModel));
        }
    }
}
