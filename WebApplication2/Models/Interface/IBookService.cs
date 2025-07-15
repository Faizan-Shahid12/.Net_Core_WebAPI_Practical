namespace WebApi_Practice.Models.Interface
{
    public interface IBookService
    {
        public List<Book> GetAll();

        public void Add(Book book);

        public void Remove(int id);

        public Book? GetBookById(int id);

        public void setBook(List<Book> Books);
    }
}
