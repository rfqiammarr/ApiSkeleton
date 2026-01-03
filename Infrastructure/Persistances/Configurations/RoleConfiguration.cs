using Application.Interfaces.Services.Persistance;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistances.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable($"{nameof(IAppDbContext.Roles)}");
        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(r => r.Id);
            // Properties
            builder.Property(r => r.Id)
                   .HasColumnName("RoleId");
            builder.Property(r => r.RoleName)
                   .IsRequired()
                   .HasMaxLength(15);

            // Relasi One-to-Many
            builder.HasMany(x => x.Users)
                   .WithOne(x => x.Role)
                   .HasForeignKey(x => x.RoleId);
        }
    }
}
