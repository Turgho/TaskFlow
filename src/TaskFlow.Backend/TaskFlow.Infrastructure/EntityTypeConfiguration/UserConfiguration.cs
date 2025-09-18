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

        // Email (Value Object) armazenado como string
        builder.Property(u => u.Email)
            .HasConversion(
                email => email.Value,      // para banco
                value => new Email(value)  // do banco para objeto
            )
            .IsRequired()
            .HasMaxLength(255);

        // PasswordHash (Value Object) armazenado como string
        builder.Property(u => u.PasswordHash)
            .HasConversion(
                hash => hash.Value,
                value => new PasswordHash(value)
            )
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(u => u.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate();

        builder.Property(u => u.LastLoginAt)
            .IsRequired(false);

        // Índice único no Email
        builder.HasIndex(u => u.Email).IsUnique();
    }
}