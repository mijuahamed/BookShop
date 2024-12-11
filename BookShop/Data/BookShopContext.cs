using BookShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
    public class BookShopContext:IdentityDbContext<ApplicationUser>
    {
        public BookShopContext(DbContextOptions<BookShopContext> options)
            : base(options) 
        {
        
        }
        public DbSet<Books> Books { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<BookGallery> BookGallery { get; set; }
    }
}
