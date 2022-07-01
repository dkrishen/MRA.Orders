using BookApi.Models;
using BookApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookRepository _bookRepository;


        public BookController(ILogger<BookController> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        [HttpGet]
        [Route("GetAllBooks")]
        public IActionResult GetBooks()
        {
            var tmp = _bookRepository.GetBooks();
            var tmp2 = JsonConvert.SerializeObject(tmp);
            return Ok(tmp2);
        }

        [HttpGet]
        [Route("GetBooksByUserId")]
        public IActionResult GetBooksByUserId(string data)
        {
            Guid userId = JsonConvert.DeserializeObject<Guid>(data);
            return Ok(JsonConvert.SerializeObject(_bookRepository.GetBooksByUser(userId)));
        }

        [HttpPost]
        [Route("AddBook")]
        public IActionResult AddBook(string data)
        {
            Book book = JsonConvert.DeserializeObject<Book>(data);
            _bookRepository.AddBook(book);

            return Ok();
        }
    }
}
