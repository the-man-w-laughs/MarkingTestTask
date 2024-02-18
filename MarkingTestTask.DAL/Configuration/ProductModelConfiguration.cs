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
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasOne(p => p.Box)
                   .WithMany(b => b.Products)
                   .HasForeignKey(p => p.BoxId);
            builder.HasOne(p => p.Mission)
               .WithMany(m => m.Products)
               .HasForeignKey(p => p.MissionId);
        }
    }
}
