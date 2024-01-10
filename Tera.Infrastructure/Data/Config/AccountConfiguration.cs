using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tera.Domain.Entities;

namespace Tera.Infrastructure.Data.Config;

public class AccountConfiguration : IEntityTypeConfiguration<AccountModel>
{
    public void Configure(EntityTypeBuilder<AccountModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(p => p.Balance).IsRequired();

        builder.HasOne(u => u.User)
          .WithMany(a => a.Accounts)
          .HasForeignKey(a => a.UserId)
          .OnDelete(DeleteBehavior.Cascade);
    }
}
