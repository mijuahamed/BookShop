using BookShop.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookShop.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUderAsync(SignUpUserModel userModel);
    }
}