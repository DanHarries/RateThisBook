﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace RateThisBook.Data
{
    public partial class Reviews
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        public bool? Approved { get; set; }
    }
}