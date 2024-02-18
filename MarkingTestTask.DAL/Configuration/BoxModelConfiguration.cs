using MarkingTestTask.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarkingTestTask.DAL.Configuration
{
    public class BoxModelConfiguration : IEntityTypeConfiguration<BoxModel>
    {
        public void Configure(EntityTypeBuilder<BoxModel> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasOne(b => b.Pallet)
                   .WithMany(p => p.Boxes)
                   .HasForeignKey(b => b.PalletId);
        }
    }
}
