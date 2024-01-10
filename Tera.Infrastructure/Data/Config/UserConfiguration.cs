using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tera.Domain.Entities;

namespace Tera.Infrastructure.Data.Config;

public class UserConfiguration : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
        builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(255);


        builder.HasMany(u => u.Accounts)
           .WithOne(a => a.User)
           .HasForeignKey(a => a.UserId)
           .OnDelete(DeleteBehavior.Cascade);
    }
}
