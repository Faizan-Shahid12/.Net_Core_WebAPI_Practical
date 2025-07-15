using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApi_Practice.DTO;
using WebApi_Practice.Models.Interface;
using WebApi_Practice.Models;
using AutoMapper;

namespace WebApi_Practice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService1 book;
        private readonly IMapper map;

        public BooksController(IBookService1 value,IMapper map1)
        {
            book = value;
            map = map1;
        }

        [HttpGet(Name = "GetAllBooks") ]
        public IActionResult GetAllBooks()
        {
            return Ok(book.GetAll());
        }

        [HttpPost]
        public void AddNewBook(int id,string Title,string Description,string author)
        {
            book.Add(id,Title,Description,author);
        }

        [HttpPost ]
        public void AddNewBookUsingDTO(int id, [FromBody] BookDTO book1)
        {
            book.Add(id, book1.Title, book1.Description, book1.Author);
        }

        [HttpPost]
        public void AddNewBookUsingMapper(int id, [FromBody] BookDTO book1)
        {
            Book book2 = map.Map<Book>(book1);
            book2.Id = id;

            book.Add(book2);
        }


        [HttpDelete]
        public void DeleteBook(int id)
        {
            book.Remove(id);
        }

        [HttpGet]
        public IActionResult GetBookById(int id)
        {
            BookDTO book1 = book.GetBookById(id);

            if(book1 == null)
            {
                 return NotFound();
            }

            return Ok(book1);
        }

    }
}
