using Application.Interfaces.Services.Persistance;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistances.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable($"{nameof(IAppDbContext.Permissions)}");
        if(builder is not null)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
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
