using Isopoh.Cryptography.Argon2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PE1.Webshop.Core;
using PE1.Webshop.Web.Data;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Controllers
{
    public class AccountController : Controller
    {
        private const string accountStateKey = "Account";
        private readonly CoffeeShopContext _coffeeshopContext;

        public AccountController(CoffeeShopContext coffeeshopContext)
        {
            _coffeeshopContext = coffeeshopContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AccountRegisterViewModel accountRegisterViewModel)
        {
            if(_coffeeshopContext.Users.Any(user => user.UserName.Equals(accountRegisterViewModel.UserName)))
            {
                ModelState.AddModelError("", "Credentials already exist in database");

            }
            if (!ModelState.IsValid)
            {
                return View(accountRegisterViewModel);
            }

            User newUser = new User
            {
                UserName = accountRegisterViewModel.UserName,
                FirstName = accountRegisterViewModel.FirstName,
                LastName = accountRegisterViewModel.LastName,
                Email = accountRegisterViewModel.Email,
                PassWord = Argon2.Hash(accountRegisterViewModel.Password)
            };

            try
            {
                _coffeeshopContext.Users.Add(newUser);
                await _coffeeshopContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError("", "Something went wrong...Please try again later..");
            }

            return RedirectToAction("RegisterSuccess");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountLoginViewModel accountLoginViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(accountLoginViewModel);
            }

            var user = await _coffeeshopContext.Users.FirstOrDefaultAsync(u => u.UserName.Equals(accountLoginViewModel.Username));

            if(user == null || !Argon2.Verify(user?.PassWord, accountLoginViewModel.Password))
            {
                ModelState.AddModelError("", "Incorrect username or password");
                return View(accountLoginViewModel);            
            }

            if(user != null)
            {
                accountLoginViewModel.IsAdmin = user.IsAdmin;
                accountLoginViewModel.Authenticated = true;
                accountLoginViewModel.FullName = user.FirstName + " " + user.LastName;
                HttpContext.Session.SetString(accountStateKey, JsonConvert.SerializeObject(accountLoginViewModel));
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registered()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session?.Remove(accountStateKey);
            return RedirectToAction("Index", "Home");
        }
    }
}
