using BookShop.Models;
using BookShop.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace BookShop.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;
        public AccountRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        public async Task<IdentityResult> CreateUderAsync(SignUpUserModel userModel)
        {
            var user = new ApplicationUser()
            {
                Email = userModel.Email,
                UserName = userModel.Email,
                FirstName=userModel.FirstName,
                LastName=userModel.LastName,
                DateofBirth = userModel.DateofBirth,
                Gender=userModel.Gender,
                PhoneNumber=userModel.PhoneNumber

            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;

        }

        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
           var result= await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, false);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel changePasswordModel)
        {
            var userId = _userService.GetUserId();
            var user =await _userManager.FindByIdAsync(userId);

            return await _userManager.ChangePasswordAsync(user, changePasswordModel.CurrentPassword, changePasswordModel.NewPassword);
        }

    }
}
