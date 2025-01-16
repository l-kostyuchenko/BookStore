﻿using Domain.Entities;

namespace Domain.DTOs.Book
{
    public class CreateBookDto
	{
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public DateTime PublicationDate { get; set; }
        public string CoverImageUrl { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
