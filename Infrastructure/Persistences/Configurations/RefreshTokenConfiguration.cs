using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Persistences;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;

namespace RifqiAmmarR.ApiSKeleton.Infrastructure.Persistences.Configurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable($"{nameof(IAppDbContext.RefreshTokens)}");
        if (builder is not null)
        {
            builder.HasKey(rt => rt.Id);
            builder.Property(rt => rt.Id)
                .HasColumnName("RefreshTokenId");

            builder.HasOne(rt => rt.User)
              .WithOne(u => u.RefreshToken)
              .HasForeignKey<RefreshToken>(rt => rt.UserId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
