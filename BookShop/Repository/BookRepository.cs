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
            new BookModel(){Id=101,Name="Java", Title="Java Programming Language",Author="Md. Miju Ahamed1",Price=1000,Category="Programming",Language="English",TotalPage=1006},
            new BookModel(){Id=102,Name="C", Title="C Programming Language",Author="Shamsi",Price=2000,Category="Programming",Language="English",TotalPage=2000},
            new BookModel(){Id=103,Name="C#", Title="C# Programming Language",Author="Shakeeb",Price=3000,Category="Programming",Language="English",TotalPage=20050},
            new BookModel(){Id=104,Name="C++", Title="C++ Programming Language",Author="Mominul Islam",Price=4000,Category="Programming",Language="English",TotalPage=1006},
            new BookModel(){Id=105,Name="Pithon", Title="Pithon Programming Language",Author="Anik",Price=5000,Category="Programming",Language="English",TotalPage=100},
            new BookModel(){Id=106,Name="English", Title="English Programming Language",Author="Sarker",Price=1000,Category="Programming",Language="English",TotalPage=1076},
            new BookModel(){Id=107,Name="Bangla", Title="Bangla Programming Language",Author="Romeo",Price=9000,Category="Programming",Language="English",TotalPage=1002},
            new BookModel(){Id=108,Name="Math", Title="Math Programming Language",Author="John",Price=11000,Category="Programming",Language="English",TotalPage=100},
        };
        }
    }
    
    
}
