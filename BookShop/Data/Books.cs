using System.Collections;
using System.Collections.Generic;

namespace BookShop.Data
{
    public class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public int TotalPage { get; set; }
        public int LanguageId { get; set; }
        public string Description { get; set; }

        public string CoverImageUrl { get; set; }
        public Language Language { get; set; }
        public ICollection<BookGallery> bookGallery { get; set; }
        public string BookPdfUrl { get; set; }


    }
}
