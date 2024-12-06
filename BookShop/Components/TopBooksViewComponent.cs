using BookShop.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookShop.Components
{
    public class TopBooksViewComponent:ViewComponent
    {
        private readonly IBookRepository _bookRepository;
        public TopBooksViewComponent(IBookRepository bookRepository)
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
