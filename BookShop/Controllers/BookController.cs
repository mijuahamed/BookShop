using BookShop.Models;
using BookShop.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookShop.Controllers
{
    public class BookController : Controller
    {
        public readonly IBookRepository _bookRepository=null;
        public readonly ILanguageRepository _languageRepository =null;
        public readonly IWebHostEnvironment _webHostEnvironment=null;

        public BookController(IBookRepository bookRepository, ILanguageRepository languageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ViewResult> GetAllBooks()
        {
            var data=await _bookRepository.GetAllBooks();
            return View(data);
        }
        public async Task<ViewResult> GetBookDetailsById(int id)
        {
            var data=await _bookRepository.GetBookById(id);
            return View(data);
        }

        public async Task<IActionResult> DeleteBookById(int id)
        {
           await _bookRepository.DeleteBookById(id);
            return RedirectToAction("GetAllBooks");
        }
        [HttpGet]
        public async Task<ActionResult> UpdateBookById(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
            //return RedirectToAction("GetBookDetailsById", new { id = id });
        }

        [HttpPost]
        public  ActionResult UpdateBookById(BookModel book)
        {
            var data =  _bookRepository.UpdateBookById(book.Id, book);
           // return View(data);
            return RedirectToAction("GetBookDetailsById", new { id = book.Id });
        }


        //public List<BookModel> SerachBook(string bookName, string authorName)
        //{
        //    return _bookRepository.SearchBook(bookName,authorName);
        //}
        public async Task<ViewResult> AddNewBook(bool isSuccess=false,int bookId=0)
        {
            //var model = new BookModel()
            //{
            //    Language = "2"
            //};
            //ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");



            //ViewBag.Language = GetLanguage().Select(x => new SelectListItem()
            //{
            //    Text = x.Text,
            //    Value = x.Id.ToString()
            //}).ToList();
            //var group1 = new SelectListGroup() { Name = "Group1" };
            //var group2 = new SelectListGroup() { Name = "Group2", Disabled = true };
            //var group3 = new SelectListGroup() { Name = "Group3" };
            //var group4 = new SelectListGroup() { Name = "Group4" };

            //ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text="Bangla",Value="1",Group=group1},
            //    new SelectListItem(){Text="Indian_Bangla",Value="2",Group=group1},
            //    new SelectListItem(){Text="Hindi",Value="3",Group=group2},
            //    new SelectListItem(){Text="Urdu",Value="4",Group=group2},
            //    new SelectListItem(){Text="English",Value="5",Group=group3,Selected=true},
            //    new SelectListItem(){Text="Foreign",Value="6",Group=group3},
            //    new SelectListItem(){Text="Chinese",Value="7",Group=group4},
            //    new SelectListItem(){Text="Japanese",Value="8",Group=group4,Disabled=true},
            //};

            var languages =await _languageRepository.GetAllLanguage();
        //    ViewBag.Language = new SelectList(languages, "Id", "Name");

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
           // return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                if (bookModel.CoverPhoto != null)
                {
                    string folder = "books/cover/";
                    bookModel.CoverImageUrl= await UploadImage(folder, bookModel.CoverPhoto);



                    //string folder = "books/cover/";
                    //folder += Guid.NewGuid().ToString() + "_" + bookModel.CoverPhoto.FileName;
                    //bookModel.CoverImageUrl="/"+folder;
                    //string serverFolder=Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    //await bookModel.CoverPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create)); ;
                }
                if (bookModel.BookPdf != null)
                {
                    string folder = "books/pdf/";
                    bookModel.BookPdfUrl = await UploadImage(folder, bookModel.BookPdf);
                }
                if (bookModel.GalleryFiles != null)
                {
                    string folder = "books/gallery/";
                    bookModel.Gallery = new List<GalleryModel>();
                    foreach(var file in bookModel.GalleryFiles)
                    {
                        var gallery=new GalleryModel()
                        {
                            Name = file.Name,
                            URL=await UploadImage(folder,file)
                        };
                        bookModel.Gallery.Add(gallery);
                    }
                    
                }


                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            var languages = await _languageRepository.GetAllLanguage();
          //  ViewBag.Language = new SelectList(languages, "Id", "Name");
            //var group1 = new SelectListGroup() { Name = "Group1" };
            //var group2 = new SelectListGroup() { Name = "Group2", Disabled = true };
            //var group3 = new SelectListGroup() { Name = "Group3" };
            //var group4 = new SelectListGroup() { Name = "Group4" };
            //ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text="Bangla",Value="1",Group=group1},
            //    new SelectListItem(){Text="Indian_Bangla",Value="2",Group=group1},
            //    new SelectListItem(){Text="Hindi",Value="3",Group=group2},
            //    new SelectListItem(){Text="Urdu",Value="4",Group=group2},
            //    new SelectListItem(){Text="English",Value="5",Group=group3,Selected=true},
            //    new SelectListItem(){Text="Foreign",Value="6",Group=group3},
            //    new SelectListItem(){Text="Chinese",Value="7",Group=group4},
            //    new SelectListItem(){Text="Japanese",Value="8",Group=group4,Disabled=true},
            //};


            //ViewBag.Language = GetLanguage().Select(x => new SelectListItem()
            //{
            //    Text = x.Text,
            //    Value = x.Id.ToString()
            //}).ToList();

            //ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");
            //ModelState.AddModelError("", "This is my custom error message");
            //ModelState.AddModelError("", "This is my second custom error message");


            return View();
        }

        public async Task<string> UploadImage(string folderPath,IFormFile file)
        {
            folderPath+=Guid.NewGuid().ToString()+ "_" + file.FileName;
            string serverFolder=Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/"+folderPath;
        }

        //private List<LanguageModel> GetLanguage()
        //{
        //    var languages = new List<LanguageModel>()
        //    {
        //        new LanguageModel(){Id=1,Text="Bangla"},
        //        new LanguageModel(){Id=2,Text="English"},
        //        new LanguageModel(){Id=3,Text="Arabic"}
        //    };
        //    return languages;
        //}
    }
}
