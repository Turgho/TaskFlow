using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.ValueObjects.User;

namespace TaskFlow.Infrastructure.EntityTypeConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(100);

        // Email como Owned Type
        builder.OwnsOne(u => u.Email, e =>
        {
            e.Property(p => p.Value)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(255);

            e.HasIndex(p => p.Value).IsUnique();
        });

        // PasswordHash como Owned Type
        builder.OwnsOne(u => u.PasswordHash, p =>
        {
            p.Property(x => x.Value)
                .HasColumnName("PasswordHash")
                .IsRequired()
                .HasMaxLength(255);
        });

        builder.Property(u => u.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(u => u.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate();

        builder.Property(u => u.LastLoginAt)
            .IsRequired(false);
    }
}