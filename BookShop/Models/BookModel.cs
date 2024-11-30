using BookShop.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace BookShop.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be {1} characters or less")]
        public string Name { get; set; }
        [StringLength(100,MinimumLength =5)]
       // [MyCustomValidation("Title")]

        public string Title { get; set; }
       // [MyCustomValidation("Author",ErrorMessage = "Your elegant error message goes here")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Please enter a valid price")]
        public double? Price { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage = "Please enter a valid page number")]
        [Display(Name="Total Page of Book")]
        public int? TotalPage { get; set; }
       // [Required(ErrorMessage = "Please choose your language")]
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        //[Required(ErrorMessage = "Please choose your language")]
        //public List<string> MultiLanguage { get; set; }
        public string Description { get; set; }

        
    }
}
