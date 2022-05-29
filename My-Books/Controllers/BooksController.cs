using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Books.Data.Services;
using My_Books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet("get-all-books")]
        public async Task<IActionResult> GetAllBooks()
        {
            var allBooks = await _booksService.GetALLBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _booksService.GetBookById(id);
            return Ok(book);
        }

        [HttpPost("add-book")]
        public async Task<IActionResult> AddBook([FromBody]BookVM book)
        {
            await _booksService.AddBook(book);
            return Ok();
        }

        [HttpPut("update-book-by-id/{id}")]
        public async Task<IActionResult> UpdateBookById(int id, [FromBody]BookVM book)
        {
            var UpdatedBook = await _booksService.UpdateBookById(id, book);
            return Ok(UpdatedBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public async Task<IActionResult> DeleteBookById(int id)
        {
            await _booksService.DeleteBookById(id);
            return Ok();
        }
    }
}
