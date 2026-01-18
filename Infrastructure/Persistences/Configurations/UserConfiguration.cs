using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;
using RifqiAmmarR.ApiSKeleton.Infrastructure.Persistences.DataContext;

namespace RifqiAmmarR.ApiSKeleton.Infrastructure.Persistences.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable($"{nameof(IAppDbContext.Users)}");

        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(u => u.Id);

            // Properties
            builder.Property(u => u.Id)
             .HasColumnName("UserId");

            builder.Property(u => u.Username)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(u => u.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(50);


            builder.HasOne(x => x.Role)
               .WithMany(r => r.Users)
               .HasForeignKey(u => u.RoleId);

            builder.HasOne(x => x.Permission)
               .WithMany(p => p.Users)
               .HasForeignKey(u => u.PermissionId);
        }
    }
}
