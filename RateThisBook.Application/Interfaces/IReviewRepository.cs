using RateThisBook.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RateThisBook.Application.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<ReviewsDTO>> GetReviewsByBook(int book);

        Task<ReviewsDTO> PostBookReview(ReviewsDTO review);

        // Edit, Delete etc .... 

    }
}
