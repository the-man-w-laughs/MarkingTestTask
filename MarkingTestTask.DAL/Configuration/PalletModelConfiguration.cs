using MarkingTestTask.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarkingTestTask.DAL.Configuration
{
    public class PalletModelConfiguration : IEntityTypeConfiguration<PalletModel>
    {
        public void Configure(EntityTypeBuilder<PalletModel> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
