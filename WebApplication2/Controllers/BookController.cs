using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using WebApi_Practice.Models;
using WebApi_Practice.Models.Interface;

namespace WebApi_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        IBookService Books;

        public BookController(IBookService bookService)
        {
            Books = bookService;
        }

        [HttpGet(Name = "GetAllBook")]
        public IActionResult Get()
        {
            var B = Books.GetAll();

            return Ok(B);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            foreach (Book book in Books.GetAll())
            {
                if (book.Id == id)
                {
                    return Ok(book);
                }
            }

            return null;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book value)
        {
            Book book = new Book();
            book.Id = value.Id;
            book.Author = value.Author;
            book.Title = value.Title;
            book.Description = value.Description;
            Books.Add(book);

            return CreatedAtRoute("GetAllBook", book);
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] string value)
        {
            foreach (Book book in Books.GetAll().ToList())
            {
                if (book.Id == id)
                {
                    book.Author = value;
                    return Ok(book);
                }
            }

            return null;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            foreach (Book book in Books.GetAll().ToList())
            {
                if (book.Id == id)
                {
                    Books.Remove(id);
                }
            }

        }
    }
}
