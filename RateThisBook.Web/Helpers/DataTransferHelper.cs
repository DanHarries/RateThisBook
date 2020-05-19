using RateThisBook.Application.DTO;
using RateThisBook.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateThisBook.Web.Helpers
{
    public class DataTransferHelper
    {

        public IEnumerable<HomePageViewModel> DTOToModel(IEnumerable<BooksDTO> dto)
        {
            var model = new List<HomePageViewModel>();

            foreach (var book in dto)
            {
                model.Add(new HomePageViewModel()
                {
                    Id = book.BookRef,
                    BookAuthor = book.Authors,
                    BookTitle = book.BookTitle                   

                });
            }

            return model;
        }
    }
}
