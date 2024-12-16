using BookShop.Models;
using BookShop.Repository;
using BookShop.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShop.Controllers
{
    public class HomeController: Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        public HomeController(IBookRepository bookRepository,IUserService userService, IEmailService emailService)
        {
            _bookRepository = bookRepository;
            _userService = userService;
            _emailService = emailService;
        }

        public async Task<ViewResult> Index()
        {
            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { "test@gmail.com" }
            };
            await _emailService.SendTestEmail(options);

          //  var id=_userService.GetUserId();
            //var isLoggedIn=_userService.IsAuthenticated();
           // var data=await _bookRepository.GetAllBooks();
           // return View(data);
           return View();
        }
        public ViewResult AboutUs()
        {
            return View();
        }
    }
}
