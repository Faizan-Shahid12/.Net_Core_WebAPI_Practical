using WebApi_Practice.Models;
using WebApi_Practice.Models.Interface;

namespace WebApi_Practice.Models.Services
{
    public class BookService : IBookService
    {
        private List<Book> Books;

        public void setBook(List<Book> Books1) => Books = Books1;

        public BookService()
        {
            Books = new List<Book>();
            Books.Add(new Book(1, "Clean Code", "A Handbook of Agile Software Craftsmanship", "Robert C. Martin"));
            Books.Add(new Book(2, "The Pragmatic Programmer", "Your Journey to Mastery", "Andy Hunt and Dave Thomas"));
            Books.Add(new Book(3, "Design Patterns", "Elements of Reusable Object-Oriented Software", "Erich Gamma et al."));
            Books.Add(new Book(4, "Refactoring", "Improving the Design of Existing Code", "Martin Fowler"));
            Books.Add(new Book(5, "C# in Depth", "Deep dive into modern C#", "Jon Skeet"));

        }

        public void Add(Book book)
        {
            Books.Add(book);
        }

        public List<Book> GetAll()
        {
            return Books;
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
        }

        public Book? GetBookById(int id)
        {
            foreach (Book book in Books)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }

            return null;
        }
    }
}
