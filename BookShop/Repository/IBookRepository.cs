using BookShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShop.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(BookModel bookModel);
        Task<bool> DeleteBookById(int id);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int id);
        Task<List<BookModel>> TopBooksAsync(int count);
        bool UpdateBookById(int id, BookModel book);
    }
}