using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.Configs
{
	public class OrderConfig : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.HasComment("Заказы");

			builder.HasKey(x => x.Id);

			builder
				.HasMany(x => x.OrderItems)
				.WithOne(x => x.Order);
		}
	}
}
