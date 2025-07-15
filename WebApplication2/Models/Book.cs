using WebApi_Practice.Models.Interface;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebApi_Practice.Models
{
    public class Book 
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }
        public Book() { }

        public Book(int id, string title, string description, string author)
        {
            Id = id;
            Title = title;
            Description = description;
            Author = author;
        }

    }

}
