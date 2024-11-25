namespace BookShop.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public int TotalPage { get; set; }
        public string Language { get; set; }
    }
}
