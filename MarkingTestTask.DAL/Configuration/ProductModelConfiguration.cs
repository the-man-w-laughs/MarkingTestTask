using MarkingTestTask.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarkingTestTask.DAL.Configuration
{
    public class ProductModelConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Box)
                   .WithMany(b => b.Products)
                   .HasForeignKey(p => p.BoxId);
        }
    }
}
