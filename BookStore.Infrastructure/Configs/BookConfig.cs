using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Persistence.Configs
{
	public class BookConfig : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.HasComment("Книги");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
			builder.Property(x => x.Author).IsRequired().HasMaxLength(50);

			builder
				.HasMany(b => b.Categories)
				.WithMany(c => c.Books);
		}
	}
}
