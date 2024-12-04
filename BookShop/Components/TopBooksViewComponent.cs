using BookShop.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookShop.Components
{
    public class TopBooksViewComponent:ViewComponent
    {
        private readonly BookRepository _bookRepository;
        public TopBooksViewComponent(BookRepository bookRepository)
        {
            _bookRepository=bookRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var data =await _bookRepository.TopBooksAsync(count);
            return View(data);
        }

    }
}
