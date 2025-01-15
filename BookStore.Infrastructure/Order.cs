using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure
{
	public class Order
	{
		public int Id { get; set; }
		public DateTime OrderDate { get; set; }
		public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
		//public decimal TotalAmount { get; set; }
		public string CustomerName { get; set; } 
	}
}
