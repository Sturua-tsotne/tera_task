using Microsoft.EntityFrameworkCore;
using Tera.Domain.Entities;
using Tera.Infrastructure.Data.Config;

namespace Tera.Infrastructure.Data;

public class TeraDbContext(DbContextOptions<TeraDbContext> options) : DbContext(options)
{
    public DbSet<UserModel> Users { get; set; }
    public DbSet<AccountModel> Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
