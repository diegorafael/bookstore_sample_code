using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataPersistence.DatabaseMapping
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");
            builder.Property(b => b.Id)
                .HasColumnName("BookId")
                .ValueGeneratedOnAdd();
            builder.OwnsOne(b => b.Category)
                .Property(c => c.Name).HasColumnName("CategoryName");
            builder.OwnsOne(b => b.Category)
                .Property(c => c.Location).HasColumnName("CategoryLocation");
        }
    }
}
