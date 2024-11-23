using BookShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string name, string author)
        {
            return DataSource().Where(x=>x.Name.Contains(name)&&x.Author.Contains(author)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
        {
            new BookModel(){Id=101,Name="Java", Title="Java Programming Language",Author="Md. Miju Ahamed1",Price=1000 },
            new BookModel(){Id=102,Name="C", Title="C Programming Language",Author="Md. Miju Ahamed2",Price=2000 },
            new BookModel(){Id=103,Name="C#", Title="C# Programming Language",Author="Md. Miju Ahamed3",Price=3000},
            new BookModel(){Id=104,Name="C++", Title="C++ Programming Language",Author="Md. Miju Ahamed4",Price=4000},
            new BookModel(){Id=105,Name="Pithon", Title="Pithon Programming Language",Author="Md. Miju Ahamed5",Price=5000},
        };
        }
    }
    
    
}
