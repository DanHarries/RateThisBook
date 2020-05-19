using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RateThisBook.Application.Interfaces;

namespace RateThisBook.Web.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IReviewRepository _review;

        public DetailsController(IReviewRepository review)
        {
            _review = review;
        }

        public IActionResult Index(int id)
        {
            _review.GetReviewsByBook(id)

            return View();
        }
    }
}