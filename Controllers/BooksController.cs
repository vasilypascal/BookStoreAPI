using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreAPI.Models;
using BookStoreAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<BookDTO>> GetBooks()
        {
            return await _bookRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {
            return await _bookRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<BookDTO>> PostBook([FromBody] BookDTO book)
        {
            var newBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { id = newBook.Id });
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] BookDTO book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            await _bookRepository.Update(book);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var bookToDelete = await _bookRepository.Get(id);
            if (bookToDelete == null)
            {
                return NotFound();
            }

            await _bookRepository.Delete(bookToDelete.Id);
            return NoContent();
        }
    }
}