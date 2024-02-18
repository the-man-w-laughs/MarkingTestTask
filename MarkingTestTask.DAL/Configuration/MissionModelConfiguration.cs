using MarkingTestTask.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarkingTestTask.DAL.Configuration
{
    public class MissionModelConfiguration : IEntityTypeConfiguration<MissionModel>
    {
        public void Configure(EntityTypeBuilder<MissionModel> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.HasMany(m => m.Boxes)
                   .WithOne(b => b.Mission)
                   .HasForeignKey(b => b.MissionId);
            builder.HasMany(m => m.Pallets)
                   .WithOne(p => p.Mission)
                   .HasForeignKey(p => p.MissionId);
            builder.HasMany(m => m.Products)
                   .WithOne(p => p.Mission)
                   .HasForeignKey(p => p.MissionId);
        }
    }
}
