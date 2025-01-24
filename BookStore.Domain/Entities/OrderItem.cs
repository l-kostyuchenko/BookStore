﻿namespace BookStore.Domain.Entities
{
	public class OrderItem : BaseEntity
	{
		public int BookId { get; set; }
		public Book Book { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public int OrderId { get; set; }
		public Order Order { get; set; }
	}
}
