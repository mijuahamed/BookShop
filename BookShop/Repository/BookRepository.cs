using BookShop.Data;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Repository
{
    public class BookRepository
    {
        private readonly BookShopContext _context = null;
        public BookRepository(BookShopContext context)
        {
            _context = context;
        }

        public async Task<int>  AddNewBook(BookModel bookModel)
        {
            var newbook = new Books()
            {
                Author = bookModel.Author,
                Name = bookModel.Name,
                Category = bookModel.Category,
                Description = bookModel.Description,
                LanguageId = bookModel.LanguageId,
                Price = bookModel.Price.HasValue? bookModel.Price.Value:0,
                Title = bookModel.Title,
                CoverImageUrl= bookModel.CoverImageUrl,
                BookPdfUrl= bookModel.BookPdfUrl,
                TotalPage = bookModel.TotalPage.HasValue? bookModel.TotalPage.Value : 0

            };
            newbook.bookGallery=new List<BookGallery>();
            foreach(var file in bookModel.Gallery)
            {
                BookGallery data = new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                };
                newbook.bookGallery.Add(data);
            }
           await _context.Books.AddAsync(newbook);
           await _context.SaveChangesAsync();
            return newbook.Id;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
           
            var books = await _context.Books.Select(bookdata => new BookModel()
            {
                Author = bookdata.Author,
                Name = bookdata.Name,
                Description = bookdata.Description,
                Id = bookdata.Id,
                LanguageId = bookdata.LanguageId,
                Price = bookdata.Price,
                Title = bookdata.Title,
                TotalPage = bookdata.TotalPage,
                Category = bookdata.Category,
                CoverImageUrl = bookdata.CoverImageUrl,
                
            }).ToListAsync();
            return books;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var data= await _context.Books.Where(book => book.Id == id).Select(bookdata => new BookModel()
            {
                Author = bookdata.Author,
                Name = bookdata.Name,
                Description = bookdata.Description,
                Id = bookdata.Id,
                LanguageId = bookdata.LanguageId,
                Price = bookdata.Price,
                Title = bookdata.Title,
                TotalPage = bookdata.TotalPage,
                Category = bookdata.Category,
                LanguageName = bookdata.Language.Name,
                CoverImageUrl= bookdata.CoverImageUrl,
                Gallery=bookdata.bookGallery.Select(g => new GalleryModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    URL = g.URL
                }).ToList(),
                BookPdfUrl= bookdata.BookPdfUrl,
            }).FirstOrDefaultAsync();
            return data;
           // var languageData=await _context.Language.FindAsync(bookdata.LanguageId);
        }
       public async Task<bool> DeleteBookById(int id)
        {
            var res=_context.Books.Where(x=>x.Id==id).FirstOrDefault();
            if (res != null)
            {
                _context.Books.Remove(res);
               await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public  bool UpdateBookById(int id,BookModel book)
        {
            
            var old_book = _context.Books.FirstOrDefault(e => e.Id ==id);
            var updatebook = new Books()
            {

                Name = book.Name,
                Title = book.Title,
                Author = book.Author,
                Price=(int)book.Price,
                TotalPage=(int)book.TotalPage,
                Description = book.Description,
                Category = old_book.Category,
                CoverImageUrl= old_book.CoverImageUrl,
                LanguageId=old_book.LanguageId,
                Id=old_book.Id,
                Language=old_book.Language,
                BookPdfUrl= old_book.BookPdfUrl,
                

            };
            _context.Entry(old_book).CurrentValues.SetValues(updatebook);
            _context.SaveChanges();
            return true;
           
        }

        //public List<BookModel> SearchBook(string name, string author)
        //{
        //    return DataSource().Where(x=>x.Name.Contains(name)&&x.Author.Contains(author)).ToList();
        //}

        //private List<BookModel> DataSource()
        //{
        //    return new List<BookModel>()
        //{
        //    new BookModel(){Id=1,Name="Java", Title="Java Programming Language",Author="Md. Miju Ahamed1",Price=1000,Category="Programming",Language="English",TotalPage=1006,Description="Java is a programming language that's: \r\nObject-oriented: Java is a fully object-oriented language that uses classes and objects to structure software. This makes Java a good choice for large-scale applications because it's easy to reuse, scale, and maintain code."},
        //    new BookModel(){Id=2,Name="C", Title="C Programming Language",Author="Shamsi",Price=2000,Category="Programming",Language="English",TotalPage=2000,Description="C is a general-purpose, procedural programming language that gives low-level access to a computer's memory: \r\nFeatures\r\nC is a machine-independent language that supports structured programming, recursion, and lexical variable scoping. It has a static type system and constructs that map well to common hardware instructions. "},
        //    new BookModel(){Id=3,Name="C#", Title="C# Programming Language",Author="Shakeeb",Price=3000,Category="Programming",Language="English",TotalPage=20050,Description="C# is a high-level, object-oriented programming language that's used to develop applications on the .NET platform: \r\nFeatures\r\nC# is a versatile language that supports multiple programming paradigms, including object-oriented, imperative, declarative, functional, and generic. It's also known for its familiar syntax and rich class of libraries. \r\n"},
        //    new BookModel(){Id=4,Name="C++", Title="C++ Programming Language",Author="Mominul Islam",Price=4000,Category="Programming",Language="English",TotalPage=1006,Description="C++ is a general-purpose, high-level programming language that's used to build software: \r\nFeatures\r\nC++ is an object-oriented language that emphasizes data fields with unique attributes, called objects. It also includes classes, inheritance, polymorphism, data abstraction, and encapsulation. C++ is designed to be efficient, flexible, and performant."},
        //    new BookModel(){Id=5,Name="Pithon", Title="Pithon Programming Language",Author="Anik",Price=5000,Category="Programming",Language="English",TotalPage=100,Description="Python is a high-level, object-oriented, interpreted programming language that is used for many different purposes, including:\r\nWeb development: Python is used for server-side and backend web development. \r\nSoftware development: Python is used for building software. \r\nData analysis: Python is used for data analysis. \r\nMachine learning: Python is used for machine learning."},
        //    new BookModel(){Id=6,Name="English", Title="English Programming Language",Author="Sarker",Price=1000,Category="Programming",Language="English",TotalPage=1076,Description="English is a West Germanic language that originated in England and is part of the Indo-European language family. It is the most spoken language in the world and is the official language of many countries, including the United States and Britain. Here are some characteristics of the English language: \r\nOrigin\r\nEnglish originated from the West Germanic dialects spoken by the Anglo-Saxons, and is named after the Angles, an ancient Germanic people who migrated to Britain."},
        //    new BookModel(){Id=7,Name="Bangla", Title="Bangla Programming Language",Author="Romeo",Price=9000,Category="Programming",Language="Bangla",TotalPage=1002,Description="বাংলা ভাষা (বাঙলা, বাঙ্গলা, তথা বাঙ্গালা নামেও পরিচিত) একটি ধ্রুপদী ইন্দো-আর্য ভাষা, যা দক্ষিণ এশিয়ার বাঙালি জাতির প্রধান কথ্য ও লেখ্য ভাষা। মাতৃভাষীর সংখ্যায় বাংলা ইন্দো-ইউরোপীয় ভাষা পরিবারের পঞ্চম[৮] ও মোট ব্যবহারকারীর সংখ্যা অনুসারে বাংলা বিশ্বের ৭ম বৃহত্তম ভাষা, এবং দাপ্তরিক ভাষা হিসেবে বাংলা ভাষার অবস্থান ১০ম।[৯][১০]\r\n\r\nবাংলা সার্বভৌম ভাষাভিত্তিক জাতিরাষ্ট্র বাংলাদেশের একমাত্র রাষ্ট্রভাষা তথা সরকারি ভাষা[১১] এবং ভারতের পশ্চিমবঙ্গ, ত্রিপুরা ও আসামের বরাক উপত্যকার দাপ্তরিক ভাষা। বঙ্গোপসাগরে অবস্থিত আন্দামান দ্বীপপুঞ্জের প্রধান কথ্য ভাষা বাংলা। এছাড়া, ভারতের ঝাড়খণ্ড, বিহার, মেঘালয়, মিজোরাম, ওড়িশার মতো রাজ্যগুলোতে উল্লেখযোগ্য পরিমাণে বাংলাভাষী জনগণ রয়েছে।"},
        //    new BookModel(){Id=8,Name="Math", Title="Math Programming Language",Author="John",Price=11000,Category="Programming",Language="English",TotalPage=100, Description = "Mathematical language is a system of communication that uses symbols, numbers, graphs, charts, and diagrams to express mathematical ideas and results: \r\nPrecision: Mathematical language is used to express ideas with precision and clarity. \r\nLogical reasoning: Mathematical language focuses on logical reasoning and cognitive structures. "},
        //};
        //}
    }
    
    
}
