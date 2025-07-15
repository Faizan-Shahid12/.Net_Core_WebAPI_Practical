using WebApi_Practice.DTO;

namespace WebApi_Practice.Models.Interface
{
    public interface IBookService1
    {

        public List<BookDTO> GetAll();

        public void Add(int id, string Title, string Description, string author);
        public void Add(Book book);
        public void AddBookUsingProcedure(Book book);

        public void Remove(int id);
        public void RemoveUsingProcedure(int id);

        public List<BookDTO> GetAllUsingProcedure();

        public BookDTO? GetBookById(int id);

    }
}
