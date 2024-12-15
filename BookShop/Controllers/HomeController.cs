using BookShop.Repository;
using BookShop.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookShop.Controllers
{
    public class HomeController: Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserService _userService;
        public HomeController(IBookRepository bookRepository,IUserService userService)
        {
            _bookRepository = bookRepository;
            _userService = userService;
        }

        public async Task<ViewResult> Index()
        {
            var id=_userService.GetUserId();
            var isLoggedIn=_userService.IsAuthenticated();
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
