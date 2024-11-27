using BookShop.Models;
using BookShop.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookShop.Controllers
{
    public class BookController : Controller
    {
        public readonly BookRepository _bookRepository=null;
        //BookController(BookRepository bookRepository)
        //{
        //    _bookRepository = bookRepository;
        //}
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public ViewResult GetAllBooks()
        {
            var data= _bookRepository.GetAllBooks();
            return View(data);
        }
        public ViewResult GetBookDetailsById(int id)
        {
            var data= _bookRepository.GetBookById(id);
            return View(data);
        }
        public List<BookModel> SerachBook(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName,authorName);
        }
        public ViewResult AddNewBook(bool isSuccess=false)
        {
            ViewBag.IsSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public IActionResult AddNewBook(BookModel bookModel)
        {
            int id=_bookRepository.AddNewBook(bookModel);
            if (id >0)
            {
                return RedirectToAction(nameof(AddNewBook), new {isSuccess=true});
            }

            return View();
        }
    }
}
