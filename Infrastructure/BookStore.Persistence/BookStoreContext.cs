using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BookStore.Domain.Entities;

namespace BookStore.Persistence
{
	public class BookStoreContext : DbContext
	{
		public DbSet<Book> Books { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }

		public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());			
		}
	}
}
