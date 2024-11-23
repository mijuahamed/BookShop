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
        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public ViewResult GetAllBooks()
        {
            var data= _bookRepository.GetAllBooks();
            return View();
        }
        public BookModel GetBook(int id)
        {
            return _bookRepository.GetBookById(id);
        }
        public List<BookModel> SerachBook(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName,authorName);
        }
    }
}
