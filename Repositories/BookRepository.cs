using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ILogger<BookRepository> _logger;
        private readonly BookContext _context;

        public BookRepository(BookContext context, ILogger<BookRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<BookDTO> Create(BookDTO book)
        {
            try
            {
                var bookToCreate = new Book
                {
                    Id = book.Id,
                    Author = book.Author,
                    Title = book.Title,
                    Rating = book.Rating
                };

                _context.Books.Add(bookToCreate);
                await _context.SaveChangesAsync();

                return book;
            }
            catch (Exception exception)
            {
                _logger.LogError("Error while adding new book", exception);

                throw;
            }
        }

        public async Task Delete(int id)
        {
            try 
            { 
                var bookToDelete = await _context.Books.FindAsync(id);
                _context.Books.Remove(bookToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while deleting a book with [id] = {id}", exception);

                throw;
            }
}

        public async Task<BookDTO> Get(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);

                if (book != null)
                {
                    return new BookDTO
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Author = book.Author,
                        Rating = book.Rating,
                    };
                }

                _logger.LogWarning($"Book with id [{id}] was not found");

                return null;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while retrieving a book with [id] = {id}", exception);

                throw;
            }
        }

        public async Task<IEnumerable<BookDTO>> GetAll()
        {
            try
            {
                var books = await _context.Books.ToListAsync();
                var booksToDisplay = new List<BookDTO>();

                foreach (var book in books)
                {
                    var bookToDisplay = new BookDTO
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Author = book.Author,
                        Rating = book.Rating,
                    };

                    booksToDisplay.Add(bookToDisplay);
                }

                return booksToDisplay;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while retrieving all books", exception);

                throw;
            }
        }

        public async Task Update(BookDTO book)
        {
            try
            {
                var bookToUpdate = new Book
                {
                    Id = book.Id,
                    Author = book.Author,
                    Title = book.Title,
                    Rating = book.Rating
                };

                _context.Entry(bookToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while updating a book with [id] = {book.Id}", exception);

                throw;
            }
        }
    }
}