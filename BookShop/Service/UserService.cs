using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BookShop.Service
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public UserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public string GetUserId()
        {

            return _contextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
