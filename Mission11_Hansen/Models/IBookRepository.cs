namespace Mission11_Hansen.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
