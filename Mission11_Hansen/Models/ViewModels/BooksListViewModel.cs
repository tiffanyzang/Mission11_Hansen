namespace Mission11_Hansen.Models.ViewModels
{
    public class BooksListViewModel
    {
        public required IQueryable<Book> Books { get; set;}

        public PaginationInfo PaginationInfo { get; set;} = new PaginationInfo();

        public string? CurrentBookType { get; set; }
    }
}
