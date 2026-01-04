using Application.Interfaces.Services.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure.Persistances.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable($"{nameof(IAppDbContext.Permissions)}");
        if(builder is not null)
        {
            builder.HasKey(x => x.PermissionId);
            builder.Property(x => x.PermissionId)
                .HasColumnName("PermissionId");
            builder.Property(x => x.PermissionCode)
                .IsRequired()
                .HasMaxLength(50);

            // Relasi One-to-Many
            builder.HasMany(x => x.Users)
                   .WithOne(x => x.Permission)
                   .HasForeignKey(x => x.PermissionId);
        }
    }
}
