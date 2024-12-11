using BookShop.Models;
using BookShop.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace BookShop.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [Route("signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUserModel usermodel)
        {
            if (ModelState.IsValid)
            {
                var result=await _accountRepository.CreateUderAsync(usermodel);
                if (!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }

                    return View(usermodel);
                }
                else
                {
                    ViewBag.IsSuccess=true;
                    ModelState.Clear();
                    return View(usermodel);
                }
                
            }

            return View(usermodel);
        }


        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(signInModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");   
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                }

            }

            return View(signInModel);
        }

        [Route("logut")]
        public async Task<IActionResult> Logout()
        {
           await _accountRepository.SignOutAsync();
           return RedirectToAction("Index", "Home");
        }
    }
}
