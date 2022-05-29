using Microsoft.EntityFrameworkCore;
using My_Books.Data.Models;
using My_Books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Books.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                ISRead = book.ISRead,
                DateRead = book.ISRead ? book.DateRead.Value : null,
                Rate = book.ISRead ? book.Rate.Value : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            await _context.SaveChangesAsync();
        }   

        public async Task<List<Book>> GetALLBooks() => await _context.Books.ToListAsync();
        //{
        //    var allBooks = _context.Books.ToList();
        //    return allBooks;
        //}

        public async Task<Book> GetBookById(int bookId) => await _context.Books.FirstOrDefaultAsync(n=> n.Id == bookId);

        public async Task<Book> UpdateBookById(int bookId, BookVM book)
        {
            var _book = await _context.Books.FirstOrDefaultAsync(n => n.Id == bookId);
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.ISRead = book.ISRead;
                _book.DateRead = book.ISRead ? book.DateRead.Value : null;
                _book.Rate = book.ISRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;

                await _context.SaveChangesAsync();
            }
            return _book;
        }

        public async Task DeleteBookById(int bookId)
        {
            var _book = await _context.Books.FirstOrDefaultAsync(n => n.Id == bookId); 
            if(_book != null)
            {
                _context.Books.Remove(_book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
