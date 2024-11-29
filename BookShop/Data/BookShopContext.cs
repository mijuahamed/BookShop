using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
    public class BookShopContext:DbContext
    {
        public BookShopContext(DbContextOptions<BookShopContext> options)
            : base(options) 
        {
        
        }
        public DbSet<Books> Books { get; set; }
        public DbSet<Language> Language { get; set; }
    }
}
