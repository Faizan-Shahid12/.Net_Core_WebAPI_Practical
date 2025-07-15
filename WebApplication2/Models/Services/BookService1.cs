using WebApi_Practice.DTO;
using WebApi_Practice.Models;
using WebApi_Practice.Models.Interface;

namespace WebApi_Practice.Models.Services
{
    public class BookService1 : IBookService1
    {
        private List<Book> Books;
        private readonly DB dB;
        public void setBook(List<Book> Books1) => Books = Books1;

        public BookService1(DB db)
        {
            dB = db;
            Books =  dB.GetBooks();
        }

        public void Add(int id, string Title, string Description, string author)
        {
            Book book = new Book(id,Title, Description, author);
            Books.Add(book);
            dB.AddBook(book);
        }

        public void Add(Book book)
        {
            Books.Add(book);
            dB.AddBook(book);
        }

        public void AddBookUsingProcedure(Book book)
        {
            Books.Add(book);
            dB.AddBookUsingProcedure(book);
        }

        public List<BookDTO> GetAll()
        {
            List<BookDTO> books = Books.Select(book => new BookDTO(book)).ToList();

            return books;
        }

        public List<BookDTO> GetAllUsingProcedure()
        {

            List<Book> Books1 = dB.GetBooksUsingProcedure();
            List<BookDTO> books = Books1.Select(book => new BookDTO(book)).ToList();

            return books;
        }


        public void Remove(int id)
        {
            foreach (Book books in Books.ToList())
            {
                if (books.Id == id)
                {
                    Books.Remove(books);
                }
            }

            dB.DeleteBook(id);
        }

        public void RemoveUsingProcedure(int id)
        {
            foreach (Book books in Books.ToList())
            {
                if (books.Id == id)
                {
                    Books.Remove(books);
                }
            }

            dB.DeleteBookUsingProcedure(id);
        }

        public BookDTO? GetBookById(int id)
        {
            foreach (Book book in Books)
            {
                if (book.Id == id)
                {

                    BookDTO bookDTO = new BookDTO(book);
                    return bookDTO;
                }
            }

            return null;
        }
    }
}
