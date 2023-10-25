using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XakatonBack.Model;

namespace XakatonBack.Configuration
{
    public class WeightEntityTypeConfiguration : IEntityTypeConfiguration<Weight>
    {
        public void Configure(EntityTypeBuilder<Weight> builder)
        {
            builder.HasKey(w => w.Id)
                .HasName("FK_Weight_Id");

            builder.Property(w => w.ImportanceFactor)
                .HasColumnType("decimal");

        }
    }
}
