using WebApi_Practice.Models;

namespace WebApi_Practice.DTO
{
    public class BookDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }
        public BookDTO()
        { }

        public BookDTO(Book book)
        {
            Title = book.Title;
            Description = book.Description;
            Author = book.Author;
        }
        public BookDTO(string title, string description, string author)
        {
            Title = title;
            Description = description;
            Author = author;
        }
    }
}
