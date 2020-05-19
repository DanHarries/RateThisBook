using Microsoft.EntityFrameworkCore;
using RateThisBook.Application.DTO;
using RateThisBook.Application.Interfaces;
using RateThisBook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateThisBook.Application
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _db;

        public ReviewRepository(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>
        ///  Get reviews by book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ReviewsDTO>> GetReviewsByBook(int book)
        {
            var dto = new List<ReviewsDTO>();

            try
            {
                var reviewCollection = await _db.Reviews.Where(x => x.Id == book).ToListAsync();

                foreach (var review in reviewCollection)
                {
                    dto.Add(new ReviewsDTO()
                    {
                        Id = review.Id,
                        BookId = review.BookId,
                        Email = review.Email,
                        Name = review.Name,
                        ReviewDate = review.ReviewDate,
                        Rating = review.Rating,
                        Approved = review.Approved
                    });
                }

                return dto;
            }
            catch (Exception ex)
            {
                // Log error

                throw ex;
            }

           

        }

        /// <summary>
        /// Post book review
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        public async Task<ReviewsDTO> PostBookReview(ReviewsDTO review)
        {
            try
            {
                var postReview = new Reviews()
                {
                    BookId = review.BookId,
                    Email = review.Email,
                    Name = review.Name,
                    Rating = review.Rating,
                    ReviewDate = DateTime.Now,
                                        
                };

                _db.Reviews.Add(postReview);

                await _db.SaveChangesAsync();


                return EntityToDTO(postReview);


            }
            catch (Exception ex)
            {
                // Log error 

                throw ex;
            }
        }


        #region Private Methods

        /// <summary>
        /// For speed made private should probaly be in a class for scaling
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        private ReviewsDTO EntityToDTO(Reviews review)
        {
            return new ReviewsDTO
            {
                BookId = review.BookId,
                Email = review.Email,
                Name = review.Name,
                Rating = review.Rating,
                ReviewDate = review.ReviewDate
            };


        }

        #endregion

    }
}
