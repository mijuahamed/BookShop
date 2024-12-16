using BookShop.Models;
using System.Threading.Tasks;

namespace BookShop.Service
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);
    }
}