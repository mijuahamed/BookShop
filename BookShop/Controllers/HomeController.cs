using BookShop.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookShop.Controllers
{
    public class HomeController: Controller
    {
        private readonly BookRepository _bookRepository;
        public HomeController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ViewResult> Index()
        {
            var data=await _bookRepository.GetAllBooks();
            return View(data);
        }
        public ViewResult AboutUs()
        {
            return View();
        }
    }
}
