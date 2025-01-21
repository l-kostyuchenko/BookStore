using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
	public class Book : BaseEntity
	{		
		public string Title { get; set; }
		public string Author { get; set; }
		public string ISBN { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }		
		public DateTime PublicationDate { get; set; }
		
		public List<Category> Categories { get; set; } = new List<Category>();
	}
}
