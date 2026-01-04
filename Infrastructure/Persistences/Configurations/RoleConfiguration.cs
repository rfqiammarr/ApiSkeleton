using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Persistences;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;

namespace RifqiAmmarR.ApiSKeleton.Infrastructure.Persistences.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable($"{nameof(IAppDbContext.Roles)}");
        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(r => r.RoleId);
            // Properties
            builder.Property(r => r.RoleId)
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
