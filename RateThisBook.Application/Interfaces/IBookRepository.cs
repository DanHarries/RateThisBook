using RateThisBook.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RateThisBook.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<BooksDTO>> GetAllBooks();

        Task<IEnumerable<BooksDTO>> GetBooksBySearch(string book);

        Task<BooksDTO> GetBookById(int id);

        // Add, Edit Delete Possibly in here

    }
}
