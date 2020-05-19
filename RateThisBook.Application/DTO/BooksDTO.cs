using RateThisBook.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RateThisBook.Application.DTO
{
    public class BooksDTO : Books
    {
        public int Average { get; set; }
    }
}
