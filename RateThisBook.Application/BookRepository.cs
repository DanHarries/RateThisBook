using Microsoft.EntityFrameworkCore;
using RateThisBook.Application.DTO;
using RateThisBook.Application.Interfaces;
using RateThisBook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateThisBook.Application
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _db;

        public BookRepository(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Get all books from db
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BooksDTO>> GetAllBooks()
        {
            var dto = new List<BooksDTO>();
            var bookCollection = await _db.Books.ToListAsync();

            foreach (var book in bookCollection)
            {
                dto.Add(new BooksDTO()
                {
                    BookRef = book.BookRef,
                    BookTitle = book.BookTitle,
                    Authors = book.Authors
                    
                });
                  
            }

            return dto;

        }


        /// <summary>
        /// Get book by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BooksDTO> GetBookById(int id)
        {
            return EntityToDTO(await _db.Books.Where(x => x.BookRef == id).SingleOrDefaultAsync());
        }

        /// <summary>
        /// Get books by search input
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public Task<IEnumerable<BooksDTO>> GetBooksBySearch(string book)
        {
            throw new NotImplementedException();
        }

        #region Private Methods

        /// <summary>
        /// Again for speed made private should probaly be in a class for scaling
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        private BooksDTO EntityToDTO(Books books)
        {
            return new BooksDTO
            {
                Authors = books.Authors,
                BookRef = books.BookRef,
                Summary = books.Summary,
                BookTitle = books.BookTitle                
            };


        }

        #endregion
    }
}
