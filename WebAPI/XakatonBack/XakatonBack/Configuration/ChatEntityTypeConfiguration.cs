using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XakatonBack.Model;

namespace XakatonBack.Configuration
{
    public class ChatEntityTypeConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasKey(ch => ch.Id)
                .HasName("PK_Chats_Id");

            builder.Property(ch => ch.Message)
                .IsRequired(false)
                .HasMaxLength(3500)
                .HasColumnType("nvarchar");

        }
    }
}
