using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
	public class Order : BaseEntity
	{
		public DateTime OrderDate { get; set; }
		public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
		public string CustomerName { get; set; } 
	}
}
